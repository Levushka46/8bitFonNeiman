using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.Display.View {
    public interface IDisplayFormOutput {
        void ResetButtonClicked();
        void FormClosed();
    }
}
