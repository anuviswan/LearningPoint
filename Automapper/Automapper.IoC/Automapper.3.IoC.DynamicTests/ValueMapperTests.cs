using NUnit.Framework;
using Automapper._3.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Resources;

namespace Automapper._3.IoC.Tests
{
    [TestFixture()]
    public class ValueMapperTests
    {
        private Func<Type, string, object> _iocInstance;
        [SetUp]
        public void SetupTest()
        {
            _iocInstance = Caliburn.Micro.IoC.GetInstance;
            Caliburn.Micro.IoC.GetInstance = (type, _) =>
            {
                if (type == typeof(Shared.TestModels.DataTypeWithCollections.Destination))
                {
                    return Shared.TestModels.DataTypeWithCollections.Destination.GetInstanceForIoC();
                }

                if (type == typeof(Shared.TestModels.DataTypeWithCollections.UserDefinedType))
                {
                    return Shared.TestModels.DataTypeWithCollections.UserDefinedType.GetInstanceForIoC();
                }
                return null;
            };
        }
        [TearDown]
        public void Cleanup()
        {
            Caliburn.Micro.IoC.GetInstance = _iocInstance;
        }
        [Test]
        public void MapperDataTypeWithCollections()
        {
            var destinationFromIoC = Shared.TestModels.DataTypeWithCollections.Destination.GetInstanceForIoC();
            var userDefinedTypeFromIoC = Shared.TestModels.DataTypeWithCollections.UserDefinedType.GetInstanceForIoC();

            var valueMapper = new ValueMapper();
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