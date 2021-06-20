namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Palette.View
{
    public interface IPaletteFormOutput
    {    
        void LoadPaletteClicked();
        void SavePaletteClicked();
        void SaveAsPaletteClicked();
        void PaletteButtonClicked();
        void PaletteChange(int row, int column, object A, object R, object G, object B);
        void PaletteFormClosed();
        void ResetPaletteButtonClicked();
    }

}
