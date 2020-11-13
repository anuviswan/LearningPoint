using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class HomePageViewModel:PageViewModelBase
    {
        public override string Title => "Home";
        public override object Icon => new MaterialExtension(PackIconMaterialKind.Home);
    }
}
