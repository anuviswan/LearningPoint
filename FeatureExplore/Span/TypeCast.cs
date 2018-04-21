using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span
{
    public class TypeCast
    {
        public void TypeCastPrimitiveTypes()
        {
            long originalPrimitiveType = long.MaxValue;
            Span<byte> byteSpan = BitConverter.GetBytes(originalPrimitiveType);
            Span<int> intSpan = byteSpan.NonPortableCast<byte, int>();
            int castPrimitiveType = intSpan[0];
            Console.WriteLine($"Primitive Test : OriginalValue (long) = {originalPrimitiveType}, Cast Value (int) = {castPrimitiveType}");

            var structInstance = new ValueStruct(25, 01);
            byteSpan = BitConverter.GetBytes(structInstance.Property1);
            intSpan = byteSpan.NonPortableCast<byte, int>();
            int castStructType = intSpan[0];
            Console.WriteLine($"Struct Test : OriginalValue (long) = {structInstance.Property1}, Cast Value (int) = {castStructType}");

            Console.ReadLine();
        }

        struct ValueStruct
        {
            public long Property1 { get; set; }
            public int Property2 { get; set; }

            public ValueStruct(long property1,int property2)
            {
                Property1 = property1;
                Property2 = property2;
            }
        }
    }
}
