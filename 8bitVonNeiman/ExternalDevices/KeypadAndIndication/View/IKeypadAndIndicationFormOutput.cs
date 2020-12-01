namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View
{
    public interface ISevenSegmentFormOutput
    {
        void ResetButtonClicked();
        void Key(int num);
        void FormClosed();
    }
}