using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevicesManager.View {
	public partial class DeviceManagerForm : Form {
		private readonly IDeviceManagerFormOutput _output;

		public DeviceManagerForm(IDeviceManagerFormOutput output) {
			_output = output;

			InitializeComponent();
            ConnectingExternalDevices();
		}
        
        public void ConnectingExternalDevices()
        {
			string path = @"ExternalDevices\";
            int coord = 10;

            Dictionary<string, Button> externalDevices = new Dictionary<string, Button>
            {
                { "Display.bin", addDisplayButton},
                { "Keyboard1.bin", addDeviceButton},
                { "KeypadAndIndication.bin", addKeypadAndIndicationButton},
                { "Oscillograph.bin", addOscillographButton},
                { "Timer2.bin", addTimer2Button},
                { "Timer5.bin", addTimer5Button}
            };

            foreach (var ed in externalDevices)
            {
                if (File.Exists(path + ed.Key))
                {
                    ed.Value.Location = new Point(85,coord);
                    coord += 30;
                }
                else
                {
                    ed.Value.Visible = false;
                }
            }

        }
        
        public void ShowAvailableDevices() { }

		private void addDeviceButton_Click(object sender, EventArgs e) {
			_output.AddExternalDevice();
		}

		private void DeviceManagerForm_FormClosed(object sender, FormClosedEventArgs e) {
			_output.FormClosed();
		}

        private void addDisplayButton_Click(object sender, EventArgs e) {
            _output.AddDisplay();
        }

        private void addTimer2Button_Click(object sender, EventArgs e) {
            _output.AddTimer2();
        }

        private void addTimer5Button_Click(object sender, EventArgs e) {
            _output.AddTimer5();
        }

		private void addOscillographButton_Click(object sender, EventArgs e)
		{
			_output.AddOscillograph();
		}

        private void addKeypadAndIndicationButton_Click(object sender, EventArgs e)
        {
            _output.AddKeypadAndIndication();
		}
    }
}
