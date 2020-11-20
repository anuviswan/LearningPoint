using System.ComponentModel;

namespace Validations.ViewModels
{
    public class DataErrorInfoViewModel : ViewModelBase, IDataErrorInfo
    {
        public override string Title => "IDataErrorInfo"; 
        public string this[string columnName]
        {
            get
            {
                return columnName switch
                {
                    nameof(Name) when (Name is { Length: < 3 or > 100 }) => "Name should have min 3 characters and Max 9",
                    nameof(Age) when Age < 0 || Age > 100 => "Age Should be between 0 and 100",
                    _ => string.Empty
                };
            }
        }

        public string Error => null;
    }
}
