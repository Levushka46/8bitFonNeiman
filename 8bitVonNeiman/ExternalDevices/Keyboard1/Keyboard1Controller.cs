using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.ExternalDevices.Keyboard1.View;

namespace _8bitVonNeiman.ExternalDevices.Keyboard1 {
    public class Keyboard1Controller : IKeyboard1Input, IKeyboard1FormOutput {

        private Keyboard1Form _form;

        private int _baseAddress;

        private ExtendedBitArray _dr = new ExtendedBitArray();

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private ExtendedBitArray _sr = new ExtendedBitArray();

        public Keyboard1Controller() { }

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
                    return _sr;
                case 2:
                    return _cr;
            }
            return new ExtendedBitArray();
        }

        public void CharacterEntered(char character) {
            // todo implement
        }

        public void FormClosed() {
            _form = null;
        }

        public void ReadyButtonClicked() {
            // todo implement
        }

        public void ResetButtonClicked() {
            // todo implement
        }
    }
}
