using System;
using System.Linq;

namespace GreatSorter
{
    public abstract class SortAlgorithm<T>
        where T : IComparable
    {
        public string Name { get; private set; }
        public SortableArray<T> SortableArray { get; private set; }

        protected SortAlgorithm(T[] array)
        {
            SortableArray = new SortableArray<T>(array);
            SetName();
        }

        public void SetArray(T[] array)
        {
            SortableArray = new SortableArray<T>(array);
        }

        private void SetName()
        {
            var className = GetType().Name;
            var nameWithSpaces = string.Concat(className.Select(x => char.IsUpper(x) ? " " + x : x.ToString()))
                .TrimStart(' ');
            Name = nameWithSpaces.Substring(0, nameWithSpaces.Length - 2);
        }

        public abstract void Sort();

        public override string ToString() => "Name";
    }
}