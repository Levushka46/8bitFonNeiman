using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.Common.MicroLibrary;
using _8bitVonNeiman.ExternalDevices.Oscillograph.View;

namespace _8bitVonNeiman.ExternalDevices.Oscillograph
{
    class OscillographController : IDeviceInput, IOscillographFormOutput
    {
        private OscillographForm _form;
        private readonly IDeviceOutput _output;

        private int _baseAddress = 40;
        private byte _irq = 4;

        private new const int ScrollingPoints = 20;//количество точек до скрола
        
        private readonly MicroTimer _timer; //использовать его или нет? проверить когда смогу получать значения с таймера 5

        public OscillographController(IDeviceOutput output)
        {
            _output = output;
        }
        public void FormClosed()
        {
            _form = null;
            //_timer.Abort();
            //_timer.Enabled = false;

            _output.DeviceFormClosed(this);
        }

        //тут только внутренняя логика устройства!!!!
        public override ExtendedBitArray GetMemory(int address)
        {
            throw new NotImplementedException();
        }

        public override bool HasMemory(int address)
        {
            throw new NotImplementedException();
        }

        public override void OpenForm()
        {
            if (_form == null)
            {
                _form = new OscillographForm(this);
            }
            //UpdateForm();
            //_form.ShowDeviceParameters(_baseAddress, _irq);//вывод вектора и адреса прерывания
            _form.SetInitialSettings(_form.GetChart1, System.Drawing.Color.Blue, ScrollingPoints, _form.GetTrackBar1, _form.GetLabel1, 20);
            _form.SetInitialSettings(_form.GetChart2, System.Drawing.Color.Green, ScrollingPoints, _form.GetTrackBar2, _form.GetLabel2, 20);
            _form.Show();
        }

        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUI()
        {
            throw new NotImplementedException();
        }
    }
}
