using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevicesManager {
	public interface IExternalDevicesControllerInput {
		/// Функция, показывающая форму, если она закрыта
		void ChangeFormState();
        void ExitThread();
        ExtendedBitArray GetExternalMemory(int address);
        void SetExternalMemory(ExtendedBitArray memory, int address);
        bool GetExternalMemoryBit(int address, int bitIndex);
        void SetExternalMemoryBit(bool value, int address, int bitIndex);

        void UpdateUI();
    }
}
