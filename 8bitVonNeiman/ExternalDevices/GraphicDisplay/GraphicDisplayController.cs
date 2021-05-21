using _8bitVonNeiman.Common;
using _8bitVonNeiman.Compiler.Model;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette.View;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.Videomemory.View;
using _8bitVonNeiman.ExternalDevices.GraphicDisplay.View;
using System;
using System.Drawing;
using System.Linq;

namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay
{

    public class GraphicDisplayController : IDeviceInput, IGraphicDisplayFormOutput, IPaletteFormOutput, IVideomemoryFormOutput
    {

        private ExtendedBitArray[] _videomemory = new ExtendedBitArray[4096];
        private VideomemoryFileHandler _fileHandler = new VideomemoryFileHandler();
        private PaletteFileHandler _fileHandler1 = new PaletteFileHandler();
        private GraphicDisplayForm _form;
        private readonly IDeviceOutput _output;
        private PaletteForm _form1;
        private VideomemoryForm _form2;

        private int _baseAddress = 50;

        private ExtendedBitArray _dr = new ExtendedBitArray();

        private ExtendedBitArray _arH = new ExtendedBitArray();

        private ExtendedBitArray _arL = new ExtendedBitArray();

        private ExtendedBitArray _cr = new ExtendedBitArray();

        private delegate void UpdateFormDelegate();

        private UpdateFormDelegate _updateFormDelegate;

        private Color[] colors = new Color[16];

        Bitmap Pixels;

        public GraphicDisplayController(IDeviceOutput output, int baseAddress)
        {
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


            for (int i = 0; i < 4096; i++)
                _videomemory[i] = new ExtendedBitArray("0");

            if (_form == null)
            {

                _form = new GraphicDisplayForm(this);


            }

            Pixels = new Bitmap(_form.GetScreen().Width, _form.GetScreen().Height);

            _form.ShowDeviceParameters(_baseAddress);
            DrawMemory();
            Draw();
            _form.Show();
            UpdateForm();
        }

        /// Открывает форму, если она закрыта или закрывает, если открыта
        public void ChangeFormState()
        {


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

                default:
                    return new ExtendedBitArray();

            }

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
                    {
                        DrawMemory();
                        Draw();

                    }
                    break;

            }
        }



        public ExtendedBitArray GetDr()
        {

            if (!IsPalette())
            {
                int address = (256 * (_arH.NumValue() & 15) + _arL.NumValue()) & 4095;


                return new ExtendedBitArray(_videomemory[address]);
            }


            else
            {
                byte palette = 0;

                int address = _arL.NumValue() & 63;

                switch (address % 4)
                {
                    case 0:
                        palette = colors[address / 4].A;
                        break;
                    case 1:
                        palette = colors[address / 4].R;
                        break;
                    case 2:
                        palette = colors[address / 4].G;
                        break;
                    case 3:
                        palette = colors[address / 4].B;

                        break;



                }

                return new ExtendedBitArray(palette);

            }


        }

        public void SetDr(ExtendedBitArray value)
        {
            if (IsEnabled())
            {

                if (!IsPalette())
                {
                    int address = 256 * (_arH.NumValue() & 15) + _arL.NumValue();

                    SetVideomemory(_dr, address);
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


                    switch (colorComponent)
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
                    if (_form1 != null)
                    {
                        _form1.SetPalette(colorIndex, colors[colorIndex]);
                        _form1.ShowColor(colorIndex, colors[colorIndex]);
                    }

                    if (IsRedraw())
                    {
                        DrawMemory();
                        Draw();
                    }
                }
            }


        }

        public void SetMemory(ExtendedBitArray[] memory)
        {

            memory.ToList().ForEach(i => _videomemory[i.NumValue()] = memory[i.NumValue()]);


        }


        public void LoadVideomemoryClicked()
        {
            var memory = _fileHandler.LoadMemory();
            if (memory == null)
            {
                return;
            }
            _videomemory = memory;
            SetMemory(memory);
            ShowVideomemory();

            if (IsRedraw())
            {
                DrawMemory();
                Draw();
            }

        }

        public void SaveVideomemoryClicked()
        {
            _fileHandler.Save(_videomemory);
        }

        public void SaveAsVideomemoryClicked()
        {
            _fileHandler.SaveAs(_videomemory);
        }

        public void DrawButtonClicked()
        {
            DrawMemory();
            Draw();

        }

        public void SetVideomemory(ExtendedBitArray memory, int address)
        {

            _videomemory[address] = memory;
            int i = address / VideomemoryForm.ColumnCount;
            int j = address % VideomemoryForm.ColumnCount;
            if (_form2 != null)
                _form2.SetMemory(i, j, MemoryHex(i, j));
        }


        public void ShowPalette()
        {
            for (int i = 0; i < PaletteForm.RowCount; i++)
                for (int j = 0; j < PaletteForm.ColumnCount; j++)
                {
                    _form1.SetPalette(i, j, PaletteHex(i, j));
                }

        }

        public void VideomemoryChange(int row, int column, string s)
        {
            if (s.Length > 2)
            {
                _form2.ShowMessage("Должно быть введено число от 0 до FF");
                _form2.SetMemory(row, column, MemoryHex(row, column));
                return;
            }


            int num;
            try
            {
                num = Convert.ToInt32(s, 16);
                if (num > 255 || num < 0)
                {
                    _form2.SetMemory(row, column, MemoryHex(row, column));
                    return;
                }
            }
            catch
            {
                _form2.ShowMessage("Должно быть введено число от 0 до FF");
                _form2.SetMemory(row, column, MemoryHex(row, column));
                return;
            }
            var bitArray = new ExtendedBitArray();
            CompilerSupport.FillBitArray(null, bitArray, num, 8);
            _videomemory[row * VideomemoryForm.ColumnCount + column] = bitArray;
            if (s.Length == 1)
            {
                s = "0" + s;
            }
            s = s.ToUpper();
            _form2.SetMemory(row, column, s);


            if (IsRedraw())
            {
                ChangeTwoPixels(row, column);
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

        public string MemoryHex(int row, int collumn)
        {
            int memoryIndex = row * VideomemoryForm.ColumnCount + collumn;

            return _videomemory[memoryIndex].ToHexString();

        }

        public string PaletteHex(int row, int column)
        {

            int ColorComponent = 0;

            switch (column)

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


            return (new int[4] { 8 * memory % _form.GetScreen().Width, (8 * memory / (_form.GetScreen().Width) * 4) & 255, (8 * memory + 4) % _form.GetScreen().Width, ((8 * memory + 4) / (_form.GetScreen().Width) * 4) & 255 });
        }


        public void ChangeTwoPixels(ExtendedBitArray _arH, ExtendedBitArray _arL)
        {


            int address = 256 * _arH.NumValue() + _arL.NumValue();
            ExtendedBitArray data = new ExtendedBitArray(_videomemory[address]);

            lock (new object())
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Pixels.SetPixel(GetCoordinates(address)[0] + j, GetCoordinates(address)[1] + i, colors[data.NumValue() & 15]);

                        Pixels.SetPixel(GetCoordinates(address)[2] + j, GetCoordinates(address)[3] + i, colors[data.NumValue() >> 4]);
                    }
                }
            }


        }

        public void ChangeTwoPixels(int row, int column)
        {


            int address = 16 * row + column;



            ExtendedBitArray data = new ExtendedBitArray(_videomemory[address]);


            lock (new object())
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Pixels.SetPixel(GetCoordinates(address)[0] + j, GetCoordinates(address)[1] + i, colors[data.NumValue() & 15]);
                        Pixels.SetPixel(GetCoordinates(address)[2] + j, GetCoordinates(address)[3] + i, colors[data.NumValue() >> 4]);
                    }
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
                ChangeTwoPixels(_arH1, _arL1);

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
                _form2.Close();

                _form1 = null;
                _form2 = null;
            }

            _output.DeviceFormClosed(this);
        }



        public void ResetButtonClicked()
        {
            _form.ClearBuffer();


            _cr = new ExtendedBitArray();
            _dr = new ExtendedBitArray();

            _arH = new ExtendedBitArray();
            _arL = new ExtendedBitArray();

            _form.Invoke(_updateFormDelegate);
        }

        /// Обновляет состояние формы в соответствии с текущим состоянием памяти
        private void ShowVideomemory()
        {
            for (int i = 0; i < VideomemoryForm.RowCount; i++)
                for (int j = 0; j < VideomemoryForm.ColumnCount; j++)
                {
                    _form2.SetMemory(i, j, MemoryHex(i, j));
                }
        }



        public bool IsEnabled()
        {
            return _cr[0];
        }

        public bool IsAutoincrement()
        {
            return _cr[1];
        }

        public bool IsPalette()
        {
            return _cr[2];
        }

        public bool IsRedraw()
        {
            return _cr[4];
        }
        public void PaletteButtonClicked()
        {
            if (_form1 != null)
                _form1.Close();

            _form1 = new PaletteForm(this);


            ShowPalette();

            _form1.Show();

            ShowColors();

        }



        public void LoadPaletteClicked()
        {
            colors = _fileHandler1.LoadPalette();
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





        public void PaletteChange(int row, int column, string A, string R, string G, string B, string s)
        {
            int num;
            try
            {
                num = Convert.ToInt32(s, 16);
                if (num > 255 || num < 0)
                {
                    _form1.ShowMessage("Должно быть введено число от 0 до FF");
                    _form1.SetPalette(row, colors[row]);
                    return;
                }
            }
            catch
            {
                _form1.ShowMessage("Должно быть введено число от 0 до FF");
                _form1.SetPalette(row, colors[row]);
                return;
            }
            if (s.Length == 1)
            {
                s = "0" + s;
            }
            s = s.ToUpper();

            colors[row] = Color.FromArgb(Convert.ToInt32(A, 16), Convert.ToInt32(R, 16), Convert.ToInt32(G, 16), Convert.ToInt32(B, 16));

            _form1.SetPalette(row, column, s);

            _form1.ShowColor(row, colors[row]);
            if (IsRedraw())
                DrawMemory();

        }

        public void ShowColors()
        {
            for (int i = 0; i < 16; i++)
                _form1.ShowColor(i, colors[i]);
        }

        public void ClearVideomemoryClicked()
        {
            for (int i = 0; i < VideomemoryForm.RowCount; i++)
                for (int j = 0; j < VideomemoryForm.ColumnCount; j++)
                    SetVideomemory(new ExtendedBitArray(), 16 * i + j);
            DrawMemory();
            Draw();



        }


        public void VideomemoryButtonClicked()
        {
            if (_form2 != null)
                _form2.Close();

            _form2 = new VideomemoryForm(this);


            ShowVideomemory();

            _form2.Show();


        }

        public void VideomemoryFormClosed()
        {
            _form2 = null;
        }

        public void PaletteFormClosed()
        {
            _form1 = null;
        }
    }
}


