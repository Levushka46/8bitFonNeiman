using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8bitVonNeiman.ExternalDevicesManager.View;

namespace _8bitVonNeiman.ExternalDevicesManager {
	public class ExternalDevicesController : IExternalDevicesControllerInput, IDeviceManagerFormOutput {

		private DeviceManagerForm _form;

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
			throw new NotImplementedException();
		}

		public void FormClosed() {
			_form = null;
		}
	}
}
