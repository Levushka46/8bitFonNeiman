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
    public partial class SerialControllerForm : Form, ISerialControllerStepFormOutput
    {
        private readonly ISerialControllerFormOutput _output;
        private SerialControllerStepForm stepForm;
        public SerialControllerForm(ISerialControllerFormOutput output)
        {
            _output = output;
            InitializeComponent();

            stepForm = new SerialControllerStepForm(this);
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
        public bool IsStepMode() {
            if (stepForm != null) {
                return radioButton2.Checked;
            }
            return false;
        }
        public void ShowSerialRegisters(
            ExtendedBitArray drk, ExtendedBitArray scr, ExtendedBitArray nk, ExtendedBitArray cnt,
            ExtendedBitArray drv, bool f, ExtendedBitArray nv, ExtendedBitArray a, ExtendedBitArray cntk,
            bool txd, bool txe, bool rxrdy,
            bool rxd, bool txrdy, bool rxe
        ) {
            stepForm.ShowSerialRegisters(
                drk, scr, nk, cnt,
                drv, f, nv, a, cntk,
                txd, txe, rxrdy,
                rxd, txrdy, rxe
            );
        }
        public void OpenStepForm() {
            if (stepForm == null) {
                stepForm = new SerialControllerStepForm(this);
            }
            stepForm.Show();
            _output.UpdateUI();
        }
        public void CloseStepForm() {
            if (stepForm != null) {
                stepForm.Close();
                stepForm = null;
            }
        }

        private void SerialControllerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseStepForm();
            _output.FormClosed();
        }

        private void SerialControllerForm_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) {
                OpenStepForm();
            } else {
                CloseStepForm();
            }
        }

        void ISerialControllerStepFormOutput.FormClosed() {
            stepForm = null;
            radioButton2.Checked = false;
            radioButton1.Checked = true;
        }

        public void CLKChanged(bool clk) {
            _output.CLKChanged(clk);
        }
    }
}
