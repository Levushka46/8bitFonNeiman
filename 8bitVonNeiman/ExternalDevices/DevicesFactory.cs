using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevices.Keyboard1;
using _8bitVonNeiman.ExternalDevices.Display;
using _8bitVonNeiman.ExternalDevices.Timer2;
using _8bitVonNeiman.ExternalDevices.Timer5;
using _8bitVonNeiman.ExternalDevices.Oscillograph;
using _8bitVonNeiman.ExternalDevices.KeypadAndIndication;

namespace _8bitVonNeiman.ExternalDevices {
    public class DevicesFactory {

        private readonly IDeviceOutput _output;

        public DevicesFactory(IDeviceOutput output) {
            _output = output;
        }

        public IDeviceInput GetKeyboard1() {
            return new Keyboard1Controller(_output);
        }

        public IDeviceInput GetDisplay() {
            return new DisplayController(_output);
        }

        public IDeviceInput GetTimer2() {
            return new Timer2Controller(_output);
        }

        public IDeviceInput GetTimer5() {
            return new Timer5Controller(_output);
        }

        public IDeviceInput GetOscillograph()
        {
            return new OscillographController(_output);
        }

        public IDeviceInput GetKeypadAndIndication()
        {
            return new KeypadAndIndication.KeypadAndIndicationController(_output);
        }
    }
}
