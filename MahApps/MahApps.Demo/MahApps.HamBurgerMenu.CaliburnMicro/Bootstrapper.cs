using Caliburn.Micro;
using System.Windows;

namespace MahApps.HamBurgerMenu.CaliburnMicro
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Constructor

        public Bootstrapper()
        {
            Initialize();
        }

        #endregion Constructor

        #region Overrides

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // DisplayRootViewFor<IShell>();
        }

        #endregion Overrides
    }
}