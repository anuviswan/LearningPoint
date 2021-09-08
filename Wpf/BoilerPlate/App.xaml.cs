using BoilerPlate.Services;
using BoilerPlate.ViewModels;
using System.Windows;

namespace BoilerPlate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bootstrap.Bootstrap _bootstrapper;
        public App()
        {
            _bootstrapper = new Bootstrap.Bootstrap();
        }
        public void AppStartup(object sender, StartupEventArgs e)
        {
            _bootstrapper.Initialize();
            var windowService = new WindowsService();
            windowService.ShowDialog(new ShellViewModel(), "Hai.....");
        }
    }
}
