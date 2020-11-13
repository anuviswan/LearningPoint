using Caliburn.Micro;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class PageViewModelBase:Screen
    {
        public virtual string Title { get; }
        public virtual object Icon { get; }
    }
}
