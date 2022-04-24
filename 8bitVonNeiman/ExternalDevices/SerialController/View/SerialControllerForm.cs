using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices.SerialController.View
{
    public partial class SerialControllerForm : Form
    {
        private readonly ISerialControllerFormOutput _output;

        public SerialControllerForm(ISerialControllerFormOutput output)
        {
            _output = output;
            InitializeComponent();
        }

        internal void ShowDeviceParameters(int baseAddress)
        {
            baseAddressLabel.Text = "0x" + Convert.ToString(baseAddress, 16); //baseAddress.ToString();
        }

        internal void ShowRegisters(ExtendedBitArray dr, ExtendedBitArray scr)
        {
            drBinTextBox.Text = dr.ToBinString();
            scrBinTextBox.Text = scr.ToBinString();
        }

        private void SerialControllerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.FormClosed();
        }
    }
}
