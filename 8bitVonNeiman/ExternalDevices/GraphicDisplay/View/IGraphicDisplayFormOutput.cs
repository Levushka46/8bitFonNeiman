using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.View
{

        public interface IGraphicDisplayFormOutput
        {      
            void FormClosed();    
            void PaletteButtonClicked();
            void DrawButtonClicked();
            void VideomemoryButtonClicked();
            void ResetDisplayButtonClicked();
            void HelpButtonClicked();

        }
    

}
