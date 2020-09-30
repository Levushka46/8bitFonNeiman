using _8bitVonNeiman.Common;
using System;
using _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View;

namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication
{
    public class KeypadAndIndicationController : IDeviceInput, ISevenSegmentFormOutput
    {
        private KeypadAndIndicationForm _form;
        private readonly IDeviceOutput _output;
        //private delegate void UpdateFormDelegate();
        //private UpdateFormDelegate _updateFormDelegate;
        //todo: учёт, что адресс вывода не больше колличества сегментов
        //todo: SR - 1110 0001 - переполнение очереди
        //todo: CR - 0000 AISE - автоинкремент адреса в видеопамяти/прервывания/загрузка из видеопамяти/вкл-выкл
        //todo: циклический вывод из памяти
        //todo: тесты на количестве сегментов
        //todo: удаление лишнего кода
        //todo: рбота с прерываниями
        //todo: чистка формы и файла с Настройками формы 


        private int _baseAddress = 50;
        private byte _irq = 5;

        private ExtendedBitArray _sym = new ExtendedBitArray();

        private ExtendedBitArray _addr = new ExtendedBitArray();

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private ExtendedBitArray _sr = new ExtendedBitArray();

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

        /// Открывает форму, если она закрыта или закрывает, если открыта
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
                _form.ShowRegisters(_addr /*GetDr()*/, _sym, _cr, _sr, _videoMem);
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
            return _baseAddress <= address && address <= _baseAddress + 4;
        }

        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    _addr = memory;//SetDr(memory);
                    //NextAddress();
                    break;
                case 1:
                    _sym = memory;
                    break;
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
                SetSymbols(_addr.NumValue(), _sym.NumValue());
            }
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    //ExtendedBitArray value = _addr;//GetDr();
                    //NextAddress(); //нужен ли этот метод?
                    //return value;
                    return _addr;
                case 1:
                    return _sym;
                case 2:
                    return _cr;
                case 3:
                    return _sr;
                case 4:
                    return GetVideoMem();
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
            for (var i = 0; i < _videoMem.Length; i++)
            {
                _videoMem[i] = new ExtendedBitArray();
            }

            UpdateForm();
        }

        public void FormClosed()
        {
            _form = null;
            _output.DeviceFormClosed(this);
        }

        private void SetVideoMem(ExtendedBitArray memory)
        {
            ExtendedBitArray index = new ExtendedBitArray("00000" + _sr.ToBinString().Substring(0, 3));
            _videoMem[index.NumValue()] = memory;
        }

        private ExtendedBitArray GetVideoMem()
        {
            ExtendedBitArray index = new ExtendedBitArray("00000" + _sr.ToBinString().Substring(0, 3));
            return _videoMem[index.NumValue()];
        }

        private void MakeInterruption()
        {
            _output.MakeInterruption(_irq);
            //todo: использование, судить по клавиатуре
        }

        private void SetSymbols(int index, int symbol)
        {
            _form.sevenSegments[index].CustomPattern = symbol;
        }

        private bool IsEnabled()
        {
            return _cr[0];
        }

        private bool IsAutoincrement()
        {
            return _sym[1];
        }

        private void NextAddress()
        {
            if (IsAutoincrement())
            {
                _cr.Inc();
            }
        }
    }
}