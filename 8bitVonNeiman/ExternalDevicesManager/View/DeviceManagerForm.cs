using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        private class Components
        {
            public readonly Button AddButton;
            public readonly TextBox BaseAddress;
            public readonly Label Zero;
            public readonly TextBox Irq;

            public Components(Button button, TextBox baseAddr, TextBox irq, Label zero)
            {
                AddButton = button;
                BaseAddress = baseAddr;
                Zero = zero;
                Irq = irq;
            }
        }

        private void ConnectingExternalDevices()
        {
			const string path = @"ExternalDevices\";
            int coord = 30;

            var externalDevices = new Dictionary<string, Components>
            {
                { "Display.bin", new Components(addDisplayButton, baseAddrDisplay, irqDisplay, label10)},
                { "GraphicDisplay.bin", new Components(addGraphicDisplayButton, baseAddrGraphicDisplay, irqGraphicDisplay, label11)},
                { "Keyboard1.bin", new Components(addDeviceButton, baseAddrDevice, irqDevice, label12)},
                { "KeypadAndIndication.bin", new Components(addKeypadAndIndicationButton, baseAddrKeypadAndIndication, irqKeypadAndIndication, label13)},
                { "Oscillograph.bin", new Components(addOscillographButton, baseAddrOscillograph, irqOscillograph, label14)},
                { "Timer2.bin", new Components(addTimer2Button, baseAddrTimer2, irqTimer2, label15)},
                { "Timer5.bin", new Components(addTimer5Button, baseAddrTimer5, irqTimer5, label16)}
            };

            foreach (var ed in externalDevices)
            {
                if (File.Exists(path + ed.Key))
                {
                    ed.Value.AddButton.Location = new Point(10,coord);
                    ed.Value.BaseAddress.Location = new Point(185, coord);
                    ed.Value.Zero.Location = new Point(209, coord+3);
                    ed.Value.Irq.Location = new Point(260, coord);
                    coord += 30;
                }
                else
                {
                    ed.Value.AddButton.Visible = false;
                    ed.Value.BaseAddress.Visible = false;
                    ed.Value.Zero.Visible = false;
                    ed.Value.Irq.Visible = false;
                }
            }
        }
        
        public void ShowAvailableDevices() { }

		private void addDeviceButton_Click(object sender, EventArgs e) {
			_output.AddExternalDevice(Convert.ToInt32(baseAddrDevice.Text, 16), Convert.ToInt32(irqDevice.Text));
		}

		private void DeviceManagerForm_FormClosed(object sender, FormClosedEventArgs e) {
			_output.FormClosed();
		}

        private void addDisplayButton_Click(object sender, EventArgs e) {
            _output.AddDisplay(Convert.ToInt32(baseAddrDisplay.Text,16));
        }

        private void addTimer2Button_Click(object sender, EventArgs e) {
            _output.AddTimer2(Convert.ToInt32(baseAddrTimer2.Text, 16), Convert.ToInt32(irqTimer2.Text));
        }

        private void addTimer5Button_Click(object sender, EventArgs e) {
            _output.AddTimer5(Convert.ToInt32(baseAddrTimer5.Text, 16), Convert.ToInt32(irqTimer5.Text));
        }

		private void addOscillographButton_Click(object sender, EventArgs e)
		{
			_output.AddOscillograph();
		}
        private void addKeypadAndIndicationButton_Click(object sender, EventArgs e)
        {
            _output.AddKeypadAndIndication(Convert.ToInt32(baseAddrKeypadAndIndication.Text, 16), Convert.ToInt32(irqKeypadAndIndication.Text));
		}

        private void addGraphicDisplayButton_Click(object sender, EventArgs e)
        {
            _output.AddGraphicDisplay(Convert.ToInt32(baseAddrGraphicDisplay.Text, 16));
        }

        private void IsValid(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 56) && e.KeyChar != 8) 
                e.Handled = true;
        }

        //открытый метод для проведения тестирования
        public void IsValidTest(object sender, KeyPressEventArgs e)
        {
            IsValid(sender, e);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddLCDDisplayButton_Click(object sender, EventArgs e)
        {
          _output.AddLCDDisplay(Convert.ToInt32(baseAddrLCDDisplay.Text, 16));
        }
    }
}
