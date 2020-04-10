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
                if(type == typeof(Models.TestModels.DataTypeWithCollections.Destination))
                {
                    return Models.TestModels.DataTypeWithCollections.Destination.GetInstance();
                }
                return null;
            };
        }
        [TearDown]
        public void Cleanup()
        {
            Caliburn.Micro.IoC.GetInstance = _iocInstance;
        }
        [Test()]
        public void MapperDataTypeWithCollections()
        {
            var valueMapper = new ValueMapper();
            var source = Models.TestModels.DataTypeWithCollections.Source.GetInstance();
            var destination = valueMapper.Map<Models.TestModels.DataTypeWithCollections.Source,Models.TestModels.DataTypeWithCollections.Destination>(source);
                        
            Assert.AreNotSame(source, destination);
            Assert.AreEqual(source.Property1, destination.Property1);
            Assert.AreNotEqual(source.Property2, destination.Property2);
            Assert.AreNotSame(source.Property3, destination.Property3);
            Assert.AreEqual(source.Property3.Property1, destination.Property3.Property1);
            Assert.AreEqual(source.Property3.Property2, destination.Property3.Property2);
            Assert.AreNotSame(source.Property4, source.Property4);
        }
    }
}