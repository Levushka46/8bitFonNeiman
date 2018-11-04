using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevicesManager.View;
using _8bitVonNeiman.ExternalDevices;

using _8bitVonNeiman.ExternalDevices.Keyboard1;

namespace _8bitVonNeiman.ExternalDevicesManager {
	public class ExternalDevicesController : IExternalDevicesControllerInput, IDeviceManagerFormOutput {

		private DeviceManagerForm _form;

        private readonly DevicesFactory _devicesFactory = new DevicesFactory();
        // todo make list of devices
        private IKeyboard1Input _keyboard1;

		public ExternalDevicesController() { }

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

		public void AddExternalDevice() {
            _keyboard1 = _devicesFactory.GetKeyboard1();
            _keyboard1.OpenForm();
		}

		public void FormClosed() {
			_form = null;
		}
	}
}
