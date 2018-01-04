using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App001.ViewModels
{
    public class ShellViewModel:Screen
    {
        private string _FirstName = "Jia Anu";

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                NotifyOfPropertyChange(nameof(FirstName));
            }
        }

    }
}
