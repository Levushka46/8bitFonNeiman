using System;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View
{
    public partial class KeypadAndIndicationSettingForm : Form
    {
        public KeypadAndIndicationSettingForm()
        {
            InitializeComponent();
        }

        private int _sevenSegmentCount = 8;
        private int _pointPosition = 7;
        private int _keyPadCount = 4;
        private readonly KeypadAndIndicationForm _mainForm;

        public KeypadAndIndicationSettingForm(KeypadAndIndicationForm form)
        {
            InitializeComponent();
            _mainForm = form;
            GetChecked();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SetButton_Click(sender,e);
            this.Close();
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            if (Seg2RadioButton.Checked) _sevenSegmentCount = 2;
            if (Seg4RadioButton.Checked) _sevenSegmentCount = 4;
            if (Seg6RadioButton.Checked) _sevenSegmentCount = 6;
            if (Seg8RadioButton.Checked) _sevenSegmentCount = 8;

            _mainForm.SevenSegmentCountEdit(_sevenSegmentCount);

            if (Pos0RadioButton.Checked) _pointPosition = 0;
            if (Pos7RadioButton.Checked) _pointPosition = 7;

            _mainForm.PointPosition = _pointPosition;

            if (Key3RadioButton.Checked) _keyPadCount = 3;
            if (Key34RadioButton.Checked) _keyPadCount = 34;
            if (Key4RadioButton.Checked) _keyPadCount = 4;
            if (KeyNoneRadioButton.Checked) _keyPadCount = 0;

            _mainForm.KeyPadCountEdit(_keyPadCount);
        }

        private void GetChecked()
        {
            _sevenSegmentCount = _mainForm.SevenSegmentCount;
            _pointPosition = _mainForm.PointPosition;
            _keyPadCount = _mainForm.KeyPadCount;

            switch (_sevenSegmentCount)
            {
                case 2: Seg2RadioButton.Checked = true; break;
                case 4: Seg4RadioButton.Checked = true; break;
                case 6: Seg6RadioButton.Checked = true; break;
                case 8: Seg8RadioButton.Checked = true; break;
            }

            if (_pointPosition == 0) Pos0RadioButton.Checked = true;
            else Pos7RadioButton.Checked = true;

            switch (_keyPadCount)
            {
                case 3: Key3RadioButton.Checked = true; break;
                case 34: Key34RadioButton.Checked = true; break;
                case 4: Key4RadioButton.Checked = true; break;
            }
        }
    }
}
