using MahApps.Metro.IconPacks;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class ProfilePageViewModel: PageViewModelBase
    {
        public override string Title => "Profile";
        public override object Icon => new PackIconMaterial { Kind = PackIconMaterialKind.AccountStar };
    }
}
