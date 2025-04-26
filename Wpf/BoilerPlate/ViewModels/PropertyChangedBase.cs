using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BoilerPlate.ViewModels
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyOnPropertyChanged([CallerMemberName] string? property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
