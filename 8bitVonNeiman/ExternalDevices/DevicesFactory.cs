using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevices.Keyboard1;
using _8bitVonNeiman.ExternalDevices.Display;
using _8bitVonNeiman.ExternalDevices.LCDDisplay;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay;
using _8bitVonNeiman.ExternalDevices.Timer2;
using _8bitVonNeiman.ExternalDevices.Timer5;
using _8bitVonNeiman.ExternalDevices.Oscillograph;
using _8bitVonNeiman.ExternalDevices.KeypadAndIndication;
using _8bitVonNeiman.ExternalDevices.SerialController;

namespace _8bitVonNeiman.ExternalDevices {
    public class DevicesFactory {

        private readonly IDeviceOutput _output;

        public DevicesFactory(IDeviceOutput output) {
            _output = output;
        }

        public IDeviceInput GetKeyboard1(int baseAddress, int irq) {
            return new Keyboard1Controller(_output, baseAddress, irq);
        }

        public IDeviceInput GetDisplay(int baseAddress) {
            return new DisplayController(_output, baseAddress);
        }

        public IDeviceInput GetTimer2(int baseAddress, int irq) {
            return new Timer2Controller(_output, baseAddress, irq);
        }

        public IDeviceInput GetTimer5(int baseAddress, int irq) {
            return new Timer5Controller(_output, baseAddress, irq);
        }

        public IDeviceInput GetOscillograph()
        {
            return new OscillographController(_output);
        }

        public IDeviceInput GetKeypadAndIndication(int baseAddress, int irq)
        {
            return new KeypadAndIndicationController(_output, baseAddress, irq);
        }

        public IDeviceInput GetGraphicDisplay(int baseAddress)
        {
            return new GraphicDisplayController(_output, baseAddress);
        }

        public IDeviceInput GetLCDDisplay(int baseAddress)
        {
            return new LCDDisplayController(_output, baseAddress);
        }

        internal IDeviceInput GetSerialController(int baseAddress)
        {
            return new scController(_output, baseAddress);
        }
    }
}
