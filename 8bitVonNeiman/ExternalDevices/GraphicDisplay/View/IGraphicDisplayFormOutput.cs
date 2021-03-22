namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.View
{
    public interface IGraphicDisplayFormOutput
    {
        void GraphicMemoryChanged(int row, int collumn, string s);
        //  void ReadyButtonClicked();
        void ResetButtonClicked();
        void FormClosed();
        void LoadGraphicMemoryClicked();
        void SaveGraphicMemoryClicked();
        void SaveAsGraphicMemoryClicked();
        void PaletteButtonClicked();
        void DrawButtonClicked();
        void ClearGraphicMemory();
    }
    

}
