using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class ShellViewModel: Screen
    {
        public ShellViewModel()
        {
            MenuItems = new List<PageViewModelBase>
            {
                new HomePageViewModel(),
                new ProfilePageViewModel()
            };
        }
        public IEnumerable<PageViewModelBase> MenuItems { get; }
    }
}
