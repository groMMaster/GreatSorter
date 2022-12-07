using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public interface IObserver
    {
        void Update(object sender, object eventData);
    }
}
