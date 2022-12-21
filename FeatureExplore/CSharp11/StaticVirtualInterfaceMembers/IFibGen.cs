namespace StaticVirtualInterfaceMembers
{
    public interface ISequenceGenerator<T>  where T : ISequenceGenerator<T>
    {
        static abstract T Zero { get; }

        static abstract T One { get; }
       
        static abstract T operator ++(T val);
    }


   

    public struct ValGen : ISequenceGenerator<ValGen>
    {

        public int Value { get; set; }

        public static ValGen Zero => new ValGen { Value = 0 };
        public static ValGen One => new ValGen { Value = 1 };
        public static ValGen operator ++(ValGen val)
        {
            return val with { Value = val.Value + 1 };
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }


    public struct FibonacciGenerator : ISequenceGenerator<FibonacciGenerator>
    {
        public int Previous { get; init; }
        public int Current { get; init; }
        public override string ToString() => Current.ToString();

        public static FibonacciGenerator Zero => new FibonacciGenerator { Current = 0, Previous = 0 };

        public static FibonacciGenerator One => new FibonacciGenerator { Current = 1, Previous = 0 };

        public static FibonacciGenerator operator ++(FibonacciGenerator val)
        {
            if (val.Equals(FibonacciGenerator.Zero))
                return FibonacciGenerator.One;
            else
                return val with 
                { 
                    Previous = val.Current,
                    Current = val.Previous + val.Current
                };
        }
    }
}
