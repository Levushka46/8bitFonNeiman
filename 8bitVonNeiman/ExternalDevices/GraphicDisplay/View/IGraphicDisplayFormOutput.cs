namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.View
{

    public interface IGraphicDisplayFormOutput
    {
        void ResetButtonClicked();
        void FormClosed();

        void PaletteButtonClicked();

        void DrawButtonClicked();
        void VideomemoryButtonClicked();
    }


}
