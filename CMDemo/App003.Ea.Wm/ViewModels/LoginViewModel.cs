using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App003.Ea.Wm.Contract;
using App003.Ea.Wm.Models;
using Caliburn.Micro;

namespace App003.Ea.Wm.ViewModels
{
    [Export(typeof(ILogin))]
    public class LoginViewModel : Screen, ILogin
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public LoginViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            
        }
        // Since this is a demo, we will always return true
        public bool Validate(string userName, string passWord)
        {
            _eventAggregator.PublishOnUIThread(new UserInfoModel(){UserName = userName});
            this.TryClose(dialogResult:true);
            return true;
        }

        
    }
}
