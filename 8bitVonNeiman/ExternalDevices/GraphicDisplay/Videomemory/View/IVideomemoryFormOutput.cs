namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Videomemory.View
{
    public interface IVideomemoryFormOutput
    {
        void LoadVideomemoryClicked();

        void SaveVideomemoryClicked();

        void SaveAsVideomemoryClicked();

        void VideomemoryChange(int row, int column, object s);
        void ClearVideomemoryClicked();
        void VideomemoryFormClosed();
    }
}
