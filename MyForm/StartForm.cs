using GreatSorter;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace MyForm
{
    public partial class StartForm : Form
    {
        public StartForm(SortAlgorithm<int>[] sortAlgorithms)
        {
            InitializeComponent(sortAlgorithms);
        }
    }
}