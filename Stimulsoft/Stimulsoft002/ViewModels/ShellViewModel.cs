using Caliburn.Micro;
using Stimulsoft002.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stimulsoft002.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel:Screen, IShellViewModel
    {
    }
}
