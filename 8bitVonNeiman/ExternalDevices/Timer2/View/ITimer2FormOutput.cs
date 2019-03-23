using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.Timer2.View {
    public interface ITimer2FormOutput {
        void ResetButtonClicked();
        void CaptureButtonClicked();
        void FormClosed();
    }
}
