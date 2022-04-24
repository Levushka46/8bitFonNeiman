using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay.View;

namespace _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay
{
    public class LCDDisplayController : IDeviceInput, ILCDDisplayFormOutput
    {
        private LCDDisplayForm _form;
        private readonly IDeviceOutput _output;
        public void MemoryChanged(int rowIndex, int columnIndex, string v)
        {
            VideoMemory[columnIndex] = Convert.ToByte(v, 16);
            UpdateForm();
        }
        private int _baseAddress = 60;

        private ExtendedBitArray _scr = new ExtendedBitArray();

        private ExtendedBitArray _ar = new ExtendedBitArray();

        private byte[] VideoMemory = new byte[16]; // видеопамять

        private delegate void UpdateDelegate();

        private UpdateDelegate _updateFormDelegate;//для работы с потоком, вызов функции из другого потока

        public LCDDisplayController(IDeviceOutput output, int baseAddress)
        {
            _output = output;
            _baseAddress = baseAddress * 0x10;
            _updateFormDelegate = new UpdateDelegate(() => {_form.ShowRegisters(_ar, _ar, _scr);_form.ShowVideoMemory(VideoMemory);});
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    ExtendedBitArray value = GetDr();
                    NextAddress();
                    return value;
                case 1:
                    return _ar;
                case 2:
                    return _scr;
            }
            return new ExtendedBitArray();
        }

        public override bool HasMemory(int address)
        {
            return _baseAddress <= address && address <= _baseAddress + 2;
        }

        public override void OpenForm()
        {
            if (_form == null)
            {
                _form = new LCDDisplayForm(this);
            }
            _form.ShowDeviceParameters(_baseAddress);
            _form.Show();
            UpdateForm();
        }
        private bool IsEnabled()
        {
            return _scr[0];
        }

        private bool IsAutoincrement()
        {
            return _scr[2];
        }
        private bool IsReset()
        {
            return _scr[6];
        }
        private void NextAddress()
        {
            if (IsAutoincrement())
            {
                _ar.Inc();
                if(_ar.NumValue()>15)
                {
                    _ar = new ExtendedBitArray();
                }
            }
            
        }
        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    SetDr(memory);
                    NextAddress();
                    break;
                case 1:
                    _ar = memory;
                    break;
                case 2:
                    _scr = memory;
                    if(IsReset())
                    {
                        ResetButtonClicked();
                    };
                    break;
            }
        }
        private void UpdateForm()
        {
            //_form.ShowRegisters(_ar, _ar, _scr);
            //_form.ShowVideoMemory(VideoMemory);
            _form.Invoke(_updateFormDelegate);
        }
        public void FormClosed()
        {
            _form = null;

            _output.DeviceFormClosed(this);
        }
        public void CloseForm()
        {
            if(_form != null)
            _form.Close();
        }
        public void ResetButtonClicked()
        {
            _scr = new ExtendedBitArray();
            _ar = new ExtendedBitArray();
            for (int i= 0; i< 16; i++)
            {
                VideoMemory[i] = 0;
            }
            //обнуление формы и регистров
            UpdateForm();
        }
        private void SetDr(ExtendedBitArray value)
        {
            if (IsEnabled() && 0 <= _ar.NumValue() && _ar.NumValue() < 16)
            {
                VideoMemory[_ar.NumValue()] = (byte)value.NumValue();
                UpdateForm();
            }
        }
        private ExtendedBitArray GetDr()
        {
            if (0 <= _ar.NumValue() && _ar.NumValue() < 16)
            {
                byte b = VideoMemory[_ar.NumValue()];
                return new ExtendedBitArray(b);
            }
            return new ExtendedBitArray();
        }
        public override void UpdateUI()
        {
            //UpdateForm();
            _form.ShowRegisters(_ar, _ar, _scr);
        }

        public byte[] GetVideoMemory()
        {
            return VideoMemory;
        }
    }
}
