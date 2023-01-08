using GreatSorter;
using Ninject;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class DIContainer
    {
        public static StartForm CreateStartForm()
        {
            return ConfigureContainer().Get<StartForm>();
        }

        public static StandardKernel ConfigureContainer()
        {
            var container = new StandardKernel();
            var arr = RndArray.Get(0);

            container.Bind<SortAlgorithm<int>>()
                .To<BubbleSort<int>>();
            //.WithConstructorArgument(arr);
            container.Bind<SortAlgorithm<int>>()
                .To<GnomeSort<int>>();
            //.WithConstructorArgument(arr);
            container.Bind<SortAlgorithm<int>>()
                .To<QuickSort<int>>();
                //.WithConstructorArgument(arr);
            container.Bind<SortAlgorithm<int>>().To<SelectionSort<int>>().WithConstructorArgument(arr);
            container.Bind<SortAlgorithm<int>>().To<StoogeSort<int>>().WithConstructorArgument(arr);

            container.Bind<StartForm>().To<StartForm>();

            return container;
        }
    }
}
