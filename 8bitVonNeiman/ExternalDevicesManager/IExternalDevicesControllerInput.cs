using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8bitVonNeiman.ExternalDevicesManager {
	public interface IExternalDevicesControllerInput {
		/// Функция, показывающая форму, если она закрыта
		void ChangeFormState();
	}
}
