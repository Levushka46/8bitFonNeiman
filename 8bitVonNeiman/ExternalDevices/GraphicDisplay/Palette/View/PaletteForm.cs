using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette.View
{
    public partial class PaletteForm : Form
    {

        public const int RowCount = 16;
        public const int ColumnCount = 4;


        Bitmap Pixels = new Bitmap(47, 35);

        private readonly IPaletteFormOutput _output;

        public PaletteForm(IPaletteFormOutput output)
        {
            InitializeComponent();
            _output = output;


            PictureBox t = new PictureBox();
            t.Location = new Point(30,80) ;
            t.Size = new Size(50, 50);
            t.BackColor = Color.FromArgb(0,0,0,0);
  

            PaletteDataGridView.RowCount = RowCount;
            PaletteDataGridView.ColumnCount = ColumnCount;
            PaletteDataGridView.RowHeadersWidth = 60;

            for (int i = 0; i < RowCount; i++)
            {
                PaletteDataGridView.Rows[i].HeaderCell.Value = i.ToString("X");
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                
                PaletteDataGridView.Columns[i].Width = 25;
        
            }

            PaletteDataGridView.Columns[0].HeaderCell.Value = "A";
            PaletteDataGridView.Columns[1].HeaderCell.Value = "R";
            PaletteDataGridView.Columns[2].HeaderCell.Value = "G";
            PaletteDataGridView.Columns[3].HeaderCell.Value = "B";

        }



        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public string GetPalette(int memory)
        {
  
            return (string)PaletteDataGridView[(memory % 64) % ColumnCount, (memory % 64) / ColumnCount].Value;
        }


       public void SetPalette(int row, int collumn, string memory)
       {
      
           PaletteDataGridView[collumn, row].Value = memory;
       }


       public void SetPalette(int row, Color color)
       {
           PaletteDataGridView[0, row].Value = color.A.ToString("X2");
           PaletteDataGridView[1, row].Value = color.R.ToString("X2");
           PaletteDataGridView[2, row].Value = color.G.ToString("X2");
           PaletteDataGridView[3, row].Value = color.B.ToString("X2");

       }

        public void ShowColor(int ColorIndex, Color color)
        {

            Pixels = new Bitmap(47,35);
          
            
            for (int i = 0; i < Pixels.Width;i++)
                for (int j = 0; j < Pixels.Height;j++)
                    Pixels.SetPixel(i, j, color);

            switch (ColorIndex)
               {
                case 0:
                    Color1PictureBox.Image = Pixels;
                    break;
                case 1:
                    Color2PictureBox.Image = Pixels;
                    break;
                case 2:
                    Color3PictureBox.Image = Pixels;
                    break;
                case 3:
                    Color4PictureBox.Image = Pixels;
                    break;
                case 4:
                    Color5PictureBox.Image = Pixels;
                    break;
                case 5:
                    Color6PictureBox.Image = Pixels;
                    break;
                case 6:
                    Color7PictureBox.Image = Pixels;
                    break;
                case 7:
                    Color8PictureBox.Image = Pixels;
                    break;
                case 8:
                    Color9PictureBox.Image = Pixels;
                    break;
                case 9:
                    Color10PictureBox.Image = Pixels;
                    break;
                case 10:
                    ColorAPictureBox.Image = Pixels;
                    break;
                case 11:
                    ColorBPictureBox.Image = Pixels;
                    break;
                case 12:
                    ColorCPictureBox.Image = Pixels;
                    break;
                case 13:
                    ColorDPictureBox.Image = Pixels;
                    break;
                case 14:
                    ColorEPictureBox.Image = Pixels;
                    break;
                case 15:
                    ColorFPictureBox.Image = Pixels;
                    break;
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _output.SavePaletteClicked();
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            _output.SaveAsPaletteClicked();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            _output.LoadPaletteClicked();
        }
        
        private void PaletteDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            _output.PaletteChange(e.RowIndex, e.ColumnIndex,  PaletteDataGridView[0, e.RowIndex].Value, PaletteDataGridView[1, e.RowIndex].Value, PaletteDataGridView[2, e.RowIndex].Value, PaletteDataGridView[3, e.RowIndex].Value);
        }

        private void PaletteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.PaletteFormClosed();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _output.ResetPaletteButtonClicked();
        }
    }
}
