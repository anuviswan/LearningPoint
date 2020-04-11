using NUnit.Framework;
using Shared.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.TestCases
{
    public class ValueMapperTests
    {

        public void MapperDataTypeWithCollections(IValueMapper valueMapper)
        {
            var destinationFromIoC = Shared.TestModels.DataTypeWithCollections.Destination.GetInstanceForIoC();
            var userDefinedTypeFromIoC = Shared.TestModels.DataTypeWithCollections.UserDefinedType.GetInstanceForIoC();

            var source = Shared.TestModels.DataTypeWithCollections.Source.GetInstance();
            var destination = valueMapper.Map<Shared.TestModels.DataTypeWithCollections.Source, Shared.TestModels.DataTypeWithCollections.Destination>(source);

            Assert.AreNotSame(source, destination);
            Assert.AreEqual(source.Property1, destination.Property1);

            Assert.AreNotEqual(source.Property2, destination.Property2);
            Assert.AreEqual(destinationFromIoC.Property2, destination.Property2);

            Assert.AreNotSame(source.Property3, destination.Property3);
            Assert.AreEqual(source.Property3.Property1, destination.Property3.Property1);
            Assert.AreNotEqual(source.Property3.Property2, destination.Property3.Property2);
            Assert.AreEqual(userDefinedTypeFromIoC.Property2, destination.Property3.Property2);

            CollectionAssert.AreNotEqual(source.Property4, destination.Property4);
            Assert.AreNotSame(source.Property4, destination.Property4);
            for (int i = 0; i < source.Property4.Count; i++)
            {
                Assert.AreNotSame(source.Property4[i], destination.Property4[i]);
                Assert.AreEqual(source.Property4[i].Property1, destination.Property4[i].Property1);
                Assert.AreNotEqual(source.Property4[i].Property2, destination.Property4[i].Property2);
                Assert.AreEqual(userDefinedTypeFromIoC.Property2, destination.Property4[i].Property2);
            }
        }
    }
}
