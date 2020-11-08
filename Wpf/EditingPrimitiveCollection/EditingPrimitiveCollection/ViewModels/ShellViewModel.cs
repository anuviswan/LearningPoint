using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingPrimitiveCollection.ViewModels
{
    public class ShellViewModel:Screen
    {
        public IEnumerable<Entity<string>> MyCollection { get; set; } = Enumerable.Empty<Entity<string>>();

        public void Add()
        {
            var g = MyCollection;
            MyCollection = g.Concat(new List<Entity<string>> { new Entity<string>() });
            NotifyOfPropertyChange(nameof(MyCollection));
        }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(
            this IEnumerable<T> source, params T[] tail)
        {
            return source.Concat(tail);
        }
    }

    public class Entity<T>
    {
        private T _value;
        System.Action OnValueChanged { get; set; }
        public T Value 
        {
            get => _value;
            set
            {
                if (!Equals(value, _value))
                {
                    return;
                }

                _value = value;
                NotifyProper
            }

        }
    }
}
