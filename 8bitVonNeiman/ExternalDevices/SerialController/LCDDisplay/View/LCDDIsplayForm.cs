using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.ExternalDevices.SerialController.LCDDisplay.View
{
    public partial class LCDDisplayForm : Form, LCDDisplaySettingsForm.Output, LCDDisplayMemoryForm.Output
    {
        private readonly ILCDDisplayFormOutput _output;
        private LCDDisplayMemoryForm memoryForm;
        private const int CHAR_DOTS_W = 6;
        private const int CHAR_DOTS_H = 8;
        private const int CHAR_COUNT = 16;

        private const int START_X = 10;
        private const int START_Y = 10;
        private const int DOT_W = 4;
        private const int DOT_H = 4;
        private const int DOT_PAD_X = 1;
        private const int DOT_PAD_Y = 1;
        private const int CHAR_PAD_X = 4;

        private Color lcdBackgroundColor = Color.FromArgb(0, 0, 255);
        private Color lcdDisabledColor = Color.FromArgb(47, 0, 0, 0);
        private Color lcdEnabledColor = Color.FromArgb(224, 224, 255);

        private Pen disabledPen;
        private Pen enabledPen;

        private Brush disabledBrush;
        private Brush enabledBrush;

        private int textStartChar = 16;
        private readonly Encoding cp1251 = Encoding.GetEncoding("Windows-1251");

        public void ShowDeviceParameters(int baseAddress)
        {
            baseAddressLabel.Text = "0x" + Convert.ToString(baseAddress, 16); //baseAddress.ToString();
        }

        private byte[] font = new byte[] {
            // непечатаемые символы ASCII
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,
            0,   0,   0,   0,   0,   0,

            // ASCII
            0,   0,   0,   0,   0,   0,
            0,   0,   0, 242,   0,   0,
            0,   0, 224,   0, 224,   0,
            0,  40, 254,  40, 254,  40,
            0,  36,  84, 254,  84,  72,
            0, 196, 200,  16,  38,  70,
            0, 108, 146, 170,  68,  10,
            0,   0, 160, 192,   0,   0,
            0,   0,  56,  68, 130,   0,
            0,   0, 130,  68,  56,   0,
            0,  40,  16, 124,  16,  40,
            0,  16,  16, 124,  16,  16,
            0,   0,  10,  12,   0,   0,
            0,  16,  16,  16,  16,  16,
            0,   0,   6,   6,   0,   0,
            0,   4,   8,  16,  32,  64,
            0, 124, 138, 146, 162, 124,
            0,   0,  66, 254,   2,   0,
            0,  66, 134, 138, 146,  98,
            0, 132, 130, 162, 210, 140,
            0,  24,  40,  72, 254,   8,
            0, 228, 162, 162, 162, 156,
            0,  60,  82, 146, 146,  12,
            0, 192, 128, 142, 144, 224,
            0, 108, 146, 146, 146, 108,
            0,  96, 146, 146, 148, 120,
            0,   0, 108, 108,   0,   0,
            0,   0, 106, 108,   0,   0,
            0,  16,  40,  68, 130,   0,
            0,  40,  40,  40,  40,  40,
            0,   0, 130,  68,  40,  16,
            0,  64, 128, 138, 144,  96,
            0,  76, 146, 158, 130, 124,
            0, 126, 136, 136, 136, 126, // A - english
            0, 254, 146, 146, 146, 108,
            0, 124, 130, 130, 130,  68,
            0, 254, 130, 130,  68,  56,
            0, 254, 146, 146, 146, 130,
            0, 254, 144, 144, 144, 128,
            0, 124, 130, 146, 146,  94,
            0, 254,  16,  16,  16, 254,
            0,   0, 130, 254, 130,   0,
            0,   4,   2, 130, 252, 128,
            0, 254,  16,  40,  68, 130,
            0, 254,   2,   2,   2,   2,
            0, 254,  64,  48,  64, 254,
            0, 254,  32,  16,   8, 254,
            0, 124, 130, 130, 130, 124,
            0, 254, 144, 144, 144,  96,
            0, 124, 130, 138, 132, 122,
            0, 254, 144, 152, 148,  98,
            0,  98, 146, 146, 146, 140,
            0, 128, 128, 254, 128, 128,
            0, 252,   2,   2,   2, 252,
            0, 248,   4,   2,   4, 248,
            0, 252,   2,  28,   2, 252,
            0, 198,  40,  16,  40, 198,
            0, 224,  16,  14,  16, 224,
            0, 134, 138, 146, 162, 194,
            0, 254, 130, 130,   0,   0,
            0,  64,  32,  16,   8,   4,  //    0, 168, 104,  62, 104, 168,
            0,   0, 130, 130, 254,   0,
            0,  32,  64, 128,  64,  32,
            0,   2,   2,   2,   2,   2,
            0,   0, 128,  64,  32,   0,
            0,   4,  42,  42,  42,  30,
            0, 254,  18,  34,  34,  28,
            0,  28,  34,  34,  34,   4,
            0,  28,  34,  34,  18, 254,
            0,  28,  42,  42,  42,  24,
            0,  16, 126, 144, 128,  64,
            0,  48,  74,  74,  74, 124,
            0, 254,  16,  32,  32,  30,
            0,   0,  34, 190,   2,   0,
            0,   4,   2,  34, 188,   0,
            0, 254,   8,  20,  34,   0,
            0,   0, 130, 254,   2,   0,
            0,  62,  32,  24,  32,  30,
            0,  62,  16,  32,  32,  30,
            0,  28,  34,  34,  34,  28,
            0,  62,  40,  40,  40,  16,
            0,  16,  40,  40,  24,  62,
            0,  62,  16,  32,  32,  16,
            0,  18,  42,  42,  42,   4,
            0,  32, 252,  34,   2,   4,
            0,  60,   2,   2,   4,  62,
            0,  56,   4,   2,   4,  56,
            0,  60,   2,  28,   2,  60,
            0,  34,  20,   8,  20,  34,
            0,  48,  10,  10,  10,  60,
            0,  34,  38,  42,  50,  34,
            0,   0,  16, 108, 130,   0,
            0,   0,   0, 254,   0,   0,
            0,   0, 130, 108,  16,   0,
            8,  16,  16,   8,   8,  16,//   0,  16,  16,  84,  56,  16,
            0,   0,   0,   0,   0,   0,//   0,  16,  56,  84,  16,  16,

            // Hitachi таблица сразу за ASCII (первый символ - буква Б)
            0, 127,  73,  73,  73, 102,
            0,  15, 148, 228, 132, 255,
            0, 119,   8, 127,   8, 119,
            0,  65,  65,  73,  73,  54,
            0, 127,   4,   8,  16, 127,
            0,  63, 130,  68, 136,  63,
            0,   2,  65, 126,  64, 127,
            0, 127,  64,  64,  64, 127,
            0, 113,  10,   4,   8, 112,
            0, 126,   2,   2,   2, 127,
            0, 112,   8,   8,   8, 127,
            0,  63,   1,  63,   1,  63,
            0, 126,   2, 126,   2, 127,
            0,  64, 127,   9,   9,   6,
            0, 127,   9,   6,   0, 127,
            0,  34,  73,  81,  73,  62,
            0,  14,  17,   9,   6,  25,
            0,   3,   3, 127,  32,  24,
            0, 127,  64,  64,  64,  96,
            0,  17,  30,  16,  31,  17,
            0,  99,  85,  73,  65,  65,
            0,  14,  17,  17,  30,  16,
            0,   6,   6, 252, 163, 127,
            0,   8,  16,  30,  17,  32,
            0,   4,  60, 126,  60,   4,
            0,  62,  73,  73,  73,  62,
            0,  29,  35,  32,  35,  29,
            0,   6,  41,  81,  73,  38,
            0,  12,  20,   8,  20,  24,
            0,  28,  62,  31,  62,  28,
            0,  10,  21,  21,  17,   2,
            0,  63,  64,  64,  64,  63,
            0, 127, 127,   0, 127, 127,
            0,   0,   0,  79,   0,   0,
            0,  28,  34, 127,  34,   4,
            0,   9,  62,  73,  65,   2,
            0,  34,  28,  20,  28,  34,
            0,  84,  52,  31,  52,  84,
            0,   0,   0, 119,   0,   0,
            0,   2,  41,  85,  74,  32,
            0,  10,   9,  62,  72,  40,
            0, 127,  65,  93,  73, 127,
            0,   9,  85,  85,  85,  61,
            0,   8,  20,  42,  20,  34,
            0, 127,   8,  62,  65,  62,
            0,  49,  74,  76,  72, 127,
            0, 127,  65,  83,  69, 127,
            0,   0,  48,  80,   0,   0,
            0, 112, 136, 136, 112,   0,
            0,  17,  17, 125,  17,  17,
            0,  72, 152, 168,  72,   0,
            0, 136, 168, 168,  80,   0,
            0, 254, 160, 164,  79,   5,
            0, 127,   4,   4,   8, 124,
            0,  48,  72,  72, 127, 127,
            0,   0,  12,  12,   0,   0,
            0,  14,  17,   6,  17,  14,
            0,  72, 248,   8,   0,   0,
            0,  57,  69,  69,  69,  57,
            0,  34,  20,  42,  20,   8,
            0, 232,  22,  42,  95, 130,
            0, 232,  16,  41,  83, 141,
            0, 168, 248,   6,  10,  31,
            0,   6,   9,  81,   1,   2,
            127, 136, 136, 136, 136, 127, // A
            255, 145, 145, 145, 145, 142, //Б
            255, 145, 145, 145, 145, 126, //В
            255, 128, 128, 128, 128, 240, //Г
            7, 124, 132, 132, 124, 7, //Д
            255, 145, 145, 145, 145, 145, //Е 
            195, 102, 255, 255, 102, 195, //Ж
            66, 129, 145, 169, 197, 134, //З
            255, 4, 8 , 16, 32, 255, //И
            127, 4, 136, 144, 32, 127, //Й
            255, 24, 36, 66, 129, 0, //К
            63, 64, 128, 128, 64, 63, //Л
            255, 224, 24, 24, 224, 255, //М
            255, 16, 16, 16, 16, 255, //Н
            60, 66, 129, 129, 66, 60, //О
            127, 128, 128, 128, 128, 127, // П
            255, 136, 136, 136, 136, 112, //Р
            60, 66, 129, 129, 129, 66, //С
            224, 128, 255, 255, 128, 224, //Т
            225, 19, 14, 12, 16, 224, //У
            252, 132, 255, 255, 132, 252, //Ф
            195, 36, 24, 24, 36, 195, //Х
            0, 252, 4, 4, 254, 3, //Ц
            248, 8, 8, 8, 8, 255, //Ч
            255, 1, 255, 255, 1, 255, //Ш
            252, 4, 252, 252, 6, 255, //Щ
            224, 128, 255, 17, 17, 31, //Ъ
            255, 17, 17, 31, 0, 255, //Ы
            255, 17, 17, 31, 0, 0, //Ь
            66, 153, 153, 153, 153, 126, //Э
            255, 24, 255, 129, 129, 255, //Ю
            112, 137, 138, 140, 140, 255, //Я
            0, 6, 41, 41, 41, 30,  // а
            0, 63, 41, 41, 41, 47, // б
            0, 63, 41, 41, 41, 22, // в
            0, 63, 32, 32, 32, 56, // г
            0, 3, 62, 34, 62, 3, // д 
            0, 63, 41, 41, 41, 41, // е
            0, 49, 10, 63, 10, 49, // ж
            0, 33, 33, 41, 53, 34, // з
            0, 63, 4, 8, 16, 63, // и
            0, 31, 66, 68, 72, 31, // й
            0, 63, 12, 18, 33, 0, // к
            0, 15, 16, 32, 16, 15, // л
            0, 63, 16, 8, 16, 63, // м
            0, 63, 8, 8, 8, 63, // н
            0, 30, 33, 33, 33, 30, // о
            0, 63, 32, 32, 32, 63, // п
            0, 63, 36, 36, 36, 60, // р
            0, 63, 33, 33, 33, 33, // с
            0, 48, 32, 63, 32, 48, // т
            0, 49, 10, 4, 8, 48, // у
            0, 60, 36, 63, 36, 60, // ф
            0, 49, 10, 4, 10, 49, // х
            0, 62, 2, 2, 62, 3, // ц
            0, 60, 4, 4, 4, 63, // ч
            0, 63, 1, 63, 1, 63, // ш
            0, 62, 2, 62, 2, 63, // щ
            0, 48, 32, 63, 9, 15, // ъ
            0, 63, 9, 15, 0, 63, // ы
            0, 63, 9, 9, 15, 0, // ь
            0, 18, 33, 41, 41, 30, // э
            0, 63, 8, 63, 33, 63, // ю
            0, 60, 37, 38, 36, 63, // я
            0,  15, 148, 100,  20,  15,
            0,  15,  20, 100, 148,  15,
            0,  15,  84, 148,  84,  15,
            0,  79, 148, 148,  84, 143,
            0,  15, 148,  36, 148,  15,
            0,  15,  84, 180,  84,  15,
            0,  31,  36, 127,  73,  73,
            0, 120, 132, 133, 135,  72,
            0,  31, 149,  85,  21,  17,
            0,  31,  21,  85, 149,  17,
            0,  31,  85, 149,  85,  17,
            0,  31,  85,  21,  85,  17,
            0,   0, 145,  95,  17,   0,
            0,   0,  17,  95, 145,   0,
            0,   0,  81, 159,  81,   0,
            0,   0,  81,  31,  81,   0,
            0,   8, 127,  73,  65,  62,
            0,  95, 136, 132,  66, 159,
            0,  30, 161,  97,  33,  30,
            0,  30,  33,  97, 161,  30,
            0,  14,  81, 145,  81,  14,
            0,  78, 145, 145,  81, 142,
            0,  30, 161,  33, 161,  30,
            0,  34,  20,   8,  20,  34,
            0,   8,  85, 127,  85,   8,
            0,  62, 129,  65,   1,  62,
            0,  62,   1,  65, 129,  62,
            0,  30,  65, 129,  65,  30,
            0,  62, 129,   1, 129,  62,
            0,  32,  16,  79, 144,  32,
            0, 129, 255,  37,  36,  24,
            0,   1,  62,  73,  73,  54,      
        };

        internal void ShowRegisters(ExtendedBitArray dr, ExtendedBitArray ar, ExtendedBitArray scr)//object p
        {
            drBinTextBox.Text = dr.ToBinString();
            scrBinTextBox.Text = scr.ToBinString();
            arBinTextBox.Text = ar.ToBinString();
        }

        private byte[] allDots = new byte[CHAR_DOTS_W * CHAR_COUNT];
        private byte[] screenDots;
        public LCDDisplayForm(ILCDDisplayFormOutput output)
        {
            _output = output;
            InitializeComponent();
            disabledPen = new Pen(lcdDisabledColor);
            enabledPen = new Pen(lcdEnabledColor);
            disabledBrush = new SolidBrush(lcdDisabledColor);
            enabledBrush = new SolidBrush(lcdEnabledColor);

            for (int i = 0; i < allDots.Length; ++i)
            {
                allDots[i] = 255;
            }

            screenDots = new byte[CHAR_DOTS_W * CHAR_COUNT];
            byte[] hw = new byte[] {   };
            for (int i = 0; i < hw.Length; ++i)
            {
                screenDots[i] = hw[i];
            }
            //ShowText("");
        }

        public LCDDisplayForm(IDeviceOutput output)
        {
        }

        private void ShowText(string text)
        {
            byte[] textBytes = new byte[CHAR_DOTS_W * CHAR_COUNT]; //байты на вывод
            int textBytesI = 0, textBytesLength = textBytes.Length;
            foreach (char c in text)
            {
                if (textBytesI >= textBytesLength) break;
                byte[] bs = cp1251.GetBytes(new char[] { c });
                byte b = bs[0];
                for (int i = 0; i < 6; ++textBytesI, ++i)
                {
                    textBytes[textBytesI] = font[b * 6 + i];//(byte)c
                    //ResetButton.Text=b.ToString();//(byte)c 
                }
            }
            for (int i = 0; i < textBytes.Length; ++i)
            {
                screenDots[i] = textBytes[i];// screendots - память экрана, textBytes - что записываем
            }
            lcdpanel.Invalidate();
        }
        public void ShowVideoMemory(byte [] videomemory)
        {
            byte[] textBytes = new byte[CHAR_DOTS_W * CHAR_COUNT]; //байты на вывод
            int textBytesI = 0, textBytesLength = textBytes.Length;
            foreach (byte c in videomemory)
            {
                if (textBytesI >= textBytesLength) break;

                for (int i = 0; i < 6; ++textBytesI, ++i)
                {
                    textBytes[textBytesI] = font[c * 6 + i];//(byte)c
                    //ResetButton.Text = c.ToString();//(byte)c 
                }
            }
            for (int i = 0; i < textBytes.Length; ++i)
            {
                screenDots[i] = textBytes[i];// screendots - память экрана, textBytes - что записываем
            }
            if (memoryForm != null)
            {
                memoryForm.ShowVideoMemory(videomemory);
            }
            lcdpanel.Invalidate();
        }
        private void lcdpanel_Paint(object sender, PaintEventArgs e)
        {
            // нарисовать фон одним цветом
            e.Graphics.Clear(lcdBackgroundColor);
            // нарисовать выключенные точки (можно убрать, если цвет совпадает с фоном)
            DrawDots(e.Graphics, disabledBrush, allDots);
            // нарисовать включенные точки
            DrawDots(e.Graphics, enabledBrush, screenDots);
        }

        private void DrawDots(Graphics g, Brush brush, byte[] dots)
        {
            int x = START_X;
            int y;
            int dotsCol = 0;
            byte currentCol;
            for (int ch = 0; ch < CHAR_COUNT; ++ch)
            {
                for (int col = 0; col < CHAR_DOTS_W; ++col, ++dotsCol)
                {
                    y = START_Y;
                    currentCol = dots[dotsCol];
                    for (int row = 0; row < CHAR_DOTS_H; ++row)
                    {
                        // если старший бит 1 - рисуем точку
                        if ((currentCol & 0x80) != 0)
                        {
                            g.FillRectangle(brush, x, y, DOT_W, DOT_H);
                        }
                        y += DOT_H;
                        // сдвигаем, теперь следующий бит стал старшим
                        currentCol <<= 1;
                        if (row != CHAR_DOTS_H) { y += DOT_PAD_Y; }
                    }
                    x += DOT_W;
                    if (col != CHAR_DOTS_W - 1) { x += DOT_PAD_X; }
                }
                x += CHAR_PAD_X;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                textStartChar += 16;
                if (textStartChar >= 224)
                {
                    textStartChar = 32;
                }
                string text = "";
                for (char c = (char)textStartChar; c - textStartChar < 16; ++c)
                {
                    text += c;
                }
                ShowText(text);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _output.ResetButtonClicked();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            LCDDisplaySettingsForm settingsForm = new LCDDisplaySettingsForm(this, lcdBackgroundColor, lcdEnabledColor, MemoryBtn.Enabled);
            settingsForm.ShowDialog(this);
        }

        public void Save(Color backgroundColor, Color symbolColor, bool enmem)
        {
            lcdBackgroundColor = backgroundColor;
            lcdEnabledColor = symbolColor;
            enabledBrush = new SolidBrush(lcdEnabledColor);
            MemoryBtn.Enabled = enmem;
            lcdpanel.Invalidate();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сейчас в вашем браузере откроется информация о ВУ LCD-Display");
            HelpForm form = new HelpForm("LCDDisplay");
            form.Show();
        }

        private void MemoryBtn_Click(object sender, EventArgs e)
        {
            memoryForm = new LCDDisplayMemoryForm(this);
            memoryForm.ShowVideoMemory(_output.GetVideoMemory());
            memoryForm.Show(this);
        }

        public void MemoryChanged(int rowIndex, int columnIndex, string v)
        {
            _output.MemoryChanged(rowIndex,columnIndex,v);
        }

        void LCDDisplayMemoryForm.Output.FormClosed()
        {
            memoryForm = null;
        }

        private void LCDDisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.FormClosed();
        }
    }
}
