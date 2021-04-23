using System.Collections.Generic;

namespace _8bitVonNeiman.ExternalDevices.Oscillograph.View
{
    public interface IOscillographFormOutput
    {
        void FormClosed();
        List<IDeviceInput> ConnectedDevices { get; }
    }
}
