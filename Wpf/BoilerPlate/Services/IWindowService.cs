using BoilerPlate.ControlBase;

namespace BoilerPlate.Services
{
    public interface IWindowService
    {
        bool? ShowDialog(ViewModelBase viewModel, string title);
    }
}
