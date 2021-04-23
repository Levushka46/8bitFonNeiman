using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevicesManager.View;
using _8bitVonNeiman.ExternalDevices;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevicesManager {
	public class ExternalDevicesController : IExternalDevicesControllerInput, IDeviceManagerFormOutput, IDeviceOutput {

		private DeviceManagerForm _form;

        private readonly IExternalDevicesControllerOutput _output;
        private readonly DevicesFactory _devicesFactory;
        private ISet<IDeviceInput> _devices = new HashSet<IDeviceInput>();
        public ISet<IDeviceInput> Devices => _devices;

        public ExternalDevicesController(IExternalDevicesControllerOutput output) {
            _devicesFactory = new DevicesFactory(this);
            _output = output;
        }

        public void Open() {
            if (_form == null) {
                _form = new DeviceManagerForm(this);
                _form.Show();
                _form.ShowAvailableDevices();
            }
        }

		/// Открывает форму, если она закрыта или закрывает, если открыта
		public void ChangeFormState() {
			if (_form == null) {
				_form = new DeviceManagerForm(this);
				_form.Show();
				_form.ShowAvailableDevices();
			} else {
				_form.Close();
			}
		}

        public void ExitThread() {
            foreach(var device in _devices) {
                device.ExitThread();
            }
        }

		public void AddExternalDevice(int baseAddress, int irq) {
            // todo select proper device
            IDeviceInput input = _devicesFactory.GetKeyboard1(baseAddress, irq);
            _devices.Add(input);

            input.OpenForm();
		}

        public void AddDisplay(int baseAddress) {
            IDeviceInput input = _devicesFactory.GetDisplay(baseAddress);
            _devices.Add(input);

            input.OpenForm();
        }

        public void AddTimer2(int baseAddress, int irq) {
            IDeviceInput input = _devicesFactory.GetTimer2(baseAddress, irq);
            _devices.Add(input);

            input.OpenForm();
        }

        public void AddTimer5(int baseAddress, int irq) {
            IDeviceInput input = _devicesFactory.GetTimer5(baseAddress, irq);
            _devices.Add(input);

            input.OpenForm();
        }

        public void AddOscillograph()
        {
            IDeviceInput input = _devicesFactory.GetOscillograph();
            _devices.Add(input);

            input.OpenForm();
        }

        public void AddKeypadAndIndication(int baseAddress, int irq)
        {
            IDeviceInput input = _devicesFactory.GetKeypadAndIndication(baseAddress, irq);
            _devices.Add(input);

            input.OpenForm();
        }

        public void AddGraphicDisplay(int baseAddress)
        {
            IDeviceInput input = _devicesFactory.GetGraphicDisplay(baseAddress);
            _devices.Add(input);

            input.OpenForm();
        }

        public void FormClosed() {
			_form = null;
		}

        public void DeviceFormClosed(IDeviceInput device) {
            _devices.Remove(device);
        }

        public ExtendedBitArray GetExternalMemory(int address) {
            foreach (var device in _devices) {
                if (device.HasMemory(address)) {
                    return device.GetMemory(address);
                }
            }
            return new ExtendedBitArray();
        }

        public void SetExternalMemory(ExtendedBitArray memory, int address) {
            foreach (var device in _devices) {
                if (device.HasMemory(address)) {
                    device.SetMemory(memory, address);
                    break;
                }
            }
        }

        public bool GetExternalMemoryBit(int address, int bitIndex) {
            foreach (var device in _devices) {
                if (device.HasMemory(address)) {
                    return device.GetMemoryBit(address, bitIndex);
                }
            }
            return false;
        }

        public void SetExternalMemoryBit(bool value, int address, int bitIndex) {
            foreach (var device in _devices) {
                if (device.HasMemory(address)) {
                    device.SetMemoryBit(value, address, bitIndex);
                    break;
                }
            }
        }

        public void UpdateUI() {
            foreach (var device in _devices) {
                device.UpdateUI();
            }
        }

        public void MakeInterruption(byte irq) {
            _output.MakeInterruption(irq);
        }
    }
}
