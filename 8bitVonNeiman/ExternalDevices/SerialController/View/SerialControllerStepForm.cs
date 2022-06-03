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
    public partial class SerialControllerStepForm : Form
    {
        private readonly ISerialControllerStepFormOutput _output;
        public SerialControllerStepForm(ISerialControllerStepFormOutput output)
        {
            InitializeComponent();

            _output = output;
        }

        public void ShowSerialRegisters(
            ExtendedBitArray drk, ExtendedBitArray scr, ExtendedBitArray nk, ExtendedBitArray cnt,
            ExtendedBitArray drv, bool f, ExtendedBitArray nv, ExtendedBitArray a, ExtendedBitArray cntk,
            bool txd, bool txe, bool rxrdy,
            bool rxd, bool txrdy, bool rxe
        ) {
            drkBinTextBox.Text = drk.ToBinString();
            scrkBinTextBox.Text = scr.ToBinString();
            SetTextBoxValueOfLength(nkBinTextBox, nk.ToBinString(), 5);
            SetTextBoxValueOfLength(cntkBinTextBox, cnt.ToBinString(), 3);

            drvBinTextBox.Text = drv.ToBinString();
            SetBoolTextBoxValue(fvBinTextBox, f);
            SetTextBoxValueOfLength(nvBinTextBox, nv.ToBinString(), 5);
            SetTextBoxValueOfLength(avBinTextBox, a.ToBinString(), 2);
            SetTextBoxValueOfLength(cnt2kBinTextBox, cntk.ToBinString(), 3);

            if (txe)
                TxDBinTextBox.Text="z";
            else
                SetBoolTextBoxValue(TxDBinTextBox, txd);
            SetBoolTextBoxValue(RxRDYBinTextBox, rxrdy);
            SetBoolTextBoxValue(TxEBinTextBox, txe);

            if (rxe)
                RxDBinTextBox.Text = "z";
            else
                SetBoolTextBoxValue(RxDBinTextBox, rxd);
            SetBoolTextBoxValue(TxRDYBinTextBox, txrdy);
            SetBoolTextBoxValue(RxEBinTextBox, rxe);
        }
        private static void SetTextBoxValueOfLength(TextBox textBox, string value, int length) {
            textBox.Text = value.Substring(value.Length - length);
        }
        private static void SetBoolTextBoxValue(TextBox textBox, bool value) {
            string textValue;
            if (value) {
                textValue = "1";
            } else {
                textValue = "0";
            }
            textBox.Text = textValue;
        }


        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void SerialControllerStepForm_Load(object sender, EventArgs e)
        {

        }

        private void clkButton_MouseDown(object sender, MouseEventArgs e) {
            _output.CLKChanged(true);
        }

        private void clkButton_MouseUp(object sender, MouseEventArgs e) {
            _output.CLKChanged(false);
        }

        private void SerialControllerStepForm_FormClosed(object sender, FormClosedEventArgs e) {
            _output.FormClosed();
        }

        private void DrkBinTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
