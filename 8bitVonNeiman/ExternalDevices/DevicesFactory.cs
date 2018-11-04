using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevices.Keyboard1;

namespace _8bitVonNeiman.ExternalDevices {
    public class DevicesFactory {

        public IKeyboard1Input GetKeyboard1() {
            return new Keyboard1Controller();
        }
    }
}
