using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkMappers.Poco;
using Mapster;

namespace BenchmarkMappers
{
    public class SingleEntityCompare
    {
        private IMapper _autoMapper;
        private SimpleObjectSource _source;
        private List<SimpleObjectSource> _sourceCollection;
        public SingleEntityCompare()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SimpleObjectSource, SimpleObjectDestination>();
            });

            _autoMapper = config.CreateMapper();

            _source = new SimpleObjectSource
            {
                Id= 1,
                Department = "Department",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            _sourceCollection = Enumerable.Range(1, 9999).Select(x => new SimpleObjectSource
            {
                Id = x,
                Department = $"Department {x}",
                FirstName = $"FirstName {x}",
                LastName =  $"LastName {x}"
            }).ToList();
        }

        [Benchmark]
        public void SingleEntityUsingAutomapper()
        {
            var result = _autoMapper.Map<SimpleObjectDestination>(_source);
        }

        [Benchmark]
        public void SingleEntityUsingMapster()
        {
            var result = _source.Adapt<SimpleObjectDestination>();
        }

        [Benchmark]
        public void CollectionUsingAutomapper()
        {
            var result = _autoMapper.Map<List<SimpleObjectDestination>>(_sourceCollection);
        }

        [Benchmark]
        public void CollectionUsingMapster()
        {
            var result = _sourceCollection.Adapt<List<SimpleObjectDestination>>();
        }
    }

}
