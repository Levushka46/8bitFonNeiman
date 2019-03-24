using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.Common.MicroLibrary;
using _8bitVonNeiman.ExternalDevices.Timer2.View;

namespace _8bitVonNeiman.ExternalDevices.Timer2 {
    public class Timer2Controller : IDeviceInput, ITimer2FormOutput {

        private Timer2Form _form;
        private readonly IDeviceOutput _output;

        private int _baseAddress = 20;
        private byte _irq = 2;

        private ExtendedBitArray _tcntH = new ExtendedBitArray();
        private ExtendedBitArray _tcntL = new ExtendedBitArray();

        private ExtendedBitArray _tiorH = new ExtendedBitArray();
        private ExtendedBitArray _tiorL = new ExtendedBitArray();

        private ExtendedBitArray _tscrH = new ExtendedBitArray();
        private ExtendedBitArray _tscrL = new ExtendedBitArray();

        private delegate void UpdateFormDelegate();

        private UpdateFormDelegate _updateFormDelegate;

        private readonly MicroTimer _timer;

        public Timer2Controller(IDeviceOutput output) {
            _output = output;
            _updateFormDelegate = new UpdateFormDelegate(UpdateForm);
            _timer = new MicroTimer(1000);
            _timer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnTimerEvent);
        }

        public void OpenForm() {
            if (_form == null) {
                _form = new Timer2Form(this);
            }
            UpdateForm();
            _form.ShowDeviceParameters(_baseAddress, _irq);
            _form.Show();
        }

        public void ExitThread() {
            _timer.Abort();
            _timer.Enabled = false;
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState() {
            if (_form == null) {
                _form = new Timer2Form(this);
                _form.Show();
                UpdateForm();
            } else {
                _form.Close();
            }
        }

        private void UpdateForm() {
            _form.ShowRegisters(_tcntH, _tcntL, _tiorH, _tiorL, _tscrH, _tscrL);
        }

        public bool HasMemory(int address) {
            return _baseAddress <= address && address <= _baseAddress + 5;
        }

        public void SetMemory(ExtendedBitArray memory, int address) {
            switch (address - _baseAddress) {
                case 0:
                    _tcntL = memory;
                    break;
                case 1:
                    _tcntH = memory;
                    break;
                case 2:
                    _tiorL = memory;
                    break;
                case 3:
                    _tiorH = memory;
                    break;
                case 4:
                    _tscrL = memory;
                    break;
                case 5:
                    _tscrH = memory;
                    break;
            }
            ApplySettings();
        }

        public ExtendedBitArray GetMemory(int address) {
            switch (address - _baseAddress) {
                case 0:
                    return _tcntL;
                case 1:
                    return _tcntH;
                case 2:
                    return _tiorL;
                case 3:
                    return _tiorH;
                case 4:
                    return _tscrL;
                case 5:
                    return _tscrH;
            }
            return new ExtendedBitArray();
        }

        public void UpdateUI() {
            UpdateForm();
        }

        public void FormClosed() {
            _form = null;
            _timer.Abort();
            _timer.Enabled = false;

            _output.DeviceFormClosed(this);
        }

        public void ResetButtonClicked() {
            _tcntH = new ExtendedBitArray();
            _tcntL = new ExtendedBitArray();

            _tiorH = new ExtendedBitArray();
            _tiorL = new ExtendedBitArray();

            _tscrH = new ExtendedBitArray();
            _tscrL = new ExtendedBitArray();

            ApplySettings();

            _form.Invoke(_updateFormDelegate);
        }

        public void CaptureButtonClicked() {
            SetCapture(true);

            _form.Invoke(_updateFormDelegate);
        }

        private void MakeInterruption() {
            _output.MakeInterruption(_irq);
        }

        private bool IsEnabled() {
            return _tscrL[0];
        }

        private byte GetMode() {
            bool hMode = _tscrL[2];
            bool lMode = _tscrL[1];
            return (byte)((hMode ? 2 : 0) + (lMode ? 1 : 0));
        }

        private bool IsResetOnCmp() {
            return _tscrL[3];
        }

        private bool IsOverflowIntEnabled() {
            return _tscrL[4];
        }

        private bool IsComparisonIntEnabled() {
            return _tscrL[5];
        }

        private bool IsCaptureIntEnabled() {
            return _tscrL[6];
        }

        private bool IsTSCRLLoadAllowed() {
            return _tscrL[7];
        }

        private bool Capture() {
            return _tscrH[0];
        }

        private void SetCapture(bool capture) {
            _tscrH[0] = capture;

            byte mode = GetMode();
            if (mode == 1 && capture) {
                SetCaptureFlag(true);
            }
        }

        private bool IsOverflowFlag() {
            return _tscrH[1];
        }

        private void SetOverflowFlag(bool overflow) {
            _tscrH[1] = overflow;

            if (overflow) {
                byte mode = GetMode();
                if (mode == 3) { // автозагрузка
                    _tcntH = new ExtendedBitArray(_tiorH);
                    _tcntL = new ExtendedBitArray(_tiorL);
                }
            }

            if (overflow && IsOverflowIntEnabled()) {
                MakeInterruption();
            }
        }

        private bool IsComparisonFlag() {
            return _tscrH[2];
        }

        private void SetComparisonFlag(bool comparison) {
            _tscrH[2] = comparison;

            if (comparison && IsComparisonIntEnabled()) {
                MakeInterruption();
            }
        }

        private bool IsCaptureFlag() {
            return _tscrH[3];
        }

        private void SetCaptureFlag(bool capture) {
            _tscrH[3] = capture;

            SetCapture(false);

            if (capture) {
                byte mode = GetMode();
                if (mode == 1) { // режим захвата
                    _tiorH = new ExtendedBitArray(_tcntH);
                    _tiorL = new ExtendedBitArray(_tcntL);
                }
            }

            if (capture && IsCaptureIntEnabled()) {
                MakeInterruption();
            }
        }

        private byte GetDividerMode() {
            bool div2 = _tscrH[6];
            bool div1 = _tscrH[5];
            bool div0 = _tscrH[4];
            return (byte)((div2 ? 4 : 0) + (div1 ? 2 : 0) + (div0 ? 1 : 0));
        }

        private bool IsTSCRHLoadAllowed() {
            return _tscrH[7];
        }

        private void ApplySettings() {
            byte divider = GetDividerMode();
            if (divider == 0) {
                divider = 1;
            }
            _timer.Interval = 1000 * divider;
            _timer.Enabled = IsEnabled();

            byte mode = GetMode();
            if (mode == 1 && Capture()) { // режим захвата
                SetCaptureFlag(true);
            }
        }

        private void OnTimerEvent(object sender, MicroTimerEventArgs e) {
            if (_tcntL.Inc()) {
                if (_tcntH.Inc()) {
                    SetOverflowFlag(true);
                }
            }
            byte mode = GetMode();
            if (mode == 2) { // сравнение
                if (_tcntL.NumValue() == _tiorL.NumValue() && _tcntH.NumValue() == _tiorH.NumValue()) {
                    SetComparisonFlag(true);

                    if (IsResetOnCmp()) {
                        _tcntH = new ExtendedBitArray();
                        _tcntL = new ExtendedBitArray();
                    }
                }
            }
        }
    }
}
