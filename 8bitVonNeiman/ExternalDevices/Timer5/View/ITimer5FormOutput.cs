using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.Timer5.View {
    public interface ITimer5FormOutput {
        void ResetButtonClicked();
        void CaptureButtonClicked();
        void FormClosed();
    }
}
