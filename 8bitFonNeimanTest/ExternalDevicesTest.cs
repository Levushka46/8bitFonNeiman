using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.Controller;
using _8bitVonNeiman.ExternalDevices;
using _8bitVonNeiman.ExternalDevices.Display;
using _8bitVonNeiman.ExternalDevices.KeypadAndIndication;
using _8bitVonNeiman.ExternalDevicesManager;
using _8bitVonNeiman.ExternalDevicesManager.View;
using _8bitVonNeiman.ExternalDevices.Oscillograph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _8bitFonNeimanTest
{
    [TestClass]
    public class ExternalDevicesTest
    {
        readonly IExternalDevicesControllerOutput _externalDevice = new CentralController();

        [TestMethod]
        public void OscillographCreateTest()
        {
            IDeviceManagerFormOutput deviceManagerForm = new ExternalDevicesController(_externalDevice);

            deviceManagerForm.AddOscillograph();

            Assert.IsNotNull(deviceManagerForm);
        }

        [TestMethod]
        public void OscillographControllerCreateTest()
        {
            IDeviceOutput deviceOutput = new ExternalDevicesController(_externalDevice);
            DevicesFactory devicesFactory = new DevicesFactory(deviceOutput);

            IDeviceInput oscillographController = devicesFactory.GetOscillograph();
            
            Assert.IsInstanceOfType(oscillographController, typeof(OscillographController));
        }

        [TestMethod]
        public void KeypadAndIndicationCreateTest()
        {
            IDeviceManagerFormOutput deviceManagerForm = new ExternalDevicesController(_externalDevice);

            deviceManagerForm.AddKeypadAndIndication(1,1);

            Assert.IsNotNull(deviceManagerForm);
        }

        [TestMethod]
        public void KeypadAndIndicationControllerCreateTest()
        {
            IDeviceOutput deviceOutput = new ExternalDevicesController(_externalDevice);
            DevicesFactory devicesFactory = new DevicesFactory(deviceOutput);

            IDeviceInput keypadAndIndicationController = devicesFactory.GetKeypadAndIndication(1,1);

            Assert.IsInstanceOfType(keypadAndIndicationController, typeof(KeypadAndIndicationController));
        }

        [TestMethod]
        public void KeypadAndIndicationSetAndGetMemoryTest()
        {
            IDeviceOutput deviceOutput = new ExternalDevicesController(_externalDevice);
            DevicesFactory devicesFactory = new DevicesFactory(deviceOutput);

            
            int[] mas = {0x10,0x12,0x13};
            ExtendedBitArray extendedBitArray = new ExtendedBitArray(1);
            IDeviceInput keypadAndIndicationController = devicesFactory.GetKeypadAndIndication(0x1, 1);
            foreach (var m in mas)
            {
                keypadAndIndicationController.SetMemory(extendedBitArray, m);
                Assert.AreEqual(extendedBitArray, keypadAndIndicationController.GetMemory(m));
            }
        }

        [TestMethod]
        public void DisplayAddressTest()
        {
            IDeviceOutput deviceOutput = new ExternalDevicesController(_externalDevice);
            List<DisplayController> displays = new List<DisplayController>();
            for (int i = 0x0; i < 0x8; i++)
            {
                displays.Add(new DisplayController(deviceOutput, i));
            }

            foreach (var d in displays)
            {
                Assert.IsInstanceOfType(d, typeof(DisplayController));
            }
        }

        [TestMethod]
        public void KeypadAndIndicationAddressAndIrqTest()
        {
            IDeviceOutput deviceOutput = new ExternalDevicesController(_externalDevice);
            List<KeypadAndIndicationController> keypadAndIndications = new List<KeypadAndIndicationController>();
            for (int i = 0x0; i < 0x8; i++)
                for (int j = 0; j < 8; j++)
                {
                    keypadAndIndications.Add(new KeypadAndIndicationController(deviceOutput, i, j));
                }

            foreach (var KaI in keypadAndIndications)
            {
                Assert.IsInstanceOfType(KaI, typeof(KeypadAndIndicationController));
            }
        }

        [TestMethod]
        public void IsValidAddressAndIrqTest()
        {
            DeviceManagerForm device = new DeviceManagerForm(new ExternalDevicesController(_externalDevice));
            object sender = new TextBox();
            KeyPressEventArgs key1 = new KeyPressEventArgs('5');
            KeyPressEventArgs key2 = new KeyPressEventArgs('0');
            KeyPressEventArgs key3 = new KeyPressEventArgs('7');

            device.IsValidTest(sender, key1);
            device.IsValidTest(sender, key2);
            device.IsValidTest(sender, key3);

            Assert.IsFalse(key1.Handled);
            Assert.IsFalse(key2.Handled);
            Assert.IsFalse(key3.Handled);

        }

        [TestMethod]
        public void IsNotValidAddressAndIrqTest()
        {
            DeviceManagerForm device = new DeviceManagerForm(new ExternalDevicesController(_externalDevice));
            object sender = new TextBox();
            KeyPressEventArgs key1 = new KeyPressEventArgs('.');
            KeyPressEventArgs key2 = new KeyPressEventArgs('/');
            KeyPressEventArgs key3 = new KeyPressEventArgs('8');

            device.IsValidTest(sender, key1);
            device.IsValidTest(sender, key2);
            device.IsValidTest(sender, key3);

            Assert.IsTrue(key1.Handled);
            Assert.IsTrue(key2.Handled);
            Assert.IsTrue(key3.Handled);
        }
    }
}