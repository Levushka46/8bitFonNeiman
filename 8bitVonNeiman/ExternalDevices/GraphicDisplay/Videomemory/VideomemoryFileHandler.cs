using System;
using System.Collections.Generic;
using _8bitVonNeiman.Common;
using System.IO;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay
{
    class VideomemoryFileHandler
    {

        private string _lastFilePath;

        public  ExtendedBitArray[] LoadMemory()
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Graphic Memory files (*.gmem8)|*.gmem8|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    string text;
                    byte value;
                    ExtendedBitArray[] memory = new ExtendedBitArray[4096];
            
                    int i = 0;
                    while (true)
                    {

                 

                        text = sr.ReadLine();
                        if (text == null)
                        {
                            break;
                        }

                        if (i >= 4096)

                        {

                            MessageBox.Show("Неверный формат файла. В файле должно быть 4096 чисел");
                            return null;
                        }

                        try
                        {
                            value = Convert.ToByte(text);
                       

                          
                            
                                memory[i] = new ExtendedBitArray(value);
                   
                            
                        }
                        catch
                        {

                    
                            MessageBox.Show("Неверный формат файла. Проверьте, что в нем находятся только числа от 0 до 255");
                           return null;
                        }
                        i++;
                    }


                    if (i != 4096)

                    {
                        MessageBox.Show("Неверный формат файла. В файле должно быть 4096 чисел");
                        return null;
                    }


                    return memory;
                   

                }

              



            }

            return null;

        }

        public void Save (ExtendedBitArray[] memory)
        {
            if (_lastFilePath == null)
            {
                SaveAs(memory);
            }
            else
            {
                Save(memory, _lastFilePath);
            }
        }

        public void SaveAs( ExtendedBitArray[] memory)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Graphic Memory files (*.gmem8)|*.gmem8";
            saveFileDialog.DefaultExt = "gmem8";
            if (_lastFilePath == null)
            {
                saveFileDialog.FileName = "gmemory.gmem8";
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

        private void Save(ExtendedBitArray[] memory, string path)
        {
            var count = Convert.ToInt32(Math.Pow(2, 12));
            var memoryArray = new List<string>(count);

            foreach (var pair in memory)
            {

                memoryArray.Add(pair.NumValue().ToString());
            }



            var text = string.Join(Environment.NewLine, memoryArray);

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
