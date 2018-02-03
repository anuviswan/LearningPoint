using App002.Contracts;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App002.ViewModels
{
    public class ShellViewModel : Screen, IShellViewModel
    {
        private string _Message;

        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                NotifyOfPropertyChange(nameof(Message));
            }
        }

        public void SayHello()
        {
            this.Message = "Hello World !!";
        }

        public ShellViewModel()
        {
            this.SayHello();
        }
    }
}
