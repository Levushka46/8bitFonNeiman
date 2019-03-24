using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.ExternalDevices.Display.View;

namespace _8bitVonNeiman.ExternalDevices.Display {
    public class DisplayController : IDeviceInput, IDisplayFormOutput {

        private DisplayForm _form;
        private readonly IDeviceOutput _output;

        private int _baseAddress = 10;

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private ExtendedBitArray _ar = new ExtendedBitArray();

        private readonly Encoding cp1251 = Encoding.GetEncoding("Windows-1251");

        private delegate void SetCharacterDelegate(int textBoxIndex, char character);

        private SetCharacterDelegate _updateFormDelegate;

        public DisplayController(IDeviceOutput output) {
            _output = output;
            _updateFormDelegate = new SetCharacterDelegate((textBoxIndex, character) => _form.SetCharacter(textBoxIndex, character));
        }

        public override void OpenForm() {
            if (_form == null) {
                _form = new DisplayForm(this);
            }
            UpdateForm();
            _form.ShowDeviceParameters(_baseAddress);
            _form.Show();
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState() {
            if (_form == null) {
                _form = new DisplayForm(this);
                _form.Show();
                UpdateForm();
            } else {
                _form.Close();
            }
        }

        private void UpdateForm() {
            _form.ShowRegisters(GetDr(), _cr, _ar);
        }

        public override bool HasMemory(int address) {
            return _baseAddress <= address && address <= _baseAddress + 2;
        }

        public override void SetMemory(ExtendedBitArray memory, int address) {
            switch (address - _baseAddress) {
                case 0:
                    SetDr(memory);
                    NextAddress();
                    break;
                case 1:
                    _cr = memory;
                    break;
                case 2:
                    _ar = memory;
                    break;
            }
        }

        public override ExtendedBitArray GetMemory(int address) {
            switch (address - _baseAddress) {
                case 0:
                    ExtendedBitArray value = GetDr();
                    NextAddress();
                    return value;
                case 1:
                    return _cr;
                case 2:
                    return _ar;
            }
            return new ExtendedBitArray();
        }

        public override void UpdateUI() {
            UpdateForm();
        }

        public void ResetButtonClicked() {
            _form.ClearScreen();

            _cr = new ExtendedBitArray();
            _ar = new ExtendedBitArray();

            UpdateForm();
        }

        public void FormClosed() {
            _form = null;

            _output.DeviceFormClosed(this);
        }

        private bool IsEnabled() {
            return _cr[0];
        }

        private bool IsAutoincrement() {
            return _cr[1];
        }

        private ExtendedBitArray GetDr() {
            if (0 <= _ar.NumValue() && _ar.NumValue() < 8 * 16 + 7) {
                int lineIndex = _ar.NumValue() / 16;
                int linePos = _ar.NumValue() % 16;

                int textBoxIndex = lineIndex * 18 + linePos;
                char character = _form.GetCharacter(textBoxIndex);

                byte[] bs = cp1251.GetBytes(new char[] { character });
                byte b = bs[0];

                return new ExtendedBitArray(b);
            }

            return new ExtendedBitArray();
        }

        private void NextAddress() {
            if (IsAutoincrement()) {
                _ar.Inc();
            }
        }

        private void SetDr(ExtendedBitArray value) {
            if (IsEnabled() && 0 <= _ar.NumValue() && _ar.NumValue() < 8 * 16 + 7) {
                int lineIndex = _ar.NumValue() / 16;
                int linePos = _ar.NumValue() % 16;

                int textBoxIndex = lineIndex * 18 + linePos;

                string s = cp1251.GetString(new byte[] { (byte)value.NumValue() });
                char character = s[0];

                _form.Invoke(_updateFormDelegate, textBoxIndex, character);
            }
        }
    }
}
