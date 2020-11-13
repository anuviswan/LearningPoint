using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps.HamBurgerMenu.CaliburnMicro.ViewModels
{
    public class PageViewModelBase:Screen
    {
        public virtual string Title { get; }
        public virtual object Icon { get; }
    }
}
