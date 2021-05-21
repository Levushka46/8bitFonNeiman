using _8bitVonNeiman.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.View
{
    public partial class GraphicDisplayForm : Form
    {


        public PictureBox GetScreen()
        {
            return Screen;
        }

        public void SetScreen(Bitmap bitmap)
        {
            //  lock (new object())
            // {
            Bitmap bitmap1 = new Bitmap(bitmap);
            Screen.Image = bitmap1;
            // }
            System.Threading.Thread.Sleep(2);
        }





        private readonly IGraphicDisplayFormOutput _output;

        public GraphicDisplayForm(IGraphicDisplayFormOutput output)
        {



            InitializeComponent();
            _output = output;




        }



        public void ClearBuffer()
        {

        }


        public void ShowRegisters(ExtendedBitArray _arL, ExtendedBitArray _arH, ExtendedBitArray _dr, ExtendedBitArray _cr)
        {
            arHBinTextBox.Text = _arH.ToBinString();
            arLBinTextBox.Text = _arL.ToBinString();
            drBinTextBox.Text = _dr.ToBinString();
            crBinTextBox.Text = _cr.ToBinString();
        }

        public void ShowDeviceParameters(int baseAddress)
        {
            baseAddressLabel.Text = "0x" + Convert.ToString(baseAddress, 16);
            interruptionVectorLabel.Text = "-";
        }




        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void PaletteButton_Click(object sender, EventArgs e)
        {
            _output.PaletteButtonClicked();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            _output.DrawButtonClicked();
        }


        private void GraphicDisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.FormClosed();
        }

        private void VideomemoryButton_Click(object sender, EventArgs e)
        {
            _output.VideomemoryButtonClicked();
        }
    }
}
