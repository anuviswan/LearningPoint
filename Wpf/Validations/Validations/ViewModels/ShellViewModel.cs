using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace Validations.ViewModels
{
    public  class ShellViewModel:Conductor<object>
    {
        public void ShowDefaultValidations()
        {
            ChangeActiveItem(new DefaultViewModel(),true);
        }
    }
}
