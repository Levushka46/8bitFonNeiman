﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevices.SerialController.View
{
    
    public interface ISerialControllerFormOutput
    {
        void FormClosed();
        void CLKChanged(bool clk);
        void UpdateUI();
    }
}
