using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8bitVonNeiman.Common;


namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View
{
    public partial class KeypadAndIndicationForm : Form
    {
        private readonly ISevenSegmentFormOutput _output;
        public KeypadAndIndicationForm(ISevenSegmentFormOutput output)
        {
            _output = output;
            InitializeComponent();

            allSevenSegments = new List<DmitryBrant.CustomControls.SevenSegment>
            {
                sevenSegment1,
                sevenSegment2,
                sevenSegment3,
                sevenSegment4,
                sevenSegment5,
                sevenSegment6,
                sevenSegment7,
                sevenSegment8
            };
            allSevenSegments.ForEach(s => s.ItalicFactor = -0.1f);

            SevenSegmentCountEdit();
        }

        private List<DmitryBrant.CustomControls.SevenSegment> allSevenSegments;
        public List<DmitryBrant.CustomControls.SevenSegment> sevenSegments;
        public int SevenSegmentCount = 4;
        //sevenSegment1.Value = textBox1.Text;
        //sevenSegment2.CustomPattern = int.Parse(textBox2.Text);

        private void button1_Click(object sender, EventArgs e)
        {
            

            //foreach (var segment in list4)
            //{
            //    segment.Value = "A";
            //    //Thread.Sleep(1000);
            //}

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //sevenSegmentArray1.Value = textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sevenSegment1.CustomPattern = (int)numericUpDown1.Value;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeypadAndIndicationSettingForm newForm = new KeypadAndIndicationSettingForm(this);
            newForm.Show();
        }

        public void SevenSegmentCountEdit()
        {
            allSevenSegments.ForEach(s => s.Visible = false);
            sevenSegments = allSevenSegments.GetRange(0, SevenSegmentCount);
            sevenSegments.ForEach(s => s.Visible = true);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _output.ResetButtonClicked();
        }

        public void ClearScreen()
        {
        }

        public void SetCharacter(int index, char value)
        {
            //StringBuilder text = new StringBuilder(displayTextBox.Text);
            //text[index] = value;
            //displayTextBox.Text = text.ToString();
        }

        public void ShowRegisters(ExtendedBitArray addr, ExtendedBitArray sym, ExtendedBitArray cr, ExtendedBitArray sr, ExtendedBitArray [] videoMem)
        {
            addrBinTextBox.Text = addr.ToBinString();
            symBinTextBox.Text = sym.ToBinString();
            crBinTextBox.Text = cr.ToBinString();
            srBinTextBox.Text = sr.ToBinString();
            StringBuilder strVideoMem = new StringBuilder();
            for (var line = 0; line < videoMem.Length; line++)
            {
                strVideoMem.Append(videoMem[line].ToBinString() + "\r");
                //videoMemBinTextBox.Lines[line] = videoMem[line].ToBinString(); //разобраться с выводом
                //videoMemBinTextBox.Lines
            }

            videoMemBinTextBox.Text = strVideoMem.ToString();

        }

        public void ShowDeviceParameters(int baseAddress, byte irq)
        {
            baseAddressLabel.Text = baseAddress.ToString();
            interruptionVectorLabel.Text = irq.ToString();
        }
    }
}
