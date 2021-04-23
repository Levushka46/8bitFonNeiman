using _8bitVonNeiman.Common;
using _8bitVonNeiman.ExternalDevices.Oscillograph.View;
using System;
using System.Collections.Generic;
using System.Linq;
using _8bitVonNeiman.ExternalDevices.Timer5;

namespace _8bitVonNeiman.ExternalDevices.Oscillograph
{
    public class OscillographController : IDeviceInput, IOscillographFormOutput
    {
        private OscillographForm _form;
        private readonly IDeviceOutput _output;
        private delegate void UpdateFormDelegate();
        private UpdateFormDelegate _updateFormDelegate;

        private int _baseAddress = 0;

        public List<IDeviceInput> ConnectedDevices { get; } = new List<IDeviceInput>();

        public OscillographController(IDeviceOutput output)
        {
            _output = output;
            _updateFormDelegate = new UpdateFormDelegate(UpdateForm);
            ConnectedDevices.AddRange(_output.Devices.Where(x => x.GetType() == typeof(Timer5Controller)));
        }
        public override void OpenForm()
        {
            if (_form == null)
            {
                _form = new OscillographForm(this);
            }
            _form.Show();
        }
        public void FormClosed()
        {
            _form = null;
            _output.DeviceFormClosed(this);
        }

        private void UpdateForm()
        {
            double nowMillis = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
        }

        public override void UpdateUI() => UpdateForm();
        public override ExtendedBitArray GetMemory(int address) => throw new NotImplementedException();
        public override bool HasMemory(int address) { return _baseAddress <= address && address <= _baseAddress; }//=> throw new NotImplementedException();
        public override void SetMemory(ExtendedBitArray memory, int address) => throw new NotImplementedException();


    }
}
