using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _8bitVonNeiman.Common;
using _8bitVonNeiman.Compiler.Model;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.View;
using System.Drawing;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette.View;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay
{
    public class GraphicDisplayController : IDeviceInput, IGraphicDisplayFormOutput,IPaletteFormOutput
    {
        private Dictionary<int, ExtendedBitArray> _memory;
        private GraphicMemoryFileHandler _fileHandler = new GraphicMemoryFileHandler();
        private PaletteFileHandler _fileHandler1 = new PaletteFileHandler();
        private GraphicDisplayForm _form;
        private readonly IDeviceOutput _output;
        private PaletteForm _form1;

        private int _baseAddress = 50;

        private ExtendedBitArray _dr = new ExtendedBitArray();

        private ExtendedBitArray _arH = new ExtendedBitArray();

        private ExtendedBitArray _arL = new ExtendedBitArray();

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private readonly Encoding cp1251 = Encoding.GetEncoding("Windows-1251");

        private int _readIndex = 0;

        private delegate void UpdateFormDelegate();

        private UpdateFormDelegate _updateFormDelegate;

        private Color[] colors = new Color[16];

        Bitmap Pixels;
        Graphics Graphic;
        bool free = true;

        public GraphicDisplayController(IDeviceOutput output, int baseAddress)
        {
            _memory = new Dictionary<int, ExtendedBitArray>();
            _output = output;
            _updateFormDelegate = new UpdateFormDelegate(UpdateForm);
            _baseAddress = baseAddress * 0x10;
        }

        public override void OpenForm()
        {
            colors[0] = Color.FromArgb(255, 0, 0, 0);
            colors[1] = Color.FromArgb(255, 0, 0, 255);
            colors[2] = Color.FromArgb(255, 0, 255, 0);
            colors[4] = Color.FromArgb(255, 255, 0, 0);
            colors[5] = Color.FromArgb(255, 255, 0, 255);
            colors[6] = Color.FromArgb(255, 255, 255, 0);
            colors[7] = Color.FromArgb(255, 255, 255, 255);
            colors[8] = Color.FromArgb(255, 127, 127, 0);
            colors[9] = Color.FromArgb(255, 127, 127, 255);
            colors[10] = Color.FromArgb(255, 127, 255, 127);
            colors[11] = Color.FromArgb(255, 127, 255, 127);
            colors[12] = Color.FromArgb(255, 255, 127, 127);
            colors[13] = Color.FromArgb(255, 255, 127, 255);
            colors[14] = Color.FromArgb(255, 100, 200, 127);
            colors[15] = Color.FromArgb(255, 100, 100, 100);
            
            if (_form == null)
            {
                //MessageBox.Show("88");
                _form = new GraphicDisplayForm(this);
                _form1 = new PaletteForm(this);
            }

            Pixels = new Bitmap(_form.GetScreen().Width, _form.GetScreen().Height);

          // Graphic = Graphics.FromImage(Pixels);
          //  ColorPixels
          
            _form.ShowDeviceParameters(_baseAddress);
            ShowMemory();
            DrawMemory();
            Draw();
            _form.Show();
            UpdateForm();
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState()
        {
            //colors[4].
            if (_form == null)
            {
                _form = new GraphicDisplayForm(this);
                _form.Show();
                UpdateForm();
            }
            else
            {
                _form.Close();
            }
        }
        
        public void ChangeFormState1()
        {
            if (_form1 == null)
            {
                _form1.Show();
                UpdateForm();
            }
            else
            {
                _form1.Close();
            }
        }
        
        private void UpdateForm()
        {
            _form.ShowRegisters(_arL, _arH, GetDr(), _cr);
        }

        public override bool HasMemory(int address)
        {
            return _baseAddress <= address && address <= _baseAddress + 3;
        }

        public override void SetMemory(ExtendedBitArray memory, int address)
        {
            switch (address - _baseAddress)
            {
                case 0:
                    _arL = memory;
                    break;
                case 1:
                    _arH = memory;
                    break;
                case 2:
                    _dr = memory;
                    SetDr(memory);
                    NextAddress();
                    break;
                case 3:
                    _cr = memory;
                    if (IsRedraw())
                        Draw();
                    break;
            }
        }
        
        private ExtendedBitArray GetDr()
        {
        //    if (_form == null)
                //MessageBox.Show("76");
            if (!IsPalette())
            {
                int address = 256 * (_arH.NumValue() & 15) + _arL.NumValue();
                return new ExtendedBitArray(Convert.ToInt32(_form.GetMemory(address), 16));
            }
            else
            {
                int address =_arL.NumValue() & 63;
                return new ExtendedBitArray(Convert.ToInt32(_form1.GetPalette(address), 16));
            }
        }
        
        private void SetDr(ExtendedBitArray value)
        {
            if (IsEnabled())
            {
                if (!IsPalette())
                {
                    int address = 256 * (_arH.NumValue() & 15) + _arL.NumValue();
                    
                    SetVideoMemory(_dr, address);
                    ChangeTwoPixels(_arH, _arL);
                    if (IsRedraw())
                    {
                        Draw();
                    }
                }
                else
                {
                    int address = _arL.NumValue() & 63;
                    int colorIndex = address / 4;
                    int colorComponent = address % 4;

                    switch(colorComponent)
                    {
                        case 0:
                            colors[colorIndex] = Color.FromArgb(_dr.NumValue(), colors[colorIndex].R, colors[colorIndex].G, colors[colorIndex].B);
                            break;
                        case 1:
                            colors[colorIndex] = Color.FromArgb(colors[colorIndex].A, _dr.NumValue(), colors[colorIndex].G, colors[colorIndex].B);
                            break;
                        case 2:
                            colors[colorIndex] = Color.FromArgb(colors[colorIndex].A, colors[colorIndex].R, _dr.NumValue(), colors[colorIndex].B);
                            break;
                        case 3:
                            colors[colorIndex] = Color.FromArgb(colors[colorIndex].A, colors[colorIndex].R, colors[colorIndex].G, _dr.NumValue());
                            break;
                    }

                    _form1.SetPalette(colorIndex, colors[colorIndex]);
                    _form1.ShowColor(colorIndex, colors[colorIndex]);

                    if (IsRedraw())
                        Draw();
                }
            }
        }

        public void SetMemory(Dictionary<int, ExtendedBitArray> memory)
        {
            memory.ToList().ForEach(x => _memory[x.Key] = x.Value);
        }


        /// Очищает память.
        public void ClearMemoryClicked()
        {
            _memory = new Dictionary<int, ExtendedBitArray>();
            // Установка начального адреса по умолчанию в ячейку вектора сброса
            SetMemory(new ExtendedBitArray(Constants.StartAddress), Constants.ResetVectorAddress);
            SetMemory(new ExtendedBitArray(0), Constants.ResetVectorAddress + 1);
        }

        public void LoadGraphicMemoryClicked()
        {
            var memory = _fileHandler.LoadMemory();
            if (memory == null)
            {
                return;
            }
            _memory = memory;
            SetMemory(memory);
        }

        public void SaveGraphicMemoryClicked()
        {
            _fileHandler.Save(_memory);
        }

        public void SaveAsGraphicMemoryClicked()
        {
            _fileHandler.SaveAs(_memory);
        }

        public void DrawButtonClicked()
        {
            DrawMemory();
            Draw();
        }

        public void CheckMemoryClicked()
        {
            var memory = _fileHandler.LoadMemory();
            var missplaced = new List<int>();
            foreach (var key in memory.Keys)
            {
                if (!_memory.ContainsKey(key) || memory[key].NumValue() != _memory[key].NumValue())
                {
                    missplaced.Add(key);
                }
            }
            if (missplaced.Count == 0)
            {
                MessageBox.Show("Память соотвутствует эталонной");
            }
            else
            {
                var text = string.Join(", ", missplaced.Select(x => x.ToString("X2")).ToArray());
                MessageBox.Show("Память не соответствует в следующих позициях: " + text);
            }
        }

        public void SetVideoMemory(ExtendedBitArray memory, int address)
        {
            _memory[address] = memory;
            int i = address / GraphicDisplayForm.ColumnCount;
            int j = address % GraphicDisplayForm.ColumnCount;
            _form.SetMemory(i, j, MemoryHex(i, j));
        }

        public void ShowPalette()
        {
         //   MessageBox.Show((colors[15].ToArgb()).ToString());
            for (int i = 0; i < PaletteForm.RowCount; i++)
                for (int j = 0; j < PaletteForm.ColumnCount; j++)
                {
                    _form1.SetPalette(i, j, PaletteHex(i, j));
                }
        }

        public override ExtendedBitArray GetMemory(int address)
        {
            switch (address - _baseAddress)
            {
                case 0:

              return _arL;

                case 1:
                     return _arH;

                case 2:
                    ExtendedBitArray value = GetDr();
                    NextAddress();
                    return value;
                case 3:
                    return _cr;
            }
            return new ExtendedBitArray();
        }

        public void GraphicMemoryChanged(int row, int collumn, string s)
        {
            if (s.Length > 2)
            {
                _form.ShowMessage("Введено некорректное число");
                _form.SetMemory(row, collumn, MemoryHex(row, collumn));
                return;
            }

            int num;
            try
            {
                num = Convert.ToInt32(s, 16);
                if (num > 255 || num < 0)
                {
                    _form.ShowMessage("Число должно быть от 0 до FF");
                    _form.SetMemory(row, collumn, MemoryHex(row, collumn));
                    return;
                }
            }
            catch
            {
                _form.ShowMessage("Введено некорректное число");
                _form.SetMemory(row, collumn, MemoryHex(row, collumn));
                return;
            }
            var bitArray = new ExtendedBitArray();
            CompilerSupport.FillBitArray(null, bitArray, num, 8);
            _memory[row * GraphicDisplayForm.ColumnCount + collumn] = bitArray;
            if (s.Length == 1)
            {
                s = "0" + s;
            }
            s = s.ToUpper();
            _form.SetMemory(row, collumn, s);
            
            if (IsRedraw())
            {
                ChangeTwoPixels(row, collumn);
                Draw();
            }
        }

        private void NextAddress()
        {
            if (IsAutoincrement())
            {
                _arL.Inc();
                if (_arL.NumValue() == 0)
                    _arH.Inc();
                GetDr();
            }
        }

        private string MemoryHex(int row, int collumn)
        {
            int memoryIndex = row * GraphicDisplayForm.ColumnCount + collumn;
            if (_memory.ContainsKey(memoryIndex))
            {
                return _memory[memoryIndex].ToHexString();
            }
            else
            {
                return "00";
            }
        }

        private string PaletteHex(int row, int collumn)
        {
            int ColorComponent=0;
            
            switch (collumn)
            {
                case 0:
                    ColorComponent = colors[row].A;
                    break;
                case 1:
                    ColorComponent = colors[row].R;
                    break;
                case 2:
                    ColorComponent = colors[row].G;
                    break;
                case 3:
                    ColorComponent = colors[row].B;
                    break;
            }
            return ColorComponent.ToString("X2");
        }

        public int[] GetCoordinates(int memory)
        {
            return (new int[4] { 8 * memory % _form.GetScreen().Width, 8 * memory / (_form.GetScreen().Width) * 4, 
                (8 * memory + 4) % _form.GetScreen().Width, (8 * memory + 4) / (_form.GetScreen().Width) * 4 });
        }
        
        public void ChangeTwoPixels(ExtendedBitArray _arH, ExtendedBitArray _arL)
        {
            int address = 256 * _arH.NumValue() + _arL.NumValue();  
            ExtendedBitArray data = new ExtendedBitArray((byte)Convert.ToInt32(_form.GetMemory(address), 16));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Pixels.SetPixel(GetCoordinates(address)[0] + j, GetCoordinates(address)[1] + i, colors[data.NumValue() & 15]);
                    Pixels.SetPixel(GetCoordinates(address)[2] + j, GetCoordinates(address)[3] + i, colors[data.NumValue() >> 4]);
                }
            }
        }

        public void ChangeTwoPixels(int row, int column)
        {
            int address = 16 * row + column;
            ExtendedBitArray data = new ExtendedBitArray((byte)Convert.ToInt32(_form.GetMemory(address), 16));
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Pixels.SetPixel(GetCoordinates(address)[0] + j, GetCoordinates(address)[1] + i, colors[data.NumValue() & 15]);
                    Pixels.SetPixel(GetCoordinates(address)[2] + j, GetCoordinates(address)[3] + i, colors[data.NumValue() >> 4]);
                }
            }
        }


        public void DrawMemory()
        {
            ExtendedBitArray _arL1 = new ExtendedBitArray();
            ExtendedBitArray _arH1 = new ExtendedBitArray();
            bool maxmemory = false;

            while (!maxmemory)
            {
                ChangeTwoPixels(_arH1,_arL1);

                if (_arL1.NumValue() == 255)
                {
                    if (_arH1.NumValue() == 15)
                    {
                        maxmemory = true;
                    }
                    _arH1.Inc();
                }
                _arL1.Inc();
            }
        }

        public void Draw()
        {
            _form.SetScreen(Pixels);
           // System.Threading.Thread.Sleep(2);
        }

        public override void UpdateUI()
        {
            UpdateForm();
        }

        public void FormClosed()
        {
            _form = null;

            if (_form1 != null)
            {
                _form1.Close();
                _form1 = null;
            }
            _output.DeviceFormClosed(this);
        }

        public void ResetButtonClicked()
        {
            _form.ClearBuffer();

            _readIndex = 0;
            _cr = new ExtendedBitArray();
            _dr = new ExtendedBitArray();
            _readIndex = 0;
            _arH = new ExtendedBitArray();
            _arL = new ExtendedBitArray();

            _form.Invoke(_updateFormDelegate);
        }

        /// Обновляет состояние формы в соответствии с текущим состоянием памяти
        private void ShowMemory()
        {
            for (int i = 0; i < GraphicDisplayForm.RowCount; i++)
                for (int j = 0; j < GraphicDisplayForm.ColumnCount; j++)
                {
                    _form.SetMemory(i, j, MemoryHex(i, j));
                }
        }

        private bool IsEnabled()
        {
            return _cr[0];
        }

        private bool IsAutoincrement()
        {
            return _cr[1];
        }

        private bool IsPalette()
        {
            return _cr[2];
        }

        private bool IsFullPalette()
        {
            return _cr[3];
        }

        private bool IsRedraw()
        {
            return _cr[4];
        }
        public void PaletteButtonClicked()
        {
            _form1.Close();
            _form1 = new PaletteForm(this);
              ShowPalette();
            _form1.Show();
            ShowColors();
        }

        public void PaletteMemoryChanged(int row, int collumn, string s)
        {
            throw new NotImplementedException();
        }

        public void LoadPaletteClicked()
        {
           colors=_fileHandler1.LoadPalette();
           if (colors == null)
                return;
           ShowPalette();
           ShowColors();
        }
        
        public void SavePaletteClicked()
        {
            _fileHandler1.Save(colors);
        }

        public void SaveAsPaletteClicked()
        {
            _fileHandler1.SaveAs(colors);
        }

        public void ClearButtonClicked()
        {
            throw new NotImplementedException();
        }

        public void PaletteChange(int row, int column,string A, string R, string G, string B, string s)
        {
            int num;
            try
            {
                num = Convert.ToInt32(s, 16);
                if (num > 255 || num < 0)
                {
                    _form1.ShowMessage("Число должно быть от 0 до FF");
                    _form1.SetPalette(row, colors[row]);
                    return;
                }
            }
            catch
            {
                _form1.ShowMessage("Введено некорректное число");
                _form1.SetPalette(row, colors[row]);
                return;
            }
            if (s.Length == 1)
            {
                s = "0" + s;
            }
            s = s.ToUpper();
           
            colors[row] = Color.FromArgb(Convert.ToInt32(A,16), Convert.ToInt32(R,16), Convert.ToInt32(G,16), Convert.ToInt32(B,16));
           
            _form1.SetPalette(row,column,s);

            _form1.ShowColor(row, colors[row]);
            if (IsRedraw())
                DrawMemory();
                
        }

        public void ShowColors()
        {
            for (int i = 0; i < 16; i++)
                _form1.ShowColor(i, colors[i]);
        }

        public void ClearGraphicMemory()
        {
            for (int i = 0; i < GraphicDisplayForm.RowCount; i++)
                for (int j = 0; j < GraphicDisplayForm.ColumnCount; j++)
                    SetVideoMemory(new ExtendedBitArray(), 16 * i + j);
            DrawMemory();
            Draw();
        }
    }
}


