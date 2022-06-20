using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.ExternalDevices.SerialController.View;
using _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay.View;
using _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay;

namespace _8bitVonNeiman.ExternalDevices.SerialController
{
    public class scController : IDeviceInput, ISerialControllerFormOutput {
        private SerialControllerForm _form;
        private LCDDisplayForm _form2;
        private LCDDisplayController controllerlcd;
        private readonly IDeviceOutput _output;
        private int _baseAddress = 60;

        private ExtendedBitArray _scr = new ExtendedBitArray(0x60);
        private ExtendedBitArray _dr = new ExtendedBitArray();
        private int tranzaction = 0;  //сколько байт в транзакции
        private bool tranzactionREAD = false;  //Что сейчас?
        private int tranzactionAddress = 0; //чтото

        private SerialExchange exchange;

        ExtendedBitArray dr {
            get { return _dr; }
            set { _dr = value; }
        }
        ExtendedBitArray n {
            get { return new ExtendedBitArray(tranzaction); }
            set { tranzaction = value.NumValue(); }
        }
        bool transactionByte;
        ExtendedBitArray cnt = new ExtendedBitArray();
        bool fr {
            get { return _scr[6]; }
            set {  _scr[6] = value; }
        }
        bool ft {
            get { return _scr[5]; }
            set { _scr[5] = value; }
        }
        bool f {
            get { return tranzactionREAD; }
            set { tranzactionREAD = value; }
        }

        public scController(IDeviceOutput output, int baseAddress)
        {
            _output = output;
            _baseAddress = baseAddress * 0x10;

            exchange = new SerialExchange(this, new SerialInterfaceModule());
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            
            switch (address - _baseAddress)
            {
                case 0:
                    ExtendedBitArray result = _dr;
                    if (IsSerialStepMode()) {
                        exchange.ByteRead();
                    } else {
                        readLCDDisplayREG();
                    }
                    return result;
                case 1:
                    return _scr;
            }
            return new ExtendedBitArray();
        }

        public override bool HasMemory(int address)
        {
            return _baseAddress <= address && address <= _baseAddress + 1;
        }

        public override void OpenForm()
        {
            if (_form == null)
            {
                _form = new SerialControllerForm(this);
            }
            _form.ShowDeviceParameters(_baseAddress);
            exchange.ShowSerialRegisters();
            _form.Show();
            UpdateForm();
            OpenLCDDisplayForm();
        }
        public void OpenLCDDisplayForm()
        {
            controllerlcd = new LCDDisplayController(_output, 0);
            controllerlcd.OpenForm();
        }
        private void UpdateForm()
        {
            _form.ShowRegisters(_dr, _scr);
            if (IsSerialStepMode()) {
                exchange.ShowSerialRegisters();
            }
            if (controllerlcd != null) {
                controllerlcd.UpdateUI();
            }
        }

        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    _dr = memory;
                    if (IsSerialStepMode()) {
                        exchange.NextByte();
                    } else {
                        WriteLCDDisplayFNA(_dr, _scr.NumValue());
                    }
                    break;
                case 1:
                    _scr[0] = memory[0];
                    break;    
            }
        }
        private bool IsSerialStepMode() {
            if (_form != null) {
                return _form.IsStepMode();
            }
            return false;
        }
        public void readLCDDisplayREG()
        {
            if (!IsEnabled())
            return;
            if (tranzaction>0)
            {
                _dr = controllerlcd.GetMemory(tranzactionAddress);
                tranzaction--;
                UpdateTranzactionFlag();
            }
        }
        public void WriteLCDDisplayFNA(ExtendedBitArray dr, int adress)
        {
            if (!IsEnabled())
            return;
                if (tranzaction == 0)
                {
                    bool read = dr[7];
                    int buffer = dr.NumValue() & 0x7F;
                    int n = buffer >> 0x02;
                    int a = buffer & 0x03;
                    tranzaction = n;
                    tranzactionREAD = read;
                    _scr[7] = read;// transactia SCR
                    tranzactionAddress = a;
                    if (read)
                    {
                        _dr = controllerlcd.GetMemory(tranzactionAddress);
                    }
                    UpdateTranzactionFlag();
                 }
                else
                {
                    if (!tranzactionREAD)
                    {
                        controllerlcd.SetMemory(dr, tranzactionAddress);
                        tranzaction--;
                        UpdateTranzactionFlag();
                    }
                }
        }
        public void WriteLCDDisplaySCR(ExtendedBitArray dr, int adress)
        {
            controllerlcd.SetMemory(dr,adress);
        }
        private void UpdateTranzactionFlag()
        {
            _scr[6] = true;//Завершение приема
            _scr[5] = true;//Завершение передачи
        }
        public void FormClosed()
        {
            _form = null;
            _output.DeviceFormClosed(this);
            controllerlcd.CloseForm();
        }
        public override void UpdateUI()
        {
            UpdateForm();
            controllerlcd.UpdateUI();
        }
        private bool IsEnabled()
        {
            return _scr[0];
        }

        public void CLKChanged(bool clk) {
            exchange.Step();
            exchange.ShowSerialRegisters();
            UpdateUI();
        }

        private class SerialExchange {
            private scController controller;
            private SerialInterfaceModule serial;

            private bool receive;
            private int algStep;

            public bool txd, txe=true, rxrdy = true;  // set by controller
            public bool rxd, txrdy = true, rxe=true;  // set by serial

            public SerialControllerStepForm form;

            public SerialExchange(scController controller, SerialInterfaceModule serial) {
                this.controller = controller;
                this.serial = serial;
            }

            public void ShowSerialRegisters() {
                controller._form.ShowSerialRegisters(
                    controller.dr, controller._scr, controller.n, controller.cnt,
                    serial.dr, serial.f, serial.n, serial.a, serial.cntk,
                    txd, txe, rxrdy,
                    rxd, txrdy, rxe
                );
            }
            public void Step() {
                switch (algStep) {
                    case 5:  // CLK up
                        TransferCLKChanged(true);
                        break;
                    case 6:  // CLK down
                        TransferCLKChanged(false);
                        break;
                    case 103:  // CLK up
                        ReceiveCLKChanged(true);
                        break;
                    case 104:  // CLK down
                        ReceiveCLKChanged(false);
                        break;
                    case 105:  // CLK up
                        FinishByteReceive();
                        break;

                    case 108:  // CLK down
                        FinishByteTransfer();
                        break;
                }
            }

            public void NextByte() {
                controller.ft = false;
                if (controller.n.NumValue() == 0) {
                    int n = (controller.dr.NumValue() & 0x7F) >> 0x02;
                    controller.n = new ExtendedBitArray(n);
                    controller.f = controller.dr[7];
                    controller.transactionByte = true;
                }
                controller.cnt = new ExtendedBitArray();

                receive = false;
                txrdy = false;
                TxRDY();
                txrdy = true;
                TxEChanged();
                algStep = 5;
            }
            public void TxRDY() {
                txe = false;
                ++algStep;
            }
            public void TxEChanged() {
                if (txe) {
                    // wait for CLK down
                    txrdy = false;
                    if (serial.n.NumValue() == 0) {
                        int n = (serial.dr.NumValue() & 0x7F) >> 0x02;
                        serial.n = new ExtendedBitArray(n);
                        int a = serial.dr.NumValue() & 0x03;
                        serial.a = new ExtendedBitArray(a);
                        serial.f = serial.dr[7];
                    } else {
                        serial.n.Dec();

                        if (controller.f) {
                            // TODO receive
                        } else {
                            controller.controllerlcd.SetMemory(serial.dr, serial.a.NumValue());
                        }
                    }
                    serial.cntk = new ExtendedBitArray();
                }
            }
            public void TransferCLKChanged(bool clk) {
                if (clk) {
                    txd = controller.dr[0];

                    int dr = serial.dr.NumValue();
                    dr = (dr >> 1) | ((dr & 0x01) << 7);  // cyclic right shift
                    serial.dr = new ExtendedBitArray(dr);
                    // TxE up - exit loop

                    ++algStep;
                } else {
                    int dr = controller.dr.NumValue();
                    dr = (dr >> 1) | ((dr & 0x01) << 7);  // cyclic right shift
                    controller.dr = new ExtendedBitArray(dr);
                    controller.cnt.Inc();

                    serial.dr[7] = txd;
                    // wait for CLK up

                    if (controller.cnt.NumValue() == 8) {
                        FinishByteTransfer();
                        if (algStep==8) {
                            TxEChanged();
                            algStep = 0;
                        }else {
                            NotRxRDY();
                            RxEChanged();
                        }
                    } else {
                        algStep = 5;
                    }
                }
            }
            public void FinishByteTransfer() {
                txe = true;
                if (!controller.transactionByte) {
                    ExtendedBitArray n = controller.n;
                    n.Dec();
                    controller.n = n;
                }
                controller.transactionByte = false;
                controller.ft = true;

                if (controller.f) {
                    rxrdy = false;
                    algStep = 102;
                } else {
                    algStep = 8;
                }
            }

            public void NotRxRDY() {
                rxe = false;
            }
            public void RxEChanged() {
                if (!rxe) {
                    rxrdy = true;
                    if (serial.n.NumValue() == 0) {
                        int n = (serial.dr.NumValue() & 0x7F) >> 0x02;
                        serial.n = new ExtendedBitArray(n);
                        int a = serial.dr.NumValue() & 0x03;
                        serial.a = new ExtendedBitArray(a);
                        serial.f = serial.dr[7];

                        serial.cntk = new ExtendedBitArray();
                    } else {
                        serial.n.Dec();
                    }
                    if (controller.f) {
                        serial.dr = controller.controllerlcd.GetMemory(serial.a.NumValue());
                        rxd = serial.dr[0];
                        serial.cntk.Inc();
                    }
                }
                algStep = 103;
            }
            public void ReceiveCLKChanged(bool clk) {
                if (clk) {
                    controller.dr[7] = rxd;

                    int dr = serial.dr.NumValue();
                    dr = (dr >> 1) | ((dr & 0x01) << 7);  // cyclic right shift
                    serial.dr = new ExtendedBitArray(dr);
                    // TxE up - exit loop

                    ++algStep;
                } else {
                    rxd = serial.dr[0];
                    serial.cntk.Inc();
                    int dr = controller.dr.NumValue();
                    dr = (dr >> 1) | ((dr & 0x01) << 7);  // cyclic right shift
                    controller.dr = new ExtendedBitArray(dr);
                    // wait for CLK up

                    if (serial.cntk.NumValue() == 8) {
                        algStep = 105;
                    } else {
                        algStep = 103;
                    }
                }
            }
            public void FinishByteReceive() {
                rxe = true;

                controller.dr[7] = rxd;
                controller.fr = true;
                serial.cntk = new ExtendedBitArray();
                ExtendedBitArray n = controller.n;
                n.Dec();
                controller.n = n;
                if (serial.n.NumValue() > 0) {
                    serial.n.Dec();
                } else {
                    int dr = serial.dr.NumValue();
                    dr = (dr >> 1) | ((dr & 0x01) << 7);  // cyclic right shift
                    serial.dr = new ExtendedBitArray(dr);
                }

                algStep = 106;
            }

            public void ByteRead() {
                algStep = 107;
                controller.fr = false;

                if (controller.n.NumValue() == 0) {
                    algStep = 0;
                } else {
                    rxrdy = false;
                    algStep = 102;
                }
            }
        }
    }
}
