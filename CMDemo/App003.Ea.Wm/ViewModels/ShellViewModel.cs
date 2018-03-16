using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using App003.Ea.Wm.Contract;
using App003.Ea.Wm.Models;
using Caliburn.Micro;

namespace App003.Ea.Wm.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Screen, IShell, IHandle<UserInfoModel>
    {
        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager,ILogin loginWindow, IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);

            _windowManager = windowManager;
            _loginWindow = loginWindow;

        }

        public override void CanClose(Action<bool> callback)
        {
            callback(false);
        }

        private string _userName  = default;
        private readonly IWindowManager _windowManager;
        private readonly ILogin _loginWindow;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                NotifyOfPropertyChange(nameof(UserName));
            }
        }

        public void PromptForLogin() => _windowManager.ShowDialog(_loginWindow);

        public void Handle(UserInfoModel message)
        {
            this.UserName = message.UserName;
        }
    }
}
