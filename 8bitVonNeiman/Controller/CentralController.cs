using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.Compiler;
using _8bitVonNeiman.Controller.View;
using _8bitVonNeiman.Cpu;
using _8bitVonNeiman.Debug;
using _8bitVonNeiman.Memory;
using _8bitVonNeiman.ExternalDevicesManager;
using _8bitVonNeiman.InterruptionController;

namespace _8bitVonNeiman.Controller {
    public class CentralController: ApplicationContext, IComponentsFormOutput, ICompilerControllerOutput, ICpuModelOutput, IMemoryControllerOutput, IDebugModuleOutput, IExternalDevicesControllerOutput {

        private readonly IMemoryControllerInput _memoryController;
        private readonly ComponentsForm _componentsForm;
        private readonly CompilerController _compilerController;
        private readonly IDebugModuleInput _debugController;
        private readonly ICpuModelInput _cpu;
		private readonly IExternalDevicesControllerInput _externalDevicesController;
        private readonly IInterruptionControllerInput _interruptionController;

        private int _lastPcl;
        private int _lastCs;

        public int CS { get { return _cpu.CS; } }
        public int DS { get { return _cpu.DS; } }
        public int SS { get { return _cpu.SS; } }

        public CentralController() {
            _componentsForm = new ComponentsForm(this);
            _componentsForm.Show();
            _compilerController = Assembly.GetCompilerController(this);
            _memoryController = Assembly.GetMemoryController(this);
            _debugController = Assembly.GetDebugController(this);
            _interruptionController = Assembly.GetInterruptionController();
            _externalDevicesController = Assembly.GetExternalDevicesController(this);
            // Важно, чтобы CPU создавался после debug'a
            _cpu = Assembly.GetCpu(this);
        }

        public void FormClosed() {
            _cpu.ExitThread();
            _externalDevicesController.ExitThread();
            ExitThread();
        }

        public void MemoryFormed(Dictionary<int, ExtendedBitArray> memory) {
            _memoryController.SetMemory(memory);
            _debugController.CommandHasRun(_lastPcl, _memoryController.GetMemoryFromSegment(_lastCs), false);
        }

        public void EditorButtonClicked() {
            _compilerController.ChangeState();
        }

        public void MemoryButtonClicked() {
            _memoryController.ChangeFormState();
        }

        public void CpuButtonClicked() {
            _cpu.ChangeFormState();
        }

        public void DebugButtonClicked() {
            _debugController.ChangeFormState();
        }

		public void ExternalDevicesManagerClicked() {
			_externalDevicesController.ChangeFormState();
		}

        public void OpenAllButtonClicked() {
            _cpu.Open();
            _compilerController.Open();
            _debugController.Open();
            _memoryController.Open();
            _externalDevicesController.Open();
        }

		public ExtendedBitArray GetMemory(int address) {
            return _memoryController.GetMemory(address);
        }

        public void SetMemory(ExtendedBitArray memory, int address) {
            _memoryController.SetMemory(memory, address);
        }

        public ExtendedBitArray GetExternalMemory(int address) {
            return _externalDevicesController.GetExternalMemory(address);
        }

        public void SetExternalMemory(ExtendedBitArray memory, int address) {
            _externalDevicesController.SetExternalMemory(memory, address);
        }

        public bool GetExternalMemoryBit(int address, int bitNumber) {
            return _externalDevicesController.GetExternalMemoryBit(address, bitNumber);
        }

        public void SetExternalMemoryBit(bool value, int address, int bitNumber) {
            _externalDevicesController.SetExternalMemoryBit(value, address, bitNumber);
        }

        public void StopExecution() {
            _cpu.Stop();
        }

        public void CommandHasRun(int pcl, int cs, bool isAutomatic) {
            _lastPcl = pcl;
            _lastCs = cs;
            _debugController.CommandHasRun(pcl, _memoryController.GetMemoryFromSegment(cs), isAutomatic);
        }

        public void Clock() {
            _externalDevicesController.Clock();
        }

        public void UpdateUI() {
            _externalDevicesController.UpdateUI();
        }

        public bool HasInterruptionRequests() {
            return _interruptionController.HasInterruptionRequests();
        }

        public byte AcknowledgeInterruption() {
            return _interruptionController.AcknowledgeInterruption();
        }

        public void MakeInterruption(byte irq) {
            _interruptionController.MakeInterruption(irq);
        }

        public void ClearInterruptions() {
            _interruptionController.ClearInterruptions();
        }

        public void Clear() {
            _interruptionController.Clear();
        }
    }
}
