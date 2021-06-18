using System;

namespace DynamicMappingPattern
{
    public class ProductForAttribute:Attribute
    {
        public Type ClientType { get; set; }
        public ProductForAttribute(Type clientType) => ClientType = clientType;
        
    }
}
