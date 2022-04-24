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
    public class scController: IDeviceInput, ISerialControllerFormOutput
    {
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
        public scController(IDeviceOutput output, int baseAddress)
        {
            _output = output;
            _baseAddress = baseAddress * 0x10;   
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            
            switch (address - _baseAddress)
            {
                case 0:
                    ExtendedBitArray result = _dr;
                    readLCDDisplayREG();
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
        }

        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    _dr = memory;
                    WriteLCDDisplayFNA(_dr, _scr.NumValue());
                    break;
                case 1:
                    _scr[0] = memory[0];
                    break;    
            }
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
            if (tranzaction == 0)
            {
                _scr[6] = true;//Завершение приема
                _scr[5] = true;//Завершение передачи
            }
            else{
                _scr[6] = !tranzactionREAD;//Завершение приема
                _scr[5] = tranzactionREAD;//Завершение передачи
            }
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
    }
}
