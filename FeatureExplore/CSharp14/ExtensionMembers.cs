using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp14;

internal static class ExtensionMembers
{
    extension<T>(SpecialList<T> source)
    {
        public int Count => source.Items.Count;

        public void Insert(int index, T item)
        {
            if (index < 0 || index > source.Items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            source.Items.Insert(index, item);
        }
    }

    extension<T>(SpecialList<T>)
    {
        public static bool IsEmpty(IEnumerable<T> source) => !source.Any();
    }

    public static void InsertOne<T>(this SpecialList<T> source, int index, T item)
    {
                if (index < 0 || index > source.Items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        source.Items.Insert(index, item);
    }

}

internal sealed class SpecialList<T>
{
    public List<T> Items { get; private set; } = new List<T>();
    public void Add(T item)
    {
        Items.Add(item);    
    }
}


/* Output
1
2
3
3
4
Count: 5
IsEmpty: False
 */