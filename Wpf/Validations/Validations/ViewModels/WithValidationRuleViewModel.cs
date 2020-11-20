using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Validations.ViewModels
{
    public class WithValidationRuleViewModel:ViewModelBase
    {
        public override string Title => "With Validation Rule";
    }

    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string { Length: <3 or >10 })
            {
                return new ValidationResult(false, "Name should have min 3 characters and max 9");
            }

            return new(true, string.Empty);
        }
    }

    public class AgeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!Int32.TryParse((string)value,out var intValue)) return new (false,"Age should be a number");

            return intValue switch
            {
                < 0 => new(false, "Age cannot be less than 0"),
                > 100 => new(false, "Let us be practical"),
                _ => new(true, string.Empty)
            };
        }
    }
}
