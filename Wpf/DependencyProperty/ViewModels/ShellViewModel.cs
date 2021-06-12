using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DependencyProperty.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
        }

        public async Task DisplayValueResolution()
        {
            await ActivateItemAsync(new ValueResolutionViewModel());
        }
    }
}
