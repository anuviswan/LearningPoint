namespace StaticVirtualInterfaceMembers
{
    public interface IBird<TDerieved>
    {
        static abstract bool CanFly();
    }

    public class Parrot : IBird<Parrot>
    {
        public static bool CanFly() => true;

    }
    public class Kiwi : IBird<Kiwi>
    {
        public static bool CanFly() => false;
    }
}
