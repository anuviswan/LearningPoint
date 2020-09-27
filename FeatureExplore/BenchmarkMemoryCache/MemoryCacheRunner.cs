using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;
using BenchmarkDotNet.Attributes;

namespace BenchmarkMemoryCache
{
    [MemoryDiagnoser]
    public class MemoryCacheRunner
    {
        private MemoryCache _memoryCache;
        private string _uniqueKey = "UniqueKey";
        public MemoryCacheRunner()
        {
            _memoryCache = new MemoryCache("DemoCache");
            _memoryCache.Add(_uniqueKey, new Foo { Name = "Anu Viswan", Age = 36 }, new CacheItemPolicy());
        }
        [Benchmark]
        public Foo GetFromCacheUsingContainsAndGet()
        {
            if (_memoryCache.Contains(_uniqueKey))
            {
                return (Foo)_memoryCache.Get(_uniqueKey);
            }

            var instance = new Foo { Name = "Anu Viswan", Age = 36 };
            _memoryCache.Add(_uniqueKey, instance, new CacheItemPolicy());
            return instance;
        }

        [Benchmark]
        public Foo GetFromCacheUsingAddOrGet()
        {
            var instance = new Foo { Name = "Anu Viswan", Age = 36 };
            return (Foo)_memoryCache.AddOrGetExisting(_uniqueKey, instance, new CacheItemPolicy());
        }
    }

    public class Foo
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
 
}
