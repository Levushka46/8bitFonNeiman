using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette
{
    class PaletteFileHandler
    {
        private string _lastFilePath;

        public Color[] LoadPalette()
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Palette files (*.pmem8)|*.pmem8|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    string text;
                    byte value;
                    byte A=0;
                    byte R=0;
                    byte G=0;
                    byte B=0;
                    string[] colors = new string[64];
                    Color[] memory = new Color[16];               
                    int i = 0;
                   
                    text = sr.ReadLine();
                    colors = text.Split(',');
                    while (i<64)
                    {
                        // if (colors == null)
                        //   MessageBox.Show("......");
                        // string[] colors = text.Split(',');
                        //    MessageBox.Show(colors[1]);
                        try
                        {
                            value = Convert.ToByte(colors[i]);
                           // MessageBox.Show((value).ToString());
                                switch (i % 4)
                                {
                                    case 0:
                                        A = value;
                                        break;
                                    case 1:
                                        R = value;
                                        break;
                                    case 2:
                                        G = value;
                                        break;
                                    case 3:
                                        B = value;
                                        try
                                        {
                                            memory[i / 4] = Color.FromArgb(A, R, G, B);
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Неверный формат файла. Превышено максимальное количество цветов.");
                                            return null;
                                        }
                                        break;
                                }
                            }
                        catch
                        {
                            MessageBox.Show("Неверный формат файла. Проверьте, что в нем находятся только числа от 0 до 255 по одному в строке.");
                            return null;
                        }
                        i++;
                    }
                    return memory;
                }
            }
            return null;
        }

        public void Save(Color[]colors)
        {
            if (_lastFilePath == null)
            {
                SaveAs(colors);
            }
            else
            {
                Save(colors, _lastFilePath);
            }
        }

        public void SaveAs(Color[] memory)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Palette files (*.pmem8)|*.pmem8";
            saveFileDialog.DefaultExt = "pmem8";
            if (_lastFilePath == null)
            {
                saveFileDialog.FileName = "palette.pmem8";
            }
            else
            {
                saveFileDialog.FileName = _lastFilePath;
            }
            saveFileDialog.Title = "Сохранить файл";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _lastFilePath = saveFileDialog.FileName;
                Save(memory, saveFileDialog.FileName);
            }
        }

        private void Save(Color[] memory, string path)
        {
            var count = Convert.ToInt32(Math.Pow(2, 6));
            var memoryArray = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                memoryArray.Add("0");
            }

            for(int i=0;i<64;i++)
            {
                switch(i%4)
                {
                    case 0:
                        memoryArray[i] = memory[i/4].A.ToString();
                        break;
                    case 1:
                        memoryArray[i] = memory[i/4].R.ToString();
                        break;
                    case 2:
                        memoryArray[i] = memory[i/4].G.ToString();
                        break;
                    case 3:
                        memoryArray[i] = memory[i/4].B.ToString();
                        break;
                }
            }
            var text = string.Join(",", memoryArray);

            try
            {
                using (var sw = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
                {
                    sw.Write(text);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно записать файл.");
            }
        }
    }
}
