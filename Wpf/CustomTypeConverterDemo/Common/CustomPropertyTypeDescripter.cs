using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTypeConverterDemo.Common
{
    public class CustomPropertyTypeDescripter : PropertyDescriptor
    {
        public CustomPropertyTypeDescripter(string name, Attribute[] attrs) : base(name, attrs)
        {
        }

        public override Type ComponentType => throw new NotImplementedException();

        public override bool IsReadOnly => throw new NotImplementedException();

        public override Type PropertyType => throw new NotImplementedException();

        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldSerializeValue(object component)
        {
            throw new NotImplementedException();
        }
    }
}
