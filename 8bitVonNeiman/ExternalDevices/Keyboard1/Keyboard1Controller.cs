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

        private readonly Encoding cp1251 = Encoding.GetEncoding("Windows-1251");

        public Keyboard1Controller(IDeviceOutput output) {
            _output = output;
        }

        public void OpenForm() {
            if (_form == null) {
                _form = new Keyboard1Form(this);
            }
            UpdateForm();
            _form.Show();
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState() {
            if (_form == null) {
                _form = new Keyboard1Form(this);
                _form.Show();
                UpdateForm();
            } else {
                _form.Close();
            }
        }

        private void UpdateForm() {
            _form.ShowRegisters(_dr, _cr, _sr);
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
            UpdateForm();
        }

        public ExtendedBitArray GetMemory(int address) {
            switch (address - _baseAddress) {
                case 0:
                    SetReadyFlag(false);
                    UpdateForm();
                    return _dr;
                case 1:
                    return _cr;
                case 2:
                    return _sr;
            }
            return new ExtendedBitArray();
        }

        public void CharacterEntered(char character) {
            if (!IsEnabled()) return;

            byte[] bs = cp1251.GetBytes(new char[] { character });
            byte b = bs[0];

            if (!ReadyOnButtonClick()) {
                _dr = new ExtendedBitArray(b);
                SetReadyFlag(true);

                if (IsInterruptionEnabled()) {
                    MakeInterruption();
                }
            }

            UpdateForm();
        }

        public void FormClosed() {
            _form = null;

            _output.DeviceFormClosed(this);
        }

        public void ReadyButtonClicked() {
            if (!IsEnabled()) return;

            char character = _form.GetCharacter();
            byte[] bs = cp1251.GetBytes(new char[] { character });
            byte b = bs[0];

            _dr = new ExtendedBitArray(b);
            SetReadyFlag(true);

            if (IsInterruptionEnabled()) {
                MakeInterruption();
            }

            UpdateForm();
        }

        public void ResetButtonClicked() {
            _form.ClearBuffer();

            _dr = new ExtendedBitArray();
            _cr = new ExtendedBitArray();
            _sr = new ExtendedBitArray();

            UpdateForm();
        }

        private bool IsEnabled() {
            return _cr[0];
        }

        private bool IsInterruptionEnabled() {
            return _cr[1];
        }

        private bool ReadyOnButtonClick() {
            return _cr[2];
        }

        private void SetReadyFlag(bool ready) {
            _sr[1] = ready;
        }

        private void SetErrorFlag(bool error) {
            _sr[0] = error;
        }

        private void MakeInterruption() {
            // todo INT
        }
    }
}
