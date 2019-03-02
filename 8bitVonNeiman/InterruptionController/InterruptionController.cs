using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.InterruptionController {
    public class InterruptionController : IInterruptionControllerInput {
        private static readonly byte NO_ACKNOWLEDGE_IRQ = 255;

        // Ожидающие запросы на прерывание
        private readonly ExtendedBitArray _irqs = new ExtendedBitArray();
        // Текущие обрабатываемые запросы на прерывание
        private readonly ExtendedBitArray _currentIrqs = new ExtendedBitArray();
        private readonly object _lock = new object();

        public bool HasInterruptionRequests() {
            lock (_lock) {
                return _irqs.NumValue() != 0;
            }
        }

        public byte AcknowledgeInterruption() {
            lock (_lock) {
                for (byte i = 0; i < 8; i++) {
                    if (_irqs[i]) {
                        _currentIrqs[i] = true;
                        _irqs[i] = false;
                        return i;
                    }
                }
                return NO_ACKNOWLEDGE_IRQ;
            }
        }

        public void MakeInterruption(byte irq) {
            lock (_lock) {
                _irqs[irq] = true;
            }
        }

        public void ClearInterruptions() {
            lock (_lock) {
                for (byte i = 0; i < 8; i++) {
                    _currentIrqs[i] = false;
                }
            }
        }

        public void Clear() {
            lock (_lock) {
                for (byte i = 0; i < 8; i++) {
                    _irqs[i] = false;
                    _currentIrqs[i] = false;
                }
            }
        }
    }
}
