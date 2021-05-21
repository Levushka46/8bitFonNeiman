using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
                    byte A = 0;
                    byte R = 0;
                    byte G = 0;
                    byte B = 0;
                    string[] colors;
                    Color[] memory = new Color[16];
                    int i = 0;

                    text = sr.ReadLine();


                    colors = text.Split(',');

                    if (colors.Length != 64)
                    {
                        MessageBox.Show("Неверный формат файла. В файле Должно быть 64 числа.");
                        return null;
                    }

                    while (i < 64)
                    {

                        try
                        {
                            value = Convert.ToByte(colors[i]);


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


                                    memory[i / 4] = Color.FromArgb(A, R, G, B);



                                    break;



                            }


                        }

                        catch
                        {
                            MessageBox.Show("Неверный формат файла. Проверьте, что в нем находятся только числа от 0 до 255, разделённые запятой");
                            return null;
                        }
                        i++;
                    }
                    return memory;
                }
            }
            return null;
        }

        public void Save(Color[] colors)
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

            for (int i = 0; i < 64; i++)

            {
                switch (i % 4)
                {
                    case 0:
                        memoryArray[i] = memory[i / 4].A.ToString();
                        break;
                    case 1:
                        memoryArray[i] = memory[i / 4].R.ToString();
                        break;
                    case 2:
                        memoryArray[i] = memory[i / 4].G.ToString();
                        break;
                    case 3:
                        memoryArray[i] = memory[i / 4].B.ToString();
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
