using Caliburn.Micro;
using MahApps.Metro.Controls;
using System.Collections.Generic;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class ShellViewModel : Conductor<object>
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