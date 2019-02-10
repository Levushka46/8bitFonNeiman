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

namespace _8bitVonNeiman.ExternalDevices.Display.View {

    public partial class DisplayForm : Form {

        private readonly IDisplayFormOutput _output;

        public DisplayForm(IDisplayFormOutput output) {
            _output = output;

            InitializeComponent();
        }

        public void ShowRegisters(ExtendedBitArray dr, ExtendedBitArray cr, ExtendedBitArray ar) {
            drBinTextBox.Text = dr.ToBinString();
            crBinTextBox.Text = cr.ToBinString();
            arBinTextBox.Text = ar.ToBinString();
        }

        public void ClearScreen() {
            displayTextBox.Text = "                \r\n                \r\n                \r\n                \r\n                \r\n                \r\n                \r\n                ";
        }

        public char GetCharacter(int index) {
            return displayTextBox.Text[index];
        }

        public void SetCharacter(int index, char value) {
            StringBuilder text = new StringBuilder(displayTextBox.Text);
            text[index] = value;
            displayTextBox.Text = text.ToString();
        }

        private void resetButton_Click(object sender, EventArgs e) {
            _output.ResetButtonClicked();
        }

        private void DisplayForm_FormClosed(object sender, FormClosedEventArgs e) {
            _output.FormClosed();
        }
    }
}
