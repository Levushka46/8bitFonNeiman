using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices {
    public interface IDeviceInput {
        void OpenForm();
        bool HasMemory(int address);
        void SetMemory(ExtendedBitArray memory, int address);
        ExtendedBitArray GetMemory(int address);

        void CommandHasRun(int pcl, List<ExtendedBitArray> memory, bool isAutomatic);
    }
}
