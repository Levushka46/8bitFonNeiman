﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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

            SevenSegmentCountEdit(SevenSegmentCount);
            KeyPadCountEdit(KeyPadCount);
        }

        private List<DmitryBrant.CustomControls.SevenSegment> allSevenSegments;
        public List<DmitryBrant.CustomControls.SevenSegment> sevenSegments;
       
        public int SevenSegmentCount = 8;
        public int PointPosition = 7;
        public int KeyPadCount = 4;

        //sevenSegment1.Value = textBox1.Text;
        //sevenSegment2.CustomPattern = int.Parse(textBox2.Text);


        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeypadAndIndicationSettingForm newForm = new KeypadAndIndicationSettingForm(this);
            newForm.Show();
        }

        public void SevenSegmentCountEdit(int count)
        {
            SevenSegmentCount = count;
            allSevenSegments.ForEach(s => s.Visible = false);
            sevenSegments = allSevenSegments.GetRange(0, SevenSegmentCount);
            sevenSegments.ForEach(s => s.Visible = true);
        }

        public void KeyPadCountEdit(int count)
        {
            KeyPadCount = count;
            keyPadPanel.Visible = KeyPadCount != 0;

            switch (KeyPadCount)
            {
                case 3:
                    keyPadPanel.Width = 120;
                    keyPadPanel.Height = 120;
                    KeyA.Visible = false;
                    KeyB.Visible = false;
                    KeyC.Visible = false;
                    KeyD.Visible = false;
                    KeyAsterisk.Visible = false;
                    Key0.Visible = false;
                    KeyHash.Visible = false;
                    break;
                case 4:
                    keyPadPanel.Width = 155;
                    keyPadPanel.Height = 155;
                    KeyA.Visible = true;
                    KeyB.Visible = true;
                    KeyC.Visible = true;
                    KeyD.Visible = true;
                    KeyAsterisk.Visible = true;
                    Key0.Visible = true;
                    KeyHash.Visible = true;
                    break;
                case 34:
                    keyPadPanel.Width = 120;
                    keyPadPanel.Height = 155;
                    KeyA.Visible = false;
                    KeyB.Visible = false;
                    KeyC.Visible = false;
                    KeyD.Visible = false;
                    KeyAsterisk.Visible = true;
                    Key0.Visible = true;
                    KeyHash.Visible = true;
                    break;
            }
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
            videoMemBinTextBox.SelectAll();
            videoMemBinTextBox.SelectionAlignment = HorizontalAlignment.Center;

        }

        public void ShowDeviceParameters(int baseAddress, byte irq)
        {
            baseAddressLabel.Text = baseAddress.ToString();
            interruptionVectorLabel.Text = irq.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Key1_Click(object sender, EventArgs e)
        {
            _output.Key(1);
        }

        private void Key2_Click(object sender, EventArgs e)
        {
            _output.Key(2);
        }

        private void Key3_Click(object sender, EventArgs e)
        {
            _output.Key(3);
        }

        private void Key4_Click(object sender, EventArgs e)
        {
            _output.Key(4);
        }

        private void Key5_Click(object sender, EventArgs e)
        {
            _output.Key(5);
        }

        private void Key6_Click(object sender, EventArgs e)
        {
            _output.Key(6);
        }

        private void Key7_Click(object sender, EventArgs e)
        {
            _output.Key(7);
        }

        private void Key8_Click(object sender, EventArgs e)
        {
            _output.Key(8);
        }

        private void Key9_Click(object sender, EventArgs e)
        {
            _output.Key(9);
        }

        private void Key0_Click(object sender, EventArgs e)
        {
            _output.Key(0);
        }

        private void KeyA_Click(object sender, EventArgs e)
        {
            _output.Key(10);
        }

        private void KeyB_Click(object sender, EventArgs e)
        {
            _output.Key(11);
        }

        private void KeyC_Click(object sender, EventArgs e)
        {
            _output.Key(12);
        }

        private void KeyD_Click(object sender, EventArgs e)
        {
            _output.Key(13);
        }

        private void KeyAsterisk_Click(object sender, EventArgs e)
        {
            _output.Key(14);
        }

        private void KeyHash_Click(object sender, EventArgs e)
        {
            _output.Key(15);
        }
    }
}
