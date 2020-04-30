using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
	}
}
