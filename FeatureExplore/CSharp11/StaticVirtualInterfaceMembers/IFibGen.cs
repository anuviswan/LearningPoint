using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticVirtualInterfaceMembers
{
    public interface IGen<T>  where T : IGen<T>
    {
        static abstract T operator ++(T val);
    }


   

    public struct ValGen : IGen<ValGen>
    {
        public int Value { get; set; }
        public static ValGen operator ++(ValGen val)
        {
            return val with { Value = val.Value + 1 };
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }


    public struct FibGen : IGen<FibGen>
    {
        public int Previous { get; set; }

        public int Current { get; set; }


        public override string ToString()
        {
            return Current.ToString();
        }

        public static FibGen operator ++(FibGen val)
        {
            return val with 
            { 
                Previous = val.Current,
                Current = val.Previous + val.Current 
            };
        }
    }

    //public class Fibonacii : IFibGen<Fibonacii>
    //{
    //    public int Value { get; set; }
    //    public static Fibonacii operator ++(Fibonacii first, Fibonacii second) 
    //    { 
    //        return default; 
    //    }
    //}
}
