using BoilerPlate.ControlBase;
using System;
using System.Linq;
using System.Windows;

namespace BoilerPlate.Services
{
    public class WindowsService : IWindowService
    {
        public bool? ShowDialog(ViewModelBase viewModel, string title)
        {
            var viewModelType = viewModel.GetType();
            var view = GetViewForViewModel(viewModelType);
            if (view is Window win)
            {
                win.DataContext = viewModel;
                win.Title = title;
                return win.ShowDialog();
            }
            else
            {
                var windowDialog = new Window();
                windowDialog.Title = title;
                return windowDialog.ShowDialog();
            }

        }

        private object? GetViewForViewModel(Type type)
        {
            var viewName = type.Name[..^5];
            var view = type.Assembly.GetTypes().Where(x => string.Equals(x.Name, viewName));
            if (view.Any())
            {
                var viewInstance = Activator.CreateInstance(view.First());
                return viewInstance;
            }
            return null;
        }
    }
}
