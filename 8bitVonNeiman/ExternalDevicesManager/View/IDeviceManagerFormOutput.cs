namespace _8bitVonNeiman.ExternalDevicesManager.View {
	public interface IDeviceManagerFormOutput {
		void AddExternalDevice(int baseAddress, int irq);
        void AddDisplay(int baseAddress);
        void AddTimer2(int baseAddress, int irq);
        void AddTimer5(int baseAddress, int irq);
		void AddOscillograph();
        void AddKeypadAndIndication(int baseAddress, int irq);
        void AddGraphicDisplay(int baseAddress);
		void FormClosed();
	}
}
