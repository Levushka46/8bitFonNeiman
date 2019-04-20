using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.Common.MicroLibrary;
using _8bitVonNeiman.ExternalDevices.Timer5.View;

namespace _8bitVonNeiman.ExternalDevices.Timer5 {
    public class Timer5Controller : IDeviceInput, ITimer5FormOutput {
        private static readonly double UPDATE_PERIOD_MILLIS = 100.0;

        private Timer5Form _form;
        private readonly IDeviceOutput _output;

        private int _baseAddress = 20;
        private byte _irq = 2;

        private ExtendedBitArray _tcntH = new ExtendedBitArray();
        private ExtendedBitArray _tcntL = new ExtendedBitArray();

        private ExtendedBitArray _ocrH = new ExtendedBitArray();
        private ExtendedBitArray _ocrL = new ExtendedBitArray();

        private ExtendedBitArray _icrH = new ExtendedBitArray();
        private ExtendedBitArray _icrL = new ExtendedBitArray();

        private ExtendedBitArray _tscrH = new ExtendedBitArray();
        private ExtendedBitArray _tscrL = new ExtendedBitArray();

        private ExtendedBitArray _hBuffer = new ExtendedBitArray();

        private bool outputPinValue;

        private bool dec;
        private ExtendedBitArray[] upperLimit;

        private delegate void UpdateFormDelegate();

        private UpdateFormDelegate _updateFormDelegate;

        private readonly MicroTimer _timer;
        private byte _internalCounter;

        private double _lastUpdateMillis;

        public Timer5Controller(IDeviceOutput output) {
            _output = output;
            _updateFormDelegate = new UpdateFormDelegate(UpdateForm);
            _timer = new MicroTimer(1000);
            _timer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnTimerEvent);
        }

        public override void OpenForm() {
            if (_form == null) {
                _form = new Timer5Form(this);
            }
            UpdateForm();
            _form.ShowDeviceParameters(_baseAddress, _irq);
            _form.Show();
        }

        public override void ExitThread() {
            _timer.Abort();
            _timer.Enabled = false;
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState() {
            if (_form == null) {
                _form = new Timer5Form(this);
                _form.Show();
                UpdateForm();
            } else {
                _form.Close();
            }
        }

        private void UpdateForm() {
            double nowMillis = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;

            _form.ShowRegisters(_tcntH, _tcntL, _ocrH, _ocrL, _icrH, _icrL, _tscrH, _tscrL, outputPinValue);
            _lastUpdateMillis = nowMillis;
        }

        public override bool HasMemory(int address) {
            return _baseAddress <= address && address <= _baseAddress + 7;
        }

        public override void SetMemory(ExtendedBitArray memory, int address) {
            int localAddress = address - _baseAddress;

            switch (localAddress) {
                case 0:
                    _tcntL = memory;
                    _tcntH = new ExtendedBitArray(_hBuffer);
                    break;
                case 2:
                    _ocrL = memory;
                    _ocrH = new ExtendedBitArray(_hBuffer);
                    break;
                case 4:
                    _icrL = memory;
                    _icrH = new ExtendedBitArray(_hBuffer);
                    break;
                case 6:
                    _tscrL = memory;
                    break;
                case 7:
                    var value = memory.NumValue() & 0x1F | _tscrH.NumValue() & 0xE0;
                    _tscrH = new ExtendedBitArray(value);
                    break;
                case 1:
                case 3:
                case 5:
                    _hBuffer = new ExtendedBitArray(memory);
                    break;
            }
            ApplySettings();
        }

        public override ExtendedBitArray GetMemory(int address) {
            switch (address - _baseAddress) {
                case 0:
                    _hBuffer = new ExtendedBitArray(_tcntH);
                    return _tcntL;
                case 2:
                    _hBuffer = new ExtendedBitArray(_ocrH);
                    return _ocrL;
                case 4:
                    _hBuffer = new ExtendedBitArray(_icrH);
                    return _icrL;
                case 6:
                    _hBuffer = new ExtendedBitArray(_tscrH);
                    return _tscrL;
                case 1:
                case 3:
                case 5:
                case 7:
                    return _hBuffer;
            }
            return new ExtendedBitArray();
        }

        public override void SetMemoryBit(bool value, int address, int bitIndex) {
            switch (address - _baseAddress) {
                case 0:
                    _tcntL[bitIndex] = value;
                    break;
                case 1:
                    _tcntH[bitIndex] = value;
                    break;
                case 2:
                    _ocrL[bitIndex] = value;
                    break;
                case 3:
                    _ocrH[bitIndex] = value;
                    break;
                case 4:
                    _icrL[bitIndex] = value;
                    break;
                case 5:
                    _icrH[bitIndex] = value;
                    break;
                case 6:
                    _tscrL[bitIndex] = value;
                    break;
                case 7:
                    _tscrH[bitIndex] = value;
                    break;
            }
            ApplySettings();
        }

        public override bool GetMemoryBit(int address, int bitIndex) {
            switch (address - _baseAddress) {
                case 0:
                    return _tcntL[bitIndex];
                case 1:
                    return _tcntH[bitIndex];
                case 2:
                    return _ocrL[bitIndex];
                case 3:
                    return _ocrH[bitIndex];
                case 4:
                    return _icrL[bitIndex];
                case 5:
                    return _icrH[bitIndex];
                case 6:
                    return _tscrL[bitIndex];
                case 7:
                    return _tscrH[bitIndex];
            }
            return false;
        }

        public override void UpdateUI() {
            UpdateForm();
        }

        public void FormClosed() {
            _form = null;
            _timer.Abort();
            _timer.Enabled = false;

            _output.DeviceFormClosed(this);
        }

        public void ResetButtonClicked() {
            _timer.Abort();

            _tcntH = new ExtendedBitArray();
            _tcntL = new ExtendedBitArray();

            _ocrH = new ExtendedBitArray();
            _ocrL = new ExtendedBitArray();

            _icrH = new ExtendedBitArray();
            _icrL = new ExtendedBitArray();

            _tscrH = new ExtendedBitArray();
            _tscrL = new ExtendedBitArray();

            _hBuffer = new ExtendedBitArray();

            _internalCounter = 0;

            ApplySettings();

            _form.Invoke(_updateFormDelegate);
        }

        public void CaptureButtonClicked() {
            if (IsExtCaptureAllowed()) {
                SetCaptureFlag(true);
            }

            _form.Invoke(_updateFormDelegate);
        }

        private void MakeInterruption() {
            _output.MakeInterruption(_irq);
        }

        private bool IsEnabled() {
            return GetDividerMode() != 0;
        }

        private byte GetMode() {
            bool hMode = _tscrL[1];
            bool lMode = _tscrL[0];
            return (byte)((hMode ? 2 : 0) + (lMode ? 1 : 0));
        }

        private byte GetDividerMode() {
            bool div1 = _tscrL[3];
            bool div0 = _tscrL[2];
            return (byte)((div1 ? 2 : 0) + (div0 ? 1 : 0));
        }

        private byte GetDivider() {
            byte dividerMode = GetDividerMode();
            switch (dividerMode) {
                case 1:
                    return 1;
                case 2:
                    return 16;
                case 3:
                    return 64;
            }
            return dividerMode;
        }

        private byte GetOutputMode() {
            bool mode1 = _tscrL[5];
            bool mode0 = _tscrL[4];
            return (byte)((mode1 ? 2 : 0) + (mode0 ? 1 : 0));
        }

        private bool IsExtCaptureAllowed() {
            return _tscrL[6];
        }

        private bool Capture() {
            return _tscrL[7];
        }

        private void SetCapture(bool capture) {
            _tscrL[7] = capture;

            if (capture) {
                SetCaptureFlag(true);
            }
        }

        private byte GetUpperLimitMode() {
            bool limit1 = _tscrH[1];
            bool limit0 = _tscrH[0];
            return (byte)((limit1 ? 2 : 0) + (limit0 ? 1 : 0));
        }

        private ExtendedBitArray[] GetUpperLimit() {
            byte upperLimitMode = GetUpperLimitMode();
            switch (upperLimitMode) {
                case 1:
                    return new ExtendedBitArray[] { /* 0 */ new ExtendedBitArray(0xFF), /* 1 */ new ExtendedBitArray() };
                case 2:
                    return new ExtendedBitArray[] { /* 0 */ new ExtendedBitArray(0xFF), /* 1 */ new ExtendedBitArray(0x0F) };
                case 3:
                    return new ExtendedBitArray[] { /* 0 */ new ExtendedBitArray(0xFF), /* 1 */ new ExtendedBitArray(0xFF) };
            }
            return new ExtendedBitArray[] { /* 0 */ _icrL, /* 1 */ _icrH };
        }

        private bool IsOverflowIntEnabled() {
            return _tscrH[2];
        }

        private bool IsComparisonIntEnabled() {
            return _tscrH[3];
        }

        private bool IsCaptureIntEnabled() {
            return _tscrH[4];
        }

        private bool IsOverflowFlag() {
            return _tscrH[5];
        }

        private void SetOverflowFlag(bool overflow) {
            _tscrH[5] = overflow;

            if (overflow && IsOverflowIntEnabled()) {
                MakeInterruption();
            }
        }

        private bool IsComparisonFlag() {
            return _tscrH[6];
        }

        private void SetComparisonFlag(bool comparison) {
            _tscrH[6] = comparison;

            if (comparison && IsComparisonIntEnabled()) {
                MakeInterruption();
            }
        }

        private bool IsCaptureFlag() {
            return _tscrH[7];
        }

        private void SetCaptureFlag(bool capture) {
            _tscrH[7] = capture;

            SetCapture(false);

            if (capture) {
                _icrH = new ExtendedBitArray(_tcntH);
                _icrL = new ExtendedBitArray(_tcntL);
            }

            if (capture && IsCaptureIntEnabled()) {
                MakeInterruption();
            }
        }

        private void ApplySettings() {
            byte divider = GetDivider();
            if (divider == 0) {
                _timer.Enabled = false;
            } else {
                _timer.Enabled = true;
            }
            upperLimit = GetUpperLimit();

            if (Capture()) { // захват
                SetCaptureFlag(true);
            }
        }

        private void OnTimerEvent(object sender, MicroTimerEventArgs e) {
            if (++_internalCounter < GetDivider()) return;

            _internalCounter = 0;

            bool equalUpperLimit = _tcntL.NumValue() == upperLimit[0].NumValue() && _tcntH.NumValue() == upperLimit[1].NumValue();
            bool equalLowerLimit = _tcntL.NumValue() == 0 && _tcntH.NumValue() == 0;

            // Инкремент/декремент
            if (dec) {
                if (_tcntL.Dec()) {
                    if (_tcntH.Dec()) {
                        // 0000 -> FFFF underflow
                        Console.WriteLine("Shouldn't normally happen! 0000.Dec()");
                    }
                }
            } else {
                if (equalUpperLimit) {
                    _tcntL.And(new ExtendedBitArray());
                    _tcntH.And(new ExtendedBitArray());

                    SetOverflowFlag(true);
                } else if (_tcntL.Inc()) {
                    if (_tcntH.Inc()) {
                        // FFFF -> 0000 overflow
                        Console.WriteLine("Shouldn't normally happen! FFFF.Inc()");
                        SetOverflowFlag(true);
                    }
                }
            }

            equalUpperLimit = _tcntL.NumValue() == upperLimit[0].NumValue() && _tcntH.NumValue() == upperLimit[1].NumValue();
            equalLowerLimit = _tcntL.NumValue() == 0 && _tcntH.NumValue() == 0;
            bool equalTcntOcr = _tcntL.NumValue() == _ocrL.NumValue() && _tcntH.NumValue() == _ocrH.NumValue();

            byte mode = GetMode();
            switch (mode) {
                case 1: // сброс при совпадении
                    if (equalTcntOcr) {
                        SetComparisonFlag(true);

                        _tcntH = new ExtendedBitArray();
                        _tcntL = new ExtendedBitArray();
                    }
                    break;
                case 2: // быстрый ШИМ
                    break;
                case 3: // ШИМ с фазовой коррекцией
                    // проверка совпадения с верхним пределом
                    if (equalUpperLimit) {
                        dec = true;
                    } else if (equalLowerLimit) {
                        dec = false;
                    }
                    break;
            }

            byte outputMode = GetOutputMode();
            switch (outputMode) {
                case 0:
                    outputPinValue = false;
                    break;
                case 1: // инверсия при совпадении TCNT == OCR
                    if (equalTcntOcr) {
                        outputPinValue = !outputPinValue;
                    }
                    break;
                case 2:
                    if (mode < 2) { // Без ШИМ
                        if (equalTcntOcr) { // сброс при совпадении
                            outputPinValue = false;
                        }
                    }
                    if (mode == 2) { // Быстрый ШИМ
                        if (equalTcntOcr) { // сброс при совпадении
                            outputPinValue = false;
                        } else if (equalUpperLimit) { // установка на вершине счета
                            outputPinValue = true;
                        }
                    }
                    if (mode == 3) { // ШИМ с ФК
                        if (equalTcntOcr) {
                            if (dec) {
                                outputPinValue = true; // установка при совпадении во время обратного счета
                            } else {
                                outputPinValue = false; // сброс при совпадении во время прямого счета
                            }
                        }
                    }
                    break;
                case 3:
                    if (mode < 2) { // Без ШИМ
                        if (equalTcntOcr) { // установка при совпадении
                            outputPinValue = true;
                        }
                    }
                    if (mode == 2) { // Быстрый ШИМ
                        if (equalTcntOcr) { // установка при совпадении
                            outputPinValue = true;
                        } else if (equalUpperLimit) { // сброс на вершине счета
                            outputPinValue = false;
                        }
                    }
                    if (mode == 3) { // ШИМ с ФК
                        if (equalTcntOcr) {
                            if (dec) {
                                outputPinValue = false; // сброс при совпадении во время обратного счета
                            } else {
                                outputPinValue = true; // установка при совпадении во время прямого счета
                            }
                        }
                    }
                    break;
            }

            double nowMillis = DateTime.Now.ToUniversalTime().Subtract(
                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    ).TotalMilliseconds;
            if (nowMillis - _lastUpdateMillis > UPDATE_PERIOD_MILLIS) {
                _form.Invoke(_updateFormDelegate);
                _lastUpdateMillis = nowMillis;
            }
        }
    }
}
