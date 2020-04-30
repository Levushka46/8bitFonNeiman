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

        private delegate void UpdateFormDelegate();

        private UpdateFormDelegate _updateFormDelegate;

        //private int _baseAddress = 40;
        //private byte _irq = 4;

        //private new const int ScrollingPoints = 20;//количество точек до скрола

        //private readonly MicroTimer _timer; //использовать его или нет? проверить когда смогу получать значения с таймера 5

        //IDeviceInput input = ExternalDevicesManager.ExternalDevicesController.devices;

        //public List<int> values = new List<int>();
        //Random rnd = new Random(DateTime.Now.Millisecond);
        //System.Windows.Forms.DataVisualization.Charting.Chart chart;

        public OscillographController(IDeviceOutput output)
        {
            _output = output;
            _updateFormDelegate = new UpdateFormDelegate(UpdateForm);
            //_timer = new MicroTimer(1000);
            //_timer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnTimerEvent);
            //_timer.Enabled = true;
        }
        public override void OpenForm()
        {
            if (_form == null)
            {
                _form = new OscillographForm(this);
            }
            //UpdateForm();
            //_form.ShowDeviceParameters(_baseAddress, _irq);//вывод вектора и адреса прерывания

            //нужно ли это здесь или оставить всё на форме???
            //_form.SetInitialSettings(_form.GetChart1, System.Drawing.Color.Blue, ScrollingPoints, _form.GetTrackBar1, _form.GetLabel1, 20); 
            //_form.SetInitialSettings(_form.GetChart2, System.Drawing.Color.Green, ScrollingPoints, _form.GetTrackBar2, _form.GetLabel2, 20);
            _form.Show();
        }
        public void FormClosed()
        {
            _form = null;
            //_timer.Abort();
            //_timer.Enabled = false;

            _output.DeviceFormClosed(this);
        }

        private void UpdateForm()
        {
            double nowMillis = DateTime.Now.ToUniversalTime().Subtract( //возможно тут что то другое нужно
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            //_form.Pin = (OutPin.outputPinValueTimer5) ? 1 : 0;
        }

        public override void UpdateUI() => UpdateForm();
        public override ExtendedBitArray GetMemory(int address) => throw new NotImplementedException();
        public override bool HasMemory(int address) => throw new NotImplementedException();
        public override void SetMemory(ExtendedBitArray memory, int address) => throw new NotImplementedException();


    }
}
