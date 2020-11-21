using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Validations.ViewModels
{
    public class Model
    {
        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(9, MinimumLength = 3, ErrorMessage = "Name should have min 3 characters and max 9")]
        public string Name { get; set; }
        [Required]
        [Range(0,100,ErrorMessage = "Age should be between 1 and 100")]
        public int Age { get; set; }
    }
    public class DataAnnotionViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private IDictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private Model _model = new ();

        public override string Title => "Data Annotation and INotifyDataErrorInfo";
        public override string Name
        {
            get => _model.Name;
            set
            {
                if (Equals(_model.Name, value)) return;

                _model.Name = value;
                NotifyOfPropertyChange();
                Validate(value);
            }
        }


        public override int Age
        {
            get => _model.Age;
            set
            {
                if (_model.Age == value) return;

                _model.Age = value;
                NotifyOfPropertyChange();
                Validate(value);
            }
        }

        private void Validate(object val, [CallerMemberName] string propertyName = null)
        {
            if (_errors.ContainsKey(propertyName)) _errors.Remove(propertyName);

            ValidationContext context = new ValidationContext(_model) { MemberName = propertyName };
            List<ValidationResult> results = new();

            if (!Validator.TryValidateProperty(val, context, results))
            {
                _errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }
    }
}
