using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetNullValueVsFallbackValue.ViewModels
{
    public class ShellViewModel
    {

        public string UserName { get; set; }
        public DateTime? DateOfBirth { get; set; } = null;
    }
}
