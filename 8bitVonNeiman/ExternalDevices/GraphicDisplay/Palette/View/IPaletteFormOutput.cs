namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette.View
{
    public interface IPaletteFormOutput
    {



        void ResetButtonClicked();

        void LoadPaletteClicked();

        void SavePaletteClicked();

        void SaveAsPaletteClicked();

        void PaletteButtonClicked();


        void PaletteChange(int row, int column, string A, string R, string G, string B, string s);
        void PaletteFormClosed();
    }

}
