using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay.View
{
    public partial class LCDDisplayMemoryForm : Form
    {
        public const int RowCount = 1;
        public const int ColumnCount = 16;
        public interface Output { void MemoryChanged(int rowIndex, int columnIndex, string v); void FormClosed(); };
        public  Output _output;

        public LCDDisplayMemoryForm (Output output )
        {
            InitializeComponent();
            _output = output;
            memoryDataGridView.RowCount = RowCount;
            memoryDataGridView.ColumnCount = ColumnCount;
            memoryDataGridView.RowHeadersWidth = 60;
            for (int i = 0; i < RowCount; i++)
            {
                memoryDataGridView.Rows[i].HeaderCell.Value = (i << 4).ToString("X");
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                memoryDataGridView.Columns[i].HeaderCell.Value = i.ToString("X");
                memoryDataGridView.Columns[i].Width = 25;
            }
        }
        public LCDDisplayMemoryForm(IDeviceOutput output)
        {
            InitializeComponent();
        }
        public void ShowVideoMemory(byte [] VideoMemory)
        {
            for(int i=0;i<16;i++)
            {
                memoryDataGridView[i, 0].Value = Convert.ToString(VideoMemory[i], 16);
            }
        }

        private void MemoryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _output.MemoryChanged(e.RowIndex, e.ColumnIndex, memoryDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void LCDDisplayMemoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.FormClosed();
        }
    }
}
