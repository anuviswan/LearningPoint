using System;

namespace BoilerPlate.Bootstrap;

public static class IoC
{
    public static Func<Type,object> GetInstance { get; set; }

    public static T Get<T>()
    {
        return (T)GetInstance(typeof(T));
    }
}
