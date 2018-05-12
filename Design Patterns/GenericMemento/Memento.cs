using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMemento
{
    public class Memento<TSource>
    {
        private byte[] _state;

        public Memento(TSource data)
        {
            using(var stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<TSource>(stream, data);
                _state = stream.ToArray();
            }
        }

        public TSource Value
        {
            get
            {
                using(var stream = new MemoryStream(_state))
                {
                    return ProtoBuf.Serializer.Deserialize<TSource>(stream);
                }
            }
        }
    }
}
