using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxUiDemo.ViewModels
{
    public class ShellViewModel:ReactiveObject
    {
        public string _currentSelection =  "No Item Selected";

        public string CurrentSelection
        {
            get => _currentSelection;
            set => this.RaiseAndSetIfChanged(ref _currentSelection, value);
        }
    }
}
