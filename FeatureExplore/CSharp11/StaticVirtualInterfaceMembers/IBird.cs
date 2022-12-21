namespace StaticVirtualInterfaceMembers
{
    public interface IBird<TDerieved>
    {
        static abstract bool CanFly();
        TDerieved Clone();
    }

    public class Parrot : IBird<Parrot>
    {
        public static bool CanFly() => true;

        public Parrot Clone()
        {
            return new Parrot(); // Assume this to be clone
        }
    }
    public class Kiwi : IBird<Kiwi>
    {
        public static bool CanFly() => false;

        public Kiwi Clone()
        {
            return new Kiwi(); // assume this to be clone
        }
    }
}
