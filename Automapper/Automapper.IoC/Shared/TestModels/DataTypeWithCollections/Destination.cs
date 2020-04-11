using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.TestModels.DataTypeWithCollections
{
    public class Destination
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public UserDefinedType Property3 { get; set; }
        public List<UserDefinedType> Property4 { get; set; }

        public static Destination GetInstance()
        {
            return new Destination
            {
                Property1 = $"{nameof(Destination)}.{nameof(Destination.Property1)}",
                Property2 = $"{nameof(Destination)}.{nameof(Destination.Property2)}",
                Property3 = new UserDefinedType
                {
                    Property1 = $"{nameof(Destination)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}",
                    Property2 = $"{nameof(Destination)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}"
                },
                Property4 = Enumerable.Range(1, 5).Select(x =>
                new UserDefinedType
                {
                    Property1 = $"{nameof(Destination)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property1)}[{x}]",
                    Property2 = $"{nameof(Destination)}.{nameof(UserDefinedType)}.{nameof(UserDefinedType.Property2)}[{x}]"
                }).ToList()
            };
        }

        public static Destination GetInstanceForIoC()
        {
            return new Destination
            {
                Property1 = $"IoC => {nameof(Destination)}.{nameof(Destination.Property1)}",
                Property2 = $"IoC => {nameof(Destination)}.{nameof(Destination.Property2)}",
                Property3 = UserDefinedType.GetInstanceForIoC(),
                Property4 = Enumerable.Range(1, 5).Select(x =>
                UserDefinedType.GetInstanceForIoC(x)).ToList()
            };
        }
    }
}
