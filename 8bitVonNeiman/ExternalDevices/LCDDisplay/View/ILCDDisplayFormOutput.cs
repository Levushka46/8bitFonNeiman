using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.LCDDisplay.View
{
    public interface ILCDDisplayFormOutput
    {
        void ResetButtonClicked();
        //void FormClosed();
        byte [] GetVideoMemory();
        void MemoryChanged(int rowIndex, int columnIndex, string v);
    }
}
