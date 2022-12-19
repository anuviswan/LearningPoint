namespace StaticVirtualInterfaceMembers
{
    public interface IBar
    {
        string Name { get; set; }

        public string GetName() => Name ?? $"Cannot find {nameof(Name)}";
    }

    public class Bar : IBar
    {
        public string Name { get; set; }
    }

    public class FooBar : IBar
    {
        public string Name { get; set; }

        public string GetName() => "Bar";
    }
}
