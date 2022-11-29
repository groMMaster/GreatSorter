using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public abstract class Sortable<T>
    {
        public Observer Observer;
        public abstract T[] Sort(T[] array);
    }

    public class Observer
    {

    }
}
