using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class Sorter<T>
        where T: IComparable
    {
        T[] Array { get; }
        private ISortAlgoritm algoritm;
        private TimeSpan execute;

        public Sorter(T[] array, ISortAlgoritm algoritm)
        {
            Array = array;
            this.algoritm = algoritm;
        }

        public IEnumerable<T[]> GetLog()
        {
            return algoritm.Sort(Array);
        }

        public T[] GetResult()
        {
            return algoritm.Sort(Array).Last();
        }
    }

    public interface ISortAlgoritm
    {
        IEnumerable<T[]> Sort<T>(T[] array)
            where T : IComparable;
    }
}
