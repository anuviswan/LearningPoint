using MahApps.Metro.IconPacks;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class HomePageViewModel:PageViewModelBase
    {
        public override string Title => "Home";
        public override object Icon => new PackIconMaterial { Kind = PackIconMaterialKind.Home };
    }
}
