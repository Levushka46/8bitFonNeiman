using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices.SerialController
{
    public class SerialInterfaceModule
    {
        public ExtendedBitArray dr = new ExtendedBitArray();
        public ExtendedBitArray cntk = new ExtendedBitArray();
        public bool f;
        public ExtendedBitArray n = new ExtendedBitArray();
        public ExtendedBitArray a = new ExtendedBitArray();
    }
}
