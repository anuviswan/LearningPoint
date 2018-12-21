using App004.CustomTrigger.ViewModels;
using Caliburn.Micro;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace App004.CustomTrigger
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Private Variables
        private const string X_ACTION = "ACTION";
        private const string X_KEY = "KEY";
        private const string X_SHORTCUT = "SHORTCUT";
        #endregion

        #region Constructor
        public Bootstrapper() => Initialize();
        #endregion

        #region Overrides
        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<ShellViewModel>();
        #endregion

        protected override void Configure()
        {
            var defaultCreateTrigger = Parser.CreateTrigger;

            Parser.CreateTrigger = (target, triggerText) =>
            {
                if (string.IsNullOrEmpty(triggerText)) return defaultCreateTrigger(target, null);

                var regex = new Regex($@"^\[(?<{X_ACTION}>[a-zA-Z]+)\s(?<{X_SHORTCUT}>[a-zA-Z0-9]+)\]$");
                var matches = regex.Match(triggerText.Trim());

                switch (matches.Groups[X_ACTION].Value.ToUpper())
                {
                    case X_KEY:
                        return new KeyTrigger
                        {
                            Key = (Key)Enum.Parse(typeof(Key), matches.Groups[X_SHORTCUT].Value, true),
                        };
                    default:
                        return defaultCreateTrigger(target, triggerText); ;
                }
            };
        }
    }
}
