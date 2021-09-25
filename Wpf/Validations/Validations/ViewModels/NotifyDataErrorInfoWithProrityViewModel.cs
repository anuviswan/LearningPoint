using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validations.ViewModels
{
    public class NotifyDataErrorInfoWithProrityViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private IDictionary<string, List<ErrorInfo>> _errors = new Dictionary<string, List<ErrorInfo>>();

        public override string Title => "INotifyDataErrorWithProrityInfo";
        public override string Name
        {
            get => base.Name;
            set
            {
                if (Equals(base.Name, value)) return;

                base.Name = value;
                NotifyOfPropertyChange();
                Validate();
            }
        }

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void Validate([CallerMemberName] string propertyName = null)
        {

            var errorList = new List<ErrorInfo>();

            if (Equals(propertyName, nameof(Name)))
            {

                if (CheckIfNameExists(Name))
                {
                    errorList.Add(new ErrorInfo
                    {
                        Message = "IserName already exists",
                        Priority = Prority.High
                    });
                }

                if (Name is { Length: < 3 or > 9 })
                {
                    errorList.Add(new ErrorInfo
                    {
                        Message = "UserName should be min 3 characters and Max 9 characters",
                        Priority = Prority.Low
                    });
                }

                if (!Name.All(x=>char.IsLetterOrDigit(x)))
                {
                    errorList.Add(new ErrorInfo
                    {
                        Message = "Username should contain only alphanumeric characters",
                        Priority = Prority.Medium
                    });
                }
            }


            if (errorList.Any())
            {
                _errors[propertyName] = errorList;
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                return;
            }

            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);
        }

        private bool CheckIfNameExists(string name)
        {
            return true;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName)) return _errors[propertyName];
            return null;
        }
    }

    public class ErrorInfo
    {
        public string Message { get; set; }
        public Prority Priority { get; set; }
    }

    public enum Prority
    {
        Low,
        Medium,
        High
    } 
}
