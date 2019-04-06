using System.Collections.Generic;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.Debug {
    public interface IDebugModuleInput {
        void Open();
        /// Функция, показывающая форму, если она закрыта, и закрывающая ее, если она открыта
        void ChangeFormState();
        
        void CommandHasRun(int pcl, List<ExtendedBitArray> memory, bool isAutomatic);
    }
}
