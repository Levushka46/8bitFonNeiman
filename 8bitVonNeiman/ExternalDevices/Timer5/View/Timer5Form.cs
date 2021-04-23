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

namespace _8bitVonNeiman.ExternalDevices.Timer5.View {
    public partial class Timer5Form : Form {

        private readonly ITimer5FormOutput _output;

        public Timer5Form(ITimer5FormOutput output) {
            _output = output;

            InitializeComponent();
        }

        public void ShowRegisters(ExtendedBitArray tcntH, ExtendedBitArray tcntL,
            ExtendedBitArray ocrH, ExtendedBitArray ocrL,
            ExtendedBitArray icrH, ExtendedBitArray icrL,
            ExtendedBitArray tscrH, ExtendedBitArray tscrL,
            bool outputPinValue) {

            tcntHTextBox.Text = tcntH.ToBinString();
            tcntLTextBox.Text = tcntL.ToBinString();
            ocrHTextBox.Text = ocrH.ToBinString();
            ocrLTextBox.Text = ocrL.ToBinString();
            icrHTextBox.Text = icrH.ToBinString();
            icrLTextBox.Text = icrL.ToBinString();
            tscrHTextBox.Text = tscrH.ToBinString();
            tscrLTextBox.Text = tscrL.ToBinString();

            //вывод значений во внешний порт
            outputPinTextBox.Text = outputPinValue ? "1" : "0";
        }

        public void ShowDeviceParameters(int baseAddress, byte irq) {
            baseAddressLabel.Text = "0x" + Convert.ToString(baseAddress, 16);
            interruptionVectorLabel.Text = irq.ToString();
        }

        private void Timer5Form_FormClosed(object sender, FormClosedEventArgs e) {
            _output.FormClosed();
        }

        private void resetButton_Click(object sender, EventArgs e) {
            _output.ResetButtonClicked();
        }

        private void captureButton_Click(object sender, EventArgs e) {
            _output.CaptureButtonClicked();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm("Timer_5");
            form.Show();
        }
    }
}
