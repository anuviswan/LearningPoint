using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace PolymorphicParameterBinding.Models
{
    public abstract class Shape // : IParsable<TDerieved> where TDerieved : IParsable<TDerieved>
    {
    }


    public class Rectangle : Shape, IParsable<Rectangle> 
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }


        public static Rectangle Parse(string s, IFormatProvider? provider)
        {
            try
            {
                return JsonConvert.DeserializeObject<Rectangle>(s);
            }
            catch
            {
                throw;
            }
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Rectangle result)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                result = null;
                return false;
            }

            try
            {
                result = JsonConvert.DeserializeObject<Rectangle>(s);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }

    public class Triangle : Shape, IParsable<Triangle> 
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }
        public int Id { get; set; }

        public static Triangle Parse(string s, IFormatProvider? provider)
        {
            try
            {
                return JsonConvert.DeserializeObject<Triangle>(s);
            }
            catch
            {
                throw;
            }
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Triangle result)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                result = null;
                return false;
            }

            try
            {
                result = JsonConvert.DeserializeObject<Triangle>(s);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
