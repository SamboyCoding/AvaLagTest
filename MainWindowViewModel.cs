namespace AvaLagTest;

public class MainWindowViewModel : EasyNotifyPropertyChanged
{
    private string _logText;
    private string _summary;

    public string LogText
    {
        get => _logText;
        set
        {
            _logText = value;
            OnPropertyChanged();
        }
    }

    public string Summary
    {
        get => _summary;
        set
        {
            _summary = value;
            OnPropertyChanged();
        }
    }
}