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

namespace _8bitVonNeiman.ExternalDevices.Keyboard1.View {

    public partial class Keyboard1Form : Form {

        private readonly IKeyboard1FormOutput _output;

        public Keyboard1Form(IKeyboard1FormOutput output) {
            _output = output;

            InitializeComponent();
        }

        public void ShowRegisters(ExtendedBitArray dr, ExtendedBitArray cr, ExtendedBitArray sr) {
            drBinTextBox.Text = dr.ToBinString();
            crBinTextBox.Text = cr.ToBinString();
            srBinTextBox.Text = sr.ToBinString();
        }

        public void ShowDeviceParameters(int baseAddress, byte irq) {
            baseAddressLabel.Text = "0x" + Convert.ToString(baseAddress, 16);
            interruptionVectorLabel.Text = irq.ToString();
        }

        public char GetCharacter(int index) {
            if (index >= bufferTextBox.Text.Length) {
                return bufferTextBox.Text.LastOrDefault();
            }
            return bufferTextBox.Text.ElementAtOrDefault(index);
        }

        public int TextLength() {
            return bufferTextBox.Text.Length;
        }

        public void ClearBuffer() {
            bufferTextBox.Text = "";
        }

        private void readyButton_Click(object sender, EventArgs e) {
            _output.ReadyButtonClicked();
        }

        private void resetButton_Click(object sender, EventArgs e) {
            _output.ResetButtonClicked();
        }

        private void bufferTextBox_TextChanged(object sender, EventArgs e) {
            _output.CharacterEntered();
        }

        private void Keyboard1Form_FormClosed(object sender, FormClosedEventArgs e) {
            _output.FormClosed();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm("Klava");
            form.Show();
        }
    }
}
