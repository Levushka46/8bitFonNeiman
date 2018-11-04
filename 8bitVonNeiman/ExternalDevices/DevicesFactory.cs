using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevices.Keyboard1;

namespace _8bitVonNeiman.ExternalDevices {
    public class DevicesFactory {

        private readonly IDeviceOutput _output;

        public DevicesFactory(IDeviceOutput output) {
            _output = output;
        }

        public IDeviceInput GetKeyboard1() {
            return new Keyboard1Controller(_output);
        }
    }
}
