using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.SerialController.View {
    public interface ISerialControllerStepFormOutput {
        void FormClosed();
        void CLKChanged(bool clk);
    }
}
