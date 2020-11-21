using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Validations.ViewModels
{
    public class NotifyDataErrorInfoViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private IDictionary<string, List<string>> _errors = new Dictionary<string,List<string>>();

        public override string Title => "INotifyDataErrorInfo";
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


        public override int Age
        {
            get => base.Age;
            set
            {
                if(base.Age == value) return;

                base.Age = value;
                NotifyOfPropertyChange();
                Validate();
            }
        }
        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void Validate([CallerMemberName] string propertyName=null)
        {
            var error = propertyName switch
            {
                nameof(Name) when Name is { Length: < 3 or > 9 } => "Name should be min 3 characters and Max 9 characters",
                nameof(Age) when (Age < 0 || Age > 100) => "Age should be between 0 and 100",
                _ => null
            };

            if (error != null)
            {
                _errors[propertyName] = new List<string>{ error };
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                return;
            }

            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName)) return _errors[propertyName];
            return null;
        }
    }
}
