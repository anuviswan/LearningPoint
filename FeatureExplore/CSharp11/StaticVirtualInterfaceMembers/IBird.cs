namespace StaticVirtualInterfaceMembers
{
    public interface IBird
    {
        static abstract bool CanFly();
    }

    public class Parrot : IBird
    {
        public static bool CanFly() => true;
    }
    public class Kiwi : IBird
    {
        public static bool CanFly() => false;
    }
}
