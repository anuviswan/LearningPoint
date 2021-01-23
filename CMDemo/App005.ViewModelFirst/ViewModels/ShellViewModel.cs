using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace App005.ViewModelFirst.ViewModels
{
    public class ShellViewModel:Conductor<object>
    {
        public UserProfileViewModel UserProfile { get; set; }

        public IEnumerable<UserProfileViewModel> UserProfileCollection { get; set; }
        public ShellViewModel()
        {
            UserProfile = IoC.Get<UserProfileViewModel>();
            UserProfile.Name = "Anu Viswan";
            UserProfile.Age = 37;

            UserProfileCollection = Enumerable.Range(1, 10).Select(x => new UserProfileViewModel { Name = $"Sample Name {x}", Age = 37 + x });
        }
    }
}
