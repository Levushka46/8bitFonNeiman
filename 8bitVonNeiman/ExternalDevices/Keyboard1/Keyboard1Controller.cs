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
        private byte _irq = 1;

        private ExtendedBitArray _dr { get { return new ExtendedBitArray(GetCharacter()); } }

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private ExtendedBitArray _sr = new ExtendedBitArray();

        private readonly Encoding cp1251 = Encoding.GetEncoding("Windows-1251");

        private int _readIndex = 0;

        private delegate void UpdateFormDelegate();

        private UpdateFormDelegate _updateFormDelegate;

        public Keyboard1Controller(IDeviceOutput output) {
            _output = output;
            _updateFormDelegate = new UpdateFormDelegate(UpdateForm);
        }

        public override void OpenForm() {
            if (_form == null) {
                _form = new Keyboard1Form(this);
            }
            UpdateForm();
            _form.ShowDeviceParameters(_baseAddress, _irq);
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

        public override bool HasMemory(int address) {
            return _baseAddress <= address && address <= _baseAddress + 2;
        }

        public override void SetMemory(ExtendedBitArray memory, int address) {
            switch (address - _baseAddress) {
                case 0:
                    break;
                case 1:
                    _cr = memory;
                    break;
                case 2:
                    _sr = memory;
                    break;
            }
        }

        public override ExtendedBitArray GetMemory(int address) {
            switch (address - _baseAddress) {
                case 0:
                    ExtendedBitArray value = _dr;
                    NextCharacter();
                    SetReadyFlag(0 < _form.TextLength() && _readIndex < _form.TextLength());
                    return value;
                case 1:
                    return _cr;
                case 2:
                    return _sr;
            }
            return new ExtendedBitArray();
        }

        public override void UpdateUI() {
            UpdateForm();
        }

        public void CharacterEntered() {
            if (!IsEnabled()) return;

            if (!ReadyOnButtonClick()) {
                SetReadyFlag(true);

                if (IsInterruptionEnabled()) {
                    MakeInterruption();
                }
            }

            _form.Invoke(_updateFormDelegate);
        }

        public void FormClosed() {
            _form = null;

            _output.DeviceFormClosed(this);
        }

        private byte GetCharacter() {
            char character = _form.GetCharacter(_readIndex);
            byte[] bs = cp1251.GetBytes(new char[] { character });
            byte b = bs[0];
            return b;
        }

        private void NextCharacter() {
            if (_readIndex < _form.TextLength()) {
                _readIndex++;
            }
        }

        public void ReadyButtonClicked() {
            if (!IsEnabled()) return;

            SetReadyFlag(true);

            if (IsInterruptionEnabled()) {
                MakeInterruption();
            }

            _form.Invoke(_updateFormDelegate);
        }

        public void ResetButtonClicked() {
            _form.ClearBuffer();

            _readIndex = 0;
            _cr = new ExtendedBitArray();
            _sr = new ExtendedBitArray();

            _form.Invoke(_updateFormDelegate);
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
            _output.MakeInterruption(_irq);
        }
    }
}
