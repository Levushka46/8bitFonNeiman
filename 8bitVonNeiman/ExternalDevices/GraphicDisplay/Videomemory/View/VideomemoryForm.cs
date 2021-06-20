using System;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Videomemory.View
{
    public partial class VideomemoryForm : Form
    {

        public const int RowCount = 256;
        public const int ColumnCount = 16;

        private readonly IVideomemoryFormOutput _output;

        public VideomemoryForm(IVideomemoryFormOutput output)
        {
            InitializeComponent();
            _output = output;


            VideoMemoryDataGridView.RowCount = RowCount;
            VideoMemoryDataGridView.ColumnCount = ColumnCount;
            VideoMemoryDataGridView.RowHeadersWidth = 60;
            for (int i = 0; i < RowCount; i++)
            {
                VideoMemoryDataGridView.Rows[i].HeaderCell.Value = (i << 4).ToString("X");
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                VideoMemoryDataGridView.Columns[i].HeaderCell.Value = i.ToString("X");
                VideoMemoryDataGridView.Columns[i].Width = 25;
            }
        }


        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void SetMemory(int row, int collumn, string memory)
        {
            VideoMemoryDataGridView[collumn, row].Value = memory;
        }


        public string GetMemory(int row, int collumn)
        {
            return VideoMemoryDataGridView[collumn, row].Value.ToString();
        }

        public void ScrollToSegment(int segment)
        {
            if (0 <= segment && segment <= VideoMemoryDataGridView.RowCount / 16)
            {
                VideoMemoryDataGridView.FirstDisplayedScrollingRowIndex = segment * 16;
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            _output.SaveVideomemoryClicked();
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            _output.SaveAsVideomemoryClicked();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            _output.LoadVideomemoryClicked();
        }

        private void VideomemoryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _output.VideomemoryChange(e.RowIndex, e.ColumnIndex, VideoMemoryDataGridView[e.ColumnIndex, e.RowIndex].Value);
        }

        private void ClearVideomemory_Click(object sender, EventArgs e)
        {
            _output.ClearVideomemoryClicked();
        }

        private void VideomemoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.VideomemoryFormClosed();
        }
    }
}
