using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using UserDisplay.Commands;

namespace UserDisplay;
internal class MainWindowViewModel:INotifyPropertyChanged
{
    private RpcClient _rpcClient;
    public int Count { get; set; } = 15;
    public ICommand FetchCommand { get; set; }

    public ObservableCollection<string> LogMessages { get; set; } = new ObservableCollection<string>();
    public MainWindowViewModel()
    {
        FetchCommand = new DelegateCommand((_) => ExecuteFetchCommand());
        _rpcClient = new RpcClient();
        _rpcClient.Initialiaze();
    }


    public async Task ExecuteFetchCommand()
    {
        var response = await _rpcClient.SendAsync(Count.ToString());
        LogMessages.Add($"Generating {Count} UserNames");
        await foreach(var userName in DeserializeStreaming<string>(response))
        {
            LogMessages.Add(userName);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async IAsyncEnumerable<T> DeserializeStreaming<T>(string data)
    {
        using var memStream = new MemoryStream(Encoding.UTF8.GetBytes(data));

        await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<T>(memStream))
        {
            yield return item;
        }
    }
}
