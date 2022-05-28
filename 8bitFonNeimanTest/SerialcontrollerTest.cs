using System;
using System.Drawing;
using _8bitVonNeiman.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _8bitVonNeiman.ExternalDevices;
using _8bitVonNeiman.ExternalDevices.SerialController;
using _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay;

using _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay.View;

namespace _8bitFonNeimanTest
{
    [TestClass]
    public class SerialcontrollerTest
    {
        private readonly ILCDDisplayFormOutput _output;
        private readonly _8bitVonNeiman.ExternalDevices.IDeviceOutput output;
        private readonly LCDDisplayMemoryForm.Output output_;
        int adr = 7;
        int baseadr = 0x70;
        [TestMethod]
        public void TestSetMemorySetsDr()
        {
            IDeviceOutput _output=new DeviceOutput();
            scController controller = new scController(_output, adr);
            controller.OpenLCDDisplayForm();
            int lcdscr = 1 ;
            int lcddr = 65;
            controller.SetMemory(new ExtendedBitArray(1), baseadr + 1);
            controller.SetMemory(new ExtendedBitArray(6), baseadr);
            controller.SetMemory(new ExtendedBitArray(lcdscr), baseadr);
            controller.SetMemory(new ExtendedBitArray(4), baseadr);
            controller.SetMemory(new ExtendedBitArray(lcddr), baseadr);
            controller.SetMemory(new ExtendedBitArray(0x86), baseadr);
            Assert.AreEqual(lcdscr, controller.GetMemory(baseadr).NumValue());
            controller.SetMemory(new ExtendedBitArray(0x84), baseadr);
            Assert.AreEqual(lcddr, controller.GetMemory(baseadr).NumValue());
        }

        [TestMethod]
        public void TestSetMemorySetsScr0()
        {
            int adr2 = baseadr + 0x01;
            IDeviceOutput _output = new DeviceOutput();
            scController controller = new scController(_output, adr);
            ExtendedBitArray mem = new ExtendedBitArray(5);
            controller.SetMemory(mem, adr2);
            ExtendedBitArray testmem = controller.GetMemory(adr2);
            Assert.AreEqual(mem[0], testmem[0]);
        }

        [TestMethod]
        public void TestHasMemory()
        {
            LCDDisplayForm controller = new LCDDisplayForm(_output);
            int baseadress = baseadr;
            controller.ShowDeviceParameters(baseadress);
        }
        [TestMethod]
        public void ShowDeviceParametersTest()
        {
            LCDDisplayForm controller = new LCDDisplayForm(_output);
            int baseadress = 96;
            controller.ShowDeviceParameters(baseadress);
        }
        [TestMethod]
        public void ShowVideoMemoryTest()
        {
            LCDDisplayForm controller = new LCDDisplayForm(_output);
            byte[] videomemory = new byte[] { };
            controller.ShowVideoMemory(videomemory);
        }
        public class DeviceOutput : IDeviceOutput
        {
            public ISet<IDeviceInput> Devices => throw new NotImplementedException();

            public void DeviceFormClosed(IDeviceInput device)
            {
                //throw new NotImplementedException();
            }

            public void MakeInterruption(byte irq)
            {
                //throw new NotImplementedException();
            }
        }
    }
}
