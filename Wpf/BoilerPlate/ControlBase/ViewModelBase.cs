//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//namespace BoilerPlate.ControlBase
//{
//    public class ViewModelBase
//    {
//    }
//}




using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace InGen.Client
{
    public partial class AutoNotifyPropertyChangeDemo : System.ComponentModel.INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}