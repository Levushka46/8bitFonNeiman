namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette.View
{
    public interface IPaletteFormOutput
    {
        void PaletteMemoryChanged(int row, int collumn, string s);
        //  void ReadyButtonClicked();
        void ResetButtonClicked();
        void FormClosed();
        void LoadPaletteClicked();
        void SavePaletteClicked();
        void SaveAsPaletteClicked();
        void PaletteButtonClicked();
        void ClearButtonClicked();
        void PaletteChange(int row, int column, string A, string R, string G, string B, string s);
    }

}
