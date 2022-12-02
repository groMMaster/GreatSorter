using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public interface IObserver
    {
        void Update(int[] eventData);
    }
}
