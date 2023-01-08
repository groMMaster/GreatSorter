using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public static class SortingFactory
    {
        public static SortAlgorithm<T> CreateSort<T>(string text, T[] array)
            where T : IComparable
        {
            switch (text)
            {
                case "Bubble Sort":
                    return new BubbleSort<T>(array);
                case "Gnome Sort":
                    return new GnomeSort<T>(array);
                case "Quick Sort":
                    return new QuickSort<T>(array);
                case "Selection Sort":
                    return new SelectionSort<T>(array);
                case "Stooge Sort":
                    return new StoogeSort<T>(array);
            }

            throw new ArgumentException(String.Format("this type of sorting: {0} does not exist", text));
        }
    }
}
