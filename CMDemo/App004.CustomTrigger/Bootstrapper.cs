using App004.CustomTrigger.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace App004.CustomTrigger
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        #endregion

        protected override void Configure()
        {
            var defaultCreateTrigger = Parser.CreateTrigger;

            Parser.CreateTrigger = (target, triggerText) =>
            {
                if (string.IsNullOrEmpty(triggerText)) return defaultCreateTrigger(target, null);

                var regex = new Regex(@"^\[(?<Action>[a-zA-Z]+)\s(?<Shortcut>[a-zA-Z0-9]+)\]$");
                var matches = regex.Match(triggerText.Trim());
                

                switch (matches.Groups["Action"].Value.ToLower())
                {
                    case "key":
                        return new KeyTrigger
                        {
                            Key = (Key)Enum.Parse(typeof(Key), matches.Groups["Shortcut"].Value, true),
                        };
                    default:
                        return defaultCreateTrigger(target, triggerText); ;
                }

            };
        }
    }
}
