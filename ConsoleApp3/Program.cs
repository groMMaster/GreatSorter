using System;

using GreatSorter;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var firstSort = new BubbleSort<int>(new int[]{});

            var randomArray = new Random().CreateArray(5);


            var firstLogger = new SortLogger<int>((int[])randomArray.Clone());

            firstSort.SetArray(randomArray);
            // secondSort.SetArray((int[])randomArray.Clone());

            firstSort.SortableArray.RegisterObserver(firstLogger);

            firstSort.Sort();

            var timer = new System.Windows.Forms.Timer();
            int time = 0;

            timer.Tick += (sender, args) =>
            {
                time++;
            };
        }
    }
}
