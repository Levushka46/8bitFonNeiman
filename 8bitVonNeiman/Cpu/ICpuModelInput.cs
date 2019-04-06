using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.Cpu {
    public interface ICpuModelInput {
        void Open();
        void ChangeFormState();
        void Stop();
        void ExitThread();

        int CS { get; }
        int DS { get; }
        int SS { get; }
    }
}
