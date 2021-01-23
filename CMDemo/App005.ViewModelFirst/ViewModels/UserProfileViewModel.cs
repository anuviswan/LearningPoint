using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace App005.ViewModelFirst.ViewModels
{
    public class UserProfileViewModel:PropertyChangedBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
