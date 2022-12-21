namespace StaticVirtualInterfaceMembers
{
    public interface INumeric<T> where T : INumeric<T>  
    {
        static abstract T Zero { get; }
        static abstract T One { get; }

        static T Average(T a, T b) => (a + b)/ (T.One + T.One); 
        static abstract T operator +(T a, T b);

        static abstract T operator /(T a, T b);
    }


    public record CustomNumber : INumeric<CustomNumber>
    {
        public int Value { get; set; }
        public static CustomNumber Zero => new() { Value = 0};

        public static CustomNumber One => new() { Value = 1 };

        public static CustomNumber operator +(CustomNumber a, CustomNumber b)
        {
            return  a with {  Value = a.Value + b.Value };
        }

        public static CustomNumber operator /(CustomNumber a, CustomNumber b)
        {
            if(b.Equals(Zero))
            {
                throw new ArgumentException("Divide by Zero exception");
            }

            return a with { Value = a.Value / b.Value };
        }
    }
}
