using _8bitVonNeiman.Common;
using System.Collections.Generic;
using _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View;

namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication
{
    public class KeypadAndIndicationController : IDeviceInput, ISevenSegmentFormOutput
    {
        private KeypadAndIndicationForm _form;
        private readonly IDeviceOutput _output;

        private int _baseAddress = 40;
        private byte _irq = 4;

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

        //буфер матричной клавиатуры
        Queue<ExtendedBitArray> _keyBuffer = new Queue<ExtendedBitArray>();

        public KeypadAndIndicationController(IDeviceOutput output, int baseAddress, int irq)
        {
            _output = output;
            _baseAddress = baseAddress * 0x10;
            _irq = (byte)irq;
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
                _form.ShowRegisters(_addr, _sym, _cr, _sr, _videoMem, _keyBuffer);
            }
            else
            {
                _form.ShowRegisters(new ExtendedBitArray(),
                    new ExtendedBitArray(), new ExtendedBitArray(),
                    new ExtendedBitArray(), _videoMem, _keyBuffer);
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
                    _addr = memory;
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
                for (var reg = 0; reg < _videoMem.Length; reg++)
                {
                    SetSymbols(reg, _videoMem[reg]);
                }
                SizeBuffer();
            }

            if (!_cr[0] || _cr[7]) ResetButtonClicked();
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    return _addr;
                case 1:
                {
                    if (_keyBuffer.Count == 0) return new ExtendedBitArray();
                    var buf = _keyBuffer.Dequeue();
                    SizeBuffer();
                    return buf;
                }
                case 2:
                    return _cr;
                case 3:
                    return _sr;
            }
            return new ExtendedBitArray();
        }

        public override void UpdateUI()
        {
            UpdateForm();
        }

        public void ResetButtonClicked()
        {
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

            UpdateForm();
        }

        public void FormClosed()
        {
            _form = null;
            _output.DeviceFormClosed(this);
        }

        //установка видеопамяти
        private void SetVideoMem(ExtendedBitArray memory)
        {
            int index = new ExtendedBitArray(_addr.ToBinString().Substring(CountIgnoredBits())).NumValue();
            if (_form.SevenSegmentCount == 6)
                index = index % 6;

            _videoMem[index] = memory;

            if (IsAutoincrement())
            {
                _addr.Inc();
                _addr.Mod(new ExtendedBitArray(_form.SevenSegmentCount));
            }
        }

        //формирование прерывания
        private void MakeInterruption()
        {
            _output.MakeInterruption(_irq);
        }
        private bool IsInterruptionEnabled()
        {
            return _cr[2];
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

        //загрузка с автоинкрементом
        private bool IsAutoincrement()
        {
            return _cr[1];
        }

        //Количество пропускаемых бит, в зависимости от количества сегментов
        private int CountIgnoredBits()
        {
            if (_form.SevenSegmentCount < 4) return 7;
            return _form.SevenSegmentCount == 4 ? 6 : 5;
        }
        
        //получение значения размера буфера
        private void SizeBuffer()
        {
            _sr = (_keyBuffer.Count == 0)? new ExtendedBitArray(128) : new ExtendedBitArray(_keyBuffer.Count);
        }

        //нажатие клавиши на матричной клавиатуре
        public void Key(int num)
        { ;
            if (!IsEnabled()) return;
            if (_keyBuffer.Count < 8)
            {
                _keyBuffer.Enqueue(new ExtendedBitArray(num));
                SizeBuffer();
                if (IsInterruptionEnabled()) MakeInterruption();
            }
            else _sr[3] = true;
            UpdateForm();
        }
    }
}