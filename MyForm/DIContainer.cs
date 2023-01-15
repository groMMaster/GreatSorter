using GreatSorter;
using MyForm;
using Ninject;

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

            container.Bind<SortAlgorithm<int>>()
                .To<BubbleSort<int>>();
            container.Bind<SortAlgorithm<int>>()
                .To<GnomeSort<int>>();
            container.Bind<SortAlgorithm<int>>()
                .To<QuickSort<int>>();
            container.Bind<SortAlgorithm<int>>()
                .To<SelectionSort<int>>();
            container.Bind<SortAlgorithm<int>>()
               .To<StoogeSort<int>>();

            container.Bind<StartForm>().To<StartForm>();

            return container;
        }
    }
}
