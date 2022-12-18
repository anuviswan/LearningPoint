namespace StaticVirtualInterfaceMembers
{
    public interface ISequenceGenerator<T>  where T : ISequenceGenerator<T>
    {
        static abstract T operator ++(T val);
    }


   

    public struct ValGen : ISequenceGenerator<ValGen>
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


    public struct FibonacciGenerator : ISequenceGenerator<FibonacciGenerator>
    {
        public int Previous { get; init; }
        public int Current { get; init; }
        public override string ToString() => Current.ToString();

        public static FibonacciGenerator operator ++(FibonacciGenerator val)
        {
            if (val is { Previous: 0, Current: 0})
                return val with { Current = 1 };
            else
                return val with 
                { 
                    Previous = val.Current,
                    Current = val.Previous + val.Current
                };
        }
    }
}
