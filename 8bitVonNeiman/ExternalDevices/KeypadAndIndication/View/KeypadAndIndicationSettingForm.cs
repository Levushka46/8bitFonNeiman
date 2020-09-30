using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View
{
    public partial class KeypadAndIndicationSettingForm : Form
    {
        public KeypadAndIndicationSettingForm()
        {
            InitializeComponent();
        }

        private int SevenSegmentCount = 4;
        private KeypadAndIndicationForm _mainForm;

        public KeypadAndIndicationSettingForm(KeypadAndIndicationForm form)
        {
            InitializeComponent();
            _mainForm = form;
            radioButton2.Checked = true;
            //form.SevenSegmentCount = SevenSegmentCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) SevenSegmentCount = 2;
            if (radioButton2.Checked) SevenSegmentCount = 4;
            if (radioButton3.Checked) SevenSegmentCount = 6;
            if (radioButton4.Checked) SevenSegmentCount = 8;

            _mainForm.SevenSegmentCount = SevenSegmentCount;
            _mainForm.SevenSegmentCountEdit();
            //todo: закрытие формы
        }
    }
}
