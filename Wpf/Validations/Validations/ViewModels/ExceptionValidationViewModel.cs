using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validations.ViewModels
{
    public class ExceptionValidationViewModel: ViewModelBase
    {
        public override string Title => "Exception Rule Validation";

        public override string Name
        {
            get => base.Name;
            set
            {
                if (Equals(base.Name, value)) return;

                base.Name = value;
                NotifyOfPropertyChange();
                if (Name is string { Length: < 3 or > 10 })
                    throw new Exception("Name should have min 3 characters and max 9");
            }
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (Age == value) return;

                base.Age = value;
                NotifyOfPropertyChange();
                if (Age < 0 || Age > 100)
                    throw new Exception("Age should be between 0 and 100");
            }
        }
    }
}
