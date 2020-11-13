using Caliburn.Micro;
using System.Collections.Generic;

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
        public void MenuSelectionChanged(object h, object eventArgs)
        {

        }
    }
}
