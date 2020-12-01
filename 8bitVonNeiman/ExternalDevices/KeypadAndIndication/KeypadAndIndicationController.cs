using _8bitVonNeiman.Common;
using System;
using System.Collections.Generic;
using _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View;

namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication
{
    public class KeypadAndIndicationController : IDeviceInput, ISevenSegmentFormOutput
    {
        private KeypadAndIndicationForm _form;
        private readonly IDeviceOutput _output;

        //todo: учёт, что адресс вывода не больше колличества сегментов
        //todo: циклический вывод из памяти
        //todo: тесты на количестве сегментов
        //todo: удаление лишнего кода
        //todo: рбота с прерываниями
        //todo: чистка формы и файла с Настройками формы 

        private int _baseAddress = 40;
        private byte _irq = 4;

        private ExtendedBitArray _sym = new ExtendedBitArray();
        private ExtendedBitArray _addr = new ExtendedBitArray();
        private ExtendedBitArray _cr = new ExtendedBitArray();
        private ExtendedBitArray _sr = new ExtendedBitArray();

        private int _addrVideo = 0;

        private ExtendedBitArray [] _videoMem = new ExtendedBitArray[8] 
            {
                new ExtendedBitArray(), 
                new ExtendedBitArray(), 
                new ExtendedBitArray(), 
                new ExtendedBitArray(), 
                new ExtendedBitArray(), 
                new ExtendedBitArray(), 
                new ExtendedBitArray(), 
                new ExtendedBitArray()
            };

        //буффер матричной клавиатуры
        Queue<ExtendedBitArray> _keyBuffer = new Queue<ExtendedBitArray>();

        private delegate void SetCharacterDelegate(int textBoxIndex, char character);

        private SetCharacterDelegate _updateFormDelegate;

        public KeypadAndIndicationController(IDeviceOutput output)
        {
            _output = output;
            _updateFormDelegate = new SetCharacterDelegate((textBoxIndex, character) => _form.SetCharacter(textBoxIndex, character));

        }

        public override void OpenForm()
        {
            if (_form == null)
            {
                _form = new KeypadAndIndicationForm(this);
                _form.Show();
                UpdateForm();
                _form.ShowDeviceParameters(_baseAddress, _irq);
            }
            else
            {
                _form.Close();
            }
        }

        // Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState()
        {
            if (_form == null)
            {
                _form = new KeypadAndIndicationForm(this);
                _form.Show();
                UpdateForm();
            }
            else
            {
                _form.Close();
            }
        }

        private void UpdateForm()
        {
            if (IsEnabled())
            {
                _sym = (_keyBuffer.Count == 0)? new ExtendedBitArray() : _keyBuffer.Peek();
                _form.ShowRegisters(_addr, _sym, _cr, _sr, _videoMem);
            }
            else
            {
                _form.ShowRegisters(new ExtendedBitArray(),
                    new ExtendedBitArray(),
                    new ExtendedBitArray(),
                    new ExtendedBitArray(),
                    _videoMem); //сбрасывать ли видеопамять?
            }
        }

        public override bool HasMemory(int address)
        {
            return _baseAddress <= address && address <= _baseAddress + 5;
        }

        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    _addr = memory;
                    break;
                //case 1:
                //    _sym = _keyBuffer.Peek();
                //    break;
                case 2:
                    _cr = memory;
                    break;
                case 3:
                    _sr = memory;
                    break;
                case 4:
                    SetVideoMem(memory);
                    break;
            }

            if (IsEnabled())
            {
                for (var reg = 0; reg < _videoMem.Length; reg++)
                {
                    SetSymbols(reg, _videoMem[reg]);
                    //_sym = _videoMem[reg]; //убрать!!!
                }
            }

            if (!_cr[0]) ResetButtonClicked();
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    return _addr;
                case 1:
                    return (_keyBuffer.Count == 0) ? new ExtendedBitArray() : _keyBuffer.Dequeue();
                case 2:
                    return _cr;
                case 3:
                    return _sr;
                //case 4:
                //    return GetVideoMem();
                //case 5:
                //    return (_keyBuffer.Count == 0)? new ExtendedBitArray() : _keyBuffer.Dequeue();
            }
            return new ExtendedBitArray();
        }

        public override void UpdateUI()
        {
            UpdateForm();
        }

        public void ResetButtonClicked()
        {
            _form.ClearScreen();

            _addr = new ExtendedBitArray();
            _sym = new ExtendedBitArray();
            _cr = new ExtendedBitArray();
            _sr = new ExtendedBitArray();
            for (var reg = 0; reg < 8; reg++)
            {
                _videoMem[reg] = new ExtendedBitArray();
                SetSymbols(reg, _videoMem[reg]);
            }
            _keyBuffer.Clear();

            _addrVideo = 0;
            UpdateForm();
        }

        public void FormClosed()
        {
            _form = null;
            _output.DeviceFormClosed(this);
        }

        private void SetVideoMem(ExtendedBitArray memory)
        {
            //todo: предусмотреть что то, если оба флага установлены
            if (IsLoad() && !IsLoadToAddr())
            {
                _videoMem[_addrVideo] = memory;
                _addrVideo++;
            }

            if ((IsLoadToAddr() && !IsLoad()) || (IsLoadToAddr() && IsLoad()))
            {
                ExtendedBitArray index = new ExtendedBitArray(_addr.ToBinString().Substring(5));
                _videoMem[index.NumValue()] = memory;
                //_videoMem[_addr.NumValue()] = memory;
            }

            if (_addrVideo > _form.SevenSegmentCount-1)
            {
                _cr[1] = false;
                _addrVideo = 0;
            }
            //ExtendedBitArray index = new ExtendedBitArray("00000" + _sr.ToBinString().Substring(0, 3));
            //_videoMem[index.NumValue()] = memory;
        }

        //private ExtendedBitArray GetVideoMem()
        //{
        //    if (IsLoad() && !IsLoadToAddr())
        //    {
        //        return _videoMem[_addrVideo++];
        //    }

        //    if (IsLoadToAddr() && !IsLoad())
        //    {
        //        return _videoMem[_addr.NumValue()];
        //    }
        //    return new ExtendedBitArray();
        //}

        private void MakeInterruption()
        {
            _output.MakeInterruption(_irq);
            //todo: использование, судить по клавиатуре
        }

        //установка символа и точки в сегменте по видеопамяти
        private void SetSymbols(int index, ExtendedBitArray symbol)
        {
            int pointPosition = _form.PointPosition;
            if (index >= _form.SevenSegmentCount) return;
            //установка точки
            _form.sevenSegments[index].DecimalOn = symbol[pointPosition];
            //установка символа
            if (pointPosition == 7)
                _form.sevenSegments[index].CustomPattern = symbol.NumValue();
            else
                _form.sevenSegments[index].CustomPattern = symbol.NumValue() >> 1;
        }

        private bool IsEnabled()
        {
            return _cr[0];
        }

        //последовательная загрузка в видеопамять
        private bool IsLoad()
        {
            return _cr[1];
        }

        //загрузка в видеопамять по адресу
        private bool IsLoadToAddr()
        {
            return _cr[2];
        }

        private bool IsAutoincrement()
        {
            return _sym[1];
        }

        private bool IsOverflowBuffer()
        {
            return _sr[0];
        }

        private void NextAddress()
        {
            if (IsAutoincrement())
            {
                _cr.Inc();
            }
        }

        //нажатие клавиши на матричной клавиатуре
        public void Key(int num)
        {
            if (!IsEnabled() || IsOverflowBuffer()) return;
            if (_keyBuffer.Count < 8)
                _keyBuffer.Enqueue(new ExtendedBitArray(num));
            //переполнение при записи 8 символа
            if (_keyBuffer.Count == 8)
                _sr[0] = true;

            UpdateForm();
        }
    }
}