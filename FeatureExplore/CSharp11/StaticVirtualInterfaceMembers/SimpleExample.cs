namespace StaticVirtualInterfaceMembers
{
    public interface INumeric<TDerieved> where TDerieved : INumeric<TDerieved>  
    {
        static abstract TDerieved Zero { get; }
        static abstract TDerieved One { get; }

        static TDerieved Average(TDerieved a, TDerieved b) => (a + b)/ (TDerieved.One + TDerieved.One); 
        static abstract TDerieved operator +(TDerieved a, TDerieved b);

        static abstract TDerieved operator /(TDerieved a, TDerieved b);
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
