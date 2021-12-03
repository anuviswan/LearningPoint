using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace UserDataService;
internal class MainWindowViewModel : INotifyPropertyChanged
{
    private RpcClient _rpcClient;
    public MainWindowViewModel()
    {
        _rpcClient = new RpcClient();
        _rpcClient.LogMessage += (m) =>
        {
            Application.Current.Dispatcher.Invoke(() => LogMessages.Add(m));
        };

        _rpcClient.InitializeAndRun();
    }

    public ObservableCollection<string> LogMessages { get; set; } = new ObservableCollection<string>();

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

