using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices.Keyboard1 {
    public interface IKeyboard1Input {
        void OpenForm();
        void SetMemory(ExtendedBitArray memory, int address);
        ExtendedBitArray GetMemory(int address);
    }
}
