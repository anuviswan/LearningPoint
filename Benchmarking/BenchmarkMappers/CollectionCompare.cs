using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkMappers.Poco;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkMappers
{
    [RPlotExporter]
    public class CollectionCompare
    {
        private IMapper _autoMapper;
        private List<SimpleObjectSource> _simpleObjectSourceCollection;
        private List<ComplexObjectSource> _complexObjectSourceCollection;
        public CollectionCompare()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SimpleObjectSource, SimpleObjectDestination>();
                cfg.CreateMap<ComplexObjectSource, ComplexObjectDestination>();
            });

            _autoMapper = config.CreateMapper();

            _simpleObjectSourceCollection = Enumerable.Range(1, 999).Select(x => new SimpleObjectSource
            {
                Id = x,
                Department = $"Department {x}",
                FirstName = $"FirstName {x}",
                LastName = $"LastName {x}"
            }).ToList();

            _complexObjectSourceCollection = Enumerable.Range(1, 999).Select(x => new ComplexObjectSource
            {
                Id = 1,
                Values = Enumerable.Range(10, 100),
                ComplexCollection = Enumerable.Range(1, 10).Select(x => new ComplexObjectSource
                {
                    Id = 2,
                    Values = Enumerable.Range(1, 100),
                    ComplexCollection = Enumerable.Range(1, 10).Select(x => new ComplexObjectSource
                    {
                        Id = 3,
                        Values = Enumerable.Range(1, 100),
                        ComplexCollection = Enumerable.Empty<ComplexObjectSource>().ToList()
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        [Benchmark]
        public void SimpleCollectionUsingAutomapper()
        {
            var result = _autoMapper.Map<List<SimpleObjectDestination>>(_simpleObjectSourceCollection);
        }

        [Benchmark]
        public void SimpleCollectionUsingMapster()
        {
            var result = _simpleObjectSourceCollection.Adapt<List<SimpleObjectDestination>>();
        }

        [Benchmark]
        public void ComplexCollectionUsingAutomapper()
        {
            var result = _autoMapper.Map<List<ComplexObjectDestination>>(_complexObjectSourceCollection);
        }

        [Benchmark]
        public void ComplexCollectionUsingMapster()
        {
            var result = _complexObjectSourceCollection.Adapt<List<ComplexObjectDestination>>();
        }
    }
}
