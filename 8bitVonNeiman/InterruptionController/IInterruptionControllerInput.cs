using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.InterruptionController {
    public interface IInterruptionControllerInput {
        // TODO interruption related methods: MakeInterruption, HasInterruptionRequests, AcknowledgeInterruption
        // TODO settings???: EnableInterruption, DisableInterruption
        bool HasInterruptionRequests();
        byte AcknowledgeInterruption();
        void MakeInterruption(byte irq);

        void ClearInterruptions();
    }
}
