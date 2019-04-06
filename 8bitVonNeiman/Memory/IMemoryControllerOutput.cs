using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.Memory {
    public interface IMemoryControllerOutput {
        int CS { get; }
        int DS { get; }
        int SS { get; } 
    }
}
