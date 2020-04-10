using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.TestModels.DataTypeWithCollections
{
    public class Source
    {
        public string Property1 { get; set; }
        [IgnoreDataMember]
        public string Property2 { get; set; }
        public UserDefinedType Property3 { get; set; }
        public List<UserDefinedType> Property4 { get; set; }

        public static Source GetInstance()
        {
            return new Source
            {
                Property1 = $"{nameof(Source)}.{nameof(Source.Property1)}",
                Property2 = $"{nameof(Source)}.{nameof(Source.Property2)}",
                Property3 = new UserDefinedType 
                { 
                    Property1 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}", 
                    Property2 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}" 
                },
                Property4 = Enumerable.Range(1, 5).Select(x =>
                new UserDefinedType
                {
                    Property1 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}[{x}]",
                    Property2 = $"{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}[{x}]"
                }).ToList()
            };
        }

        public static Source GetInstanceForIoC()
        {
            return new Source
            {
                Property1 = $"IoC=>{nameof(Source)}.{nameof(Source.Property1)}",
                Property2 = $"IoC=>{nameof(Source)}.{nameof(Source.Property2)}",
                Property3 = new UserDefinedType
                {
                    Property1 = $"IoC=>{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}",
                    Property2 = $"IoC=>{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}"
                },
                Property4 = Enumerable.Range(1, 5).Select(x =>
                new UserDefinedType
                {
                    Property1 = $"IoC=>{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}[{x}]",
                    Property2 = $"IoC=>{nameof(Source)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}[{x}]"
                }).ToList()
            };
        }

    }
}
