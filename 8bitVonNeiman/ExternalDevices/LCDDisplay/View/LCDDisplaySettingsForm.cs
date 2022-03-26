using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.LCDDisplay.View
{
    public partial class LCDDisplaySettingsForm : Form
    {
        public interface Output
        {
            void Save(Color backgroundColor, Color symbolColor);
        }
        private class ColorByte
        {
            public byte value { get; set; }

            public ColorByte() { }
            public ColorByte(byte value) { this.value = value; }
        }

        private Color defaultBackgroundColor = Color.FromArgb(0, 0, 255);
        private Color defaultSymbolColor = Color.FromArgb(224, 224, 255);

        public Color backgroundColor { get; set; }
        public Color symbolColor { get; set; }

        public Output output;

        public LCDDisplaySettingsForm(Output output, Color backgroundColor, Color symbolColor)
        {
            InitializeComponent();
            this.output = output;
            this.backgroundColor = backgroundColor;
            this.symbolColor = symbolColor;
            ShowBackgroundColor();
            ShowSymbolColor();
        }

        private void ShowBackgroundColor()
        {
            Color color = backgroundColor;
            bgColorPreviewPanel.BackColor = color;
            bgColorATextBox.Text = ColorByteToString(color.A);
            bgColorRTextBox.Text = ColorByteToString(color.R);
            bgColorGTextBox.Text = ColorByteToString(color.G);
            bgColorBTextBox.Text = ColorByteToString(color.B);
        }

        private void ShowSymbolColor()
        {
            Color color = symbolColor;
            symbolColorPreviewPanel.BackColor = color;
            symbolColorATextBox.Text = ColorByteToString(color.A);
            symbolColorRTextBox.Text = ColorByteToString(color.R);
            symbolColorGTextBox.Text = ColorByteToString(color.G);
            symbolColorBTextBox.Text = ColorByteToString(color.B);
        }

        private void BackgroundColorChanged()
        {
            ColorByte a = StringToColorByte(bgColorATextBox.Text);
            ColorByte r = StringToColorByte(bgColorRTextBox.Text);
            ColorByte g = StringToColorByte(bgColorGTextBox.Text);
            ColorByte b = StringToColorByte(bgColorBTextBox.Text);
            Color newColor = ColorBytesToColor(a, r, g, b);
            if (newColor != Color.Empty)
            {
                backgroundColor = newColor;
                ShowBackgroundColor();
            }
        }

        private void SymbolColorChanged()
        {
            ColorByte a = StringToColorByte(symbolColorATextBox.Text);
            ColorByte r = StringToColorByte(symbolColorRTextBox.Text);
            ColorByte g = StringToColorByte(symbolColorGTextBox.Text);
            ColorByte b = StringToColorByte(symbolColorBTextBox.Text);
            Color newColor = ColorBytesToColor(a, r, g, b);
            if (newColor != Color.Empty)
            {
                symbolColor = newColor;
                ShowSymbolColor();
            }
        }

        private static string ColorByteToString(byte value)
        {
            string result = Convert.ToString(value, 16).ToUpper();
            if (result.Length < 2)
            {
                result = "0" + result;
            }
            return result;
        }

        private static ColorByte StringToColorByte(string value)
        {
            if (value.Length < 2)
            {
                return null;
            }
            try
            {
                return new ColorByte(Convert.ToByte(value, 16));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Color ColorBytesToColor(ColorByte a, ColorByte r, ColorByte g, ColorByte b)
        {
            if (a != null && r != null && g != null && b != null)
            {
                return Color.FromArgb(a.value, r.value, g.value, b.value);
            }
            return Color.Empty;
        }

        private void bgColorTextBox_TextChanged(object sender, EventArgs e)
        {
            BackgroundColorChanged();
        }

        private void symbolColorTextBox_TextChanged(object sender, EventArgs e)
        {
            SymbolColorChanged();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            output.Save(backgroundColor, symbolColor);
        }

        private void restoreDefaultsButton_Click(object sender, EventArgs e)
        {
            backgroundColor = defaultBackgroundColor;
            symbolColor = defaultSymbolColor;
            ShowBackgroundColor();
            ShowSymbolColor();
        }
    }
}
