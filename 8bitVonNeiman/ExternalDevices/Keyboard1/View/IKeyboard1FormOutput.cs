using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.Keyboard1.View {
    public interface IKeyboard1FormOutput {
        void CharacterEntered(char character);

        void ReadyButtonClicked();
        void ResetButtonClicked();
        void FormClosed();
    }
}
