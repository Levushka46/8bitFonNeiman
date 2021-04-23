using System;
using System.Drawing;
using System.Windows.Forms;

namespace _8bitVonNeiman.Common
{
    public partial class HelpForm : Form
    {
        private readonly string file;

        public HelpForm(string file)
        {
            InitializeComponent();
            this.file = file;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            Size resolution = Screen.PrimaryScreen.Bounds.Size;
            Size = new Size(resolution.Width / 2, resolution.Height - 100);
            webBrowser.Navigate(Application.StartupPath + @"\Help\" + file + ".pdf");
            Location = new Point(20, 20);
        }
    }
}
