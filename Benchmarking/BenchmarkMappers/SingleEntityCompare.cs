using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkMappers.Poco;
using Mapster;

namespace BenchmarkMappers
{
    [RPlotExporter,MarkdownExporter,CsvExporter]
    public class SingleEntityCompare
    {
        private IMapper _autoMapper;
        private SimpleObjectSource _simpleSource;
        private ComplexObjectSource _complexSource;
        public SingleEntityCompare()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SimpleObjectSource, SimpleObjectDestination>();
                cfg.CreateMap<ComplexObjectSource, ComplexObjectDestination>();
            });

            _autoMapper = config.CreateMapper();

            _simpleSource = new SimpleObjectSource
            {
                Id = 1,
                Department = "Department",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            _complexSource = new ComplexObjectSource
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
            };

        }

        [Benchmark]
        public void SingleEntitySimpleObjectUsingAutomapper()
        {
            var result = _autoMapper.Map<SimpleObjectDestination>(_simpleSource);
        }

        [Benchmark]
        public void SingleEntitySimpleObjectUsingMapster()
        {
            var result = _simpleSource.Adapt<SimpleObjectDestination>();
        }

        [Benchmark]
        public void SingleEntityComplexObjectUsingAutomapper()
        {
            var result = _autoMapper.Map<ComplexObjectDestination>(_complexSource);
        }

        [Benchmark]
        public void SingleEntityComplexObjectUsingMapster()
        {
            var result = _complexSource.Adapt<ComplexObjectDestination>();
        }


    }

}
