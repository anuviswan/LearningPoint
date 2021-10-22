using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;

namespace RxDemo001;
public class PropertyNotifyDemo : IExecute
{
    public static void Run()
    {
        Console.WriteLine("Executing Property Notify Demo");
        var foo = new Foo();
        Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(h=>h.Invoke, h => foo.PropertyChanged += h, h => foo.PropertyChanged -= h)
            .Subscribe((e) => Console.WriteLine($"Subscribe:Changed {e.EventArgs.PropertyName}"));

        foo.Name = "Anu";

        Console.ReadLine();
    }


}

public class Foo : INotifyPropertyChanged
{
    private string _name;
    public string Name 
    {
        get => _name;
        set
        {
            if (_name == value) return;
            _name = value;
            NotifyPropertyChange();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChange([CallerMemberName]string propertyName = "")
    {
        if (!string.IsNullOrWhiteSpace(propertyName))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
