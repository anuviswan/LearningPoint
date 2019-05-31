using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class MySingleton
    {
        private static readonly Lazy<MySingleton> _instance = new Lazy<MySingleton>(() => new MySingleton());

        public static MySingleton GetInstance()
        {
            return _instance.Value;
        }

        public int Value { get; set; }
    }
}
