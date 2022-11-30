﻿using System;
using System.Collections.Generic;

namespace GreatSorter
{
    public class BubbleSort : ISortAlgoritm
    {
        public IEnumerable<T[]> Sort<T>(T[] array)
            where T: IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        array.Swap(i, j);
                        yield return array;
                    }
                }
            }
        }
    }
}