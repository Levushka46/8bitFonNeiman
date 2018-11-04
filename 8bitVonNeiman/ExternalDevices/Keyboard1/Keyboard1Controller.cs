using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.ExternalDevices.Keyboard1.View;

namespace _8bitVonNeiman.ExternalDevices.Keyboard1 {
    public class Keyboard1Controller : IDeviceInput, IKeyboard1FormOutput {

        private Keyboard1Form _form;
        private readonly IDeviceOutput _output;

        private int _baseAddress;

        private ExtendedBitArray _dr = new ExtendedBitArray();

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private ExtendedBitArray _sr = new ExtendedBitArray();

        public Keyboard1Controller(IDeviceOutput output) {
            _output = output;
        }

        public void OpenForm() {
            if (_form == null) {
                _form = new Keyboard1Form(this);
            }
            _form.ShowRegisters(_dr, _cr, _sr);
            _form.Show();
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState() {
            if (_form == null) {
                _form = new Keyboard1Form(this);
                _form.Show();
                _form.ShowRegisters(_dr, _cr, _sr);
            } else {
                _form.Close();
            }
        }

        public bool HasMemory(int address) {
            return _baseAddress <= address && address <= _baseAddress + 2;
        }

        public void SetMemory(ExtendedBitArray memory, int address) {
            switch (address - _baseAddress) {
                case 0:
                    _dr = memory;
                    break;
                case 1:
                    _cr = memory;
                    break;
                case 2:
                    _sr = memory;
                    break;
            }
            _form.ShowRegisters(_dr, _cr, _sr);
        }

        public ExtendedBitArray GetMemory(int address) {
            switch (address - _baseAddress) {
                case 0:
                    return _dr;
                case 1:
                    return _cr;
                case 2:
                    return _sr;
            }
            return new ExtendedBitArray();
        }

        public void CharacterEntered(char character) {
            // todo implement
        }

        public void FormClosed() {
            _form = null;

            _output.DeviceFormClosed(this);
        }

        public void ReadyButtonClicked() {
            // todo implement
        }

        public void ResetButtonClicked() {
            // todo implement
        }
    }
}
