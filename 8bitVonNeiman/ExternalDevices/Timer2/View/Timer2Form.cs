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

namespace _8bitVonNeiman.ExternalDevices.Timer2.View {
    public partial class Timer2Form : Form {

        private readonly ITimer2FormOutput _output;

        public Timer2Form(ITimer2FormOutput output) {
            _output = output;

            InitializeComponent();
        }

        public void ShowRegisters(ExtendedBitArray tcntH, ExtendedBitArray tcntL,
            ExtendedBitArray tiorH, ExtendedBitArray tiorL,
            ExtendedBitArray tscrH, ExtendedBitArray tscrL) {

            tcntHTextBox.Text = tcntH.ToBinString();
            tcntLTextBox.Text = tcntL.ToBinString();
            tiorHTextBox.Text = tiorH.ToBinString();
            tiorLTextBox.Text = tiorL.ToBinString();
            tscrHTextBox.Text = tscrH.ToBinString();
            tscrLTextBox.Text = tscrL.ToBinString();
        }

        public void ShowDeviceParameters(int baseAddress, byte irq) {
            baseAddressLabel.Text = "0x" + Convert.ToString(baseAddress, 16);
            interruptionVectorLabel.Text = irq.ToString();
        }

        private void Timer2Form_FormClosed(object sender, FormClosedEventArgs e) {
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
            HelpForm form = new HelpForm("Timer_2");
            form.Show();
        }
    }
}
