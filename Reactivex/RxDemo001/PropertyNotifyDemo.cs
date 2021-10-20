using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RxDemo001;
public class PropertyNotifyDemo : IExecute
{
    public static void Run()
    {
        throw new NotImplementedException();
    }
}

public class Foo : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChange([CallerMemberName]string propertyName = "")
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
