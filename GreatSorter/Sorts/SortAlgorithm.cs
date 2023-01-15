using System;
using System.Linq;

namespace GreatSorter
{
    public abstract class SortAlgorithm<T>
        where T : IComparable
    {
        public string Name { get; private set; }

        protected SortAlgorithm()
        {
            SetName();
        }

        private void SetName()
        {
            var className = GetType().Name;
            var nameWithSpaces = string.Concat(className.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
            Name = nameWithSpaces.Substring(0, nameWithSpaces.Length - 2);
        }

        public SortableArray<T> Sort(T[] array)
        {
            return Sort(new SortableArray<T>(array));
        }

        protected abstract SortableArray<T> Sort(SortableArray<T> array);
    }
}