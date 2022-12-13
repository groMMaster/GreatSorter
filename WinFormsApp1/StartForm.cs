using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GreatSorter;

namespace WinFormsApp1
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var visual = new Visualiser<int>(pictureBox1);
            var sort = new SortHandler<int>(RndArray.Get(10));
            sort.SortableArray.RegisterObserver(visual);
            sort.Start(new BubbleSort<int>());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var visual = new Visualiser<int>(pictureBox2);
            var sort = new SortHandler<int>(RndArray.Get(10));
            sort.SortableArray.RegisterObserver(visual);
            sort.Start(new BubbleSort<int>());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sortFirst = new SortHandler<int>(RndArray.Get(10));

            var visualFirst = new Visualiser<int>(pictureBox1);
            sortFirst.SortableArray.RegisterObserver(visualFirst);
            sortFirst.Start(new BubbleSort<int>());

            var sortSecond = new SortHandler<int>(RndArray.Get(10));

            var visualSecond = new Visualiser<int>(pictureBox2);
            sortSecond.SortableArray.RegisterObserver(visualSecond);
            sortSecond.Start(new GnomeSort<int>());
        }
    }
}
