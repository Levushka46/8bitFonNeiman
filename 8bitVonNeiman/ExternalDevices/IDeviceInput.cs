using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices {
    public abstract class IDeviceInput {
        public abstract void OpenForm();
        public virtual void ExitThread() { }
        public abstract bool HasMemory(int address);
        public abstract void SetMemory(ExtendedBitArray memory, int address);
        public abstract ExtendedBitArray GetMemory(int address);
        public virtual void SetMemoryBit(bool value, int address, int bitIndex) {
            ExtendedBitArray byteValue = GetMemory(address);
            byteValue[bitIndex] = value;
            SetMemory(byteValue, address);
        }
        public virtual bool GetMemoryBit(int address, int bitIndex) {
            ExtendedBitArray byteValue = GetMemory(address);
            return byteValue[bitIndex];
        }
        public virtual void Clock() { }

        public abstract void UpdateUI();
    }
}
