using System;
using System.IO;
using System.Windows.Forms;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.Controller.View {
    public partial class ComponentsForm : Form {

        private IComponentsFormOutput _output;

        public ComponentsForm(IComponentsFormOutput output) {
            _output = output;
            InitializeComponent();
        }

        private void ComponentsForm_FormClosed(object sender, FormClosedEventArgs e) {
            _output.FormClosed();
        }

        private void editorButton_Click(object sender, EventArgs e) {
            _output.EditorButtonClicked();
        }

        private void memoryButton_Click(object sender, EventArgs e) {
            _output.MemoryButtonClicked();
        }

        private void cpuButton_Click(object sender, EventArgs e) {
            _output.CpuButtonClicked();
        }

        private void debugButton_Click(object sender, EventArgs e) {
            _output.DebugButtonClicked();
        }

		private void externalDevicesManagerButton_Click(object sender, EventArgs e) {
			_output.ExternalDevicesManagerClicked();
		}

        private void openAllButton_Click(object sender, EventArgs e) {
            _output.OpenAllButtonClicked();
        }

        private void aboutButton_Click(object sender, EventArgs e) {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void ComponentsForm_Load(object sender, EventArgs e)
        {
            string filename = Application.StartupPath;
            filename = Path.GetFullPath(
                Path.Combine(filename, ".\\fN8.pdf"));
            //webBrowser1.Navigate(filename);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm("fN8");
            form.Show();
        }
    }
}
