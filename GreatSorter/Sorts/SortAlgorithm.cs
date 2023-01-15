using System;
using System.Linq;

namespace GreatSorter
{
    public abstract class SortAlgorithm<T>
        where T : IComparable
    {
        public string Name { get; private set; }

        private void SetName()
        {
            var className = GetType().Name;
            var nameWithSpaces = string.Concat(className.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
            Name = nameWithSpaces.Substring(0, nameWithSpaces.Length - 2);
        }

        public abstract SortableArray<T> Sort(T[] array);

        public override string ToString() => "Name";
    }
}