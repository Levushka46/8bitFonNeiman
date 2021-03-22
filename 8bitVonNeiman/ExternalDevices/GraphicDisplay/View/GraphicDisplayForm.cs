using _8bitVonNeiman.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.View
{
    public partial class GraphicDisplayForm : Form
    {
         public const int RowCount = 256;
        public const int ColumnCount = 16;

        public PictureBox GetScreen() => Screen;

        public void SetScreen(Bitmap bitmap)
        {
            Screen.Image = bitmap;
            System.Threading.Thread.Sleep(5);
        }

        private readonly IGraphicDisplayFormOutput _output;
      
        public GraphicDisplayForm(IGraphicDisplayFormOutput output)
        {
            InitializeComponent();
            _output = output;

            GraphicMemoryDataGridView.RowCount = RowCount;
            GraphicMemoryDataGridView.ColumnCount = ColumnCount;
            GraphicMemoryDataGridView.RowHeadersWidth = 60;
            for (int i = 0; i < RowCount; i++)
            {
                GraphicMemoryDataGridView.Rows[i].HeaderCell.Value = (i << 4).ToString("X");
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                GraphicMemoryDataGridView.Columns[i].HeaderCell.Value = i.ToString("X");
                GraphicMemoryDataGridView.Columns[i].Width = 25;
            }
        }

        public int TextLength()
        {
            return 0;// bufferTextBox.Text.Length;
        }

        public void ClearBuffer()
        {
           // bufferTextBox.Text = "";
        }

        public void ShowRegisters(ExtendedBitArray _arL, ExtendedBitArray _arH, ExtendedBitArray  _dr, ExtendedBitArray _cr)
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

        public void SetMemory(int row, int collumn, string memory)
        {
            GraphicMemoryDataGridView[collumn, row].Value = memory;
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void ScrollToSegment(int segment)
        {
            if (0 <= segment && segment <= GraphicMemoryDataGridView.RowCount / 16)
            {
                GraphicMemoryDataGridView.FirstDisplayedScrollingRowIndex = segment * 16;
            }
        }

        public void ScrollToEndOfSegment(int segment)
        {
            if (0 <= segment && segment <= GraphicMemoryDataGridView.RowCount / 16 - 1)
            {
                GraphicMemoryDataGridView.FirstDisplayedScrollingRowIndex = (segment + 1) * 16 - GraphicMemoryDataGridView.DisplayedRowCount(false) - 1;
            }
        }
        
        public string GetMemory(int memory)
        {
            return (string)GraphicMemoryDataGridView[(memory % 4096) % ColumnCount, (memory % 4096) / ColumnCount].Value;
        }

        public char GetCharacter(int index)
        {
            return '9';
           /* if (index >= bufferTextBox.Text.Length)
            {
                return bufferTextBox.Text.LastOrDefault();
            }
            return bufferTextBox.Text.ElementAtOrDefault(index);*/
        }

        private void GraphicMemoryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _output.GraphicMemoryChanged(e.RowIndex, e.ColumnIndex, GraphicMemoryDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString());
        }
       
        private void SaveButton_Click(object sender, EventArgs e)
        {
            _output.SaveGraphicMemoryClicked();
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            _output.SaveAsGraphicMemoryClicked();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            _output.LoadGraphicMemoryClicked();      }

        private void GraphicMemoryDataGridView_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            _output.GraphicMemoryChanged(e.RowIndex, e.ColumnIndex, GraphicMemoryDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString());
        }
        
        private void PaletteButton_Click(object sender, EventArgs e)
        {
            _output.PaletteButtonClicked();
        }

        private void PaletteButton_ChangeUICues(object sender, UICuesEventArgs e)
        {
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            _output.DrawButtonClicked();
        }

        private void ClearGraphicMemory_Click(object sender, EventArgs e)
        {
            _output.ClearGraphicMemory();
        }

        private void GraphicDisplayForm_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(GraphicMemoryDataGridView.ColumnCount.ToString());
        }

        private void GraphicDisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.FormClosed();
        }
    }
}
