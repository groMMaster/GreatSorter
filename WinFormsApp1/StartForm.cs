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

        private void button1_Click(object sender, EventArgs e)
        {
            var sortFirst = new SortHandler<int>(RndArray.Get(50));

            var visualFirst = new Visualiser<int>(pictureBox1);
            sortFirst.SortableArray.RegisterObserver(visualFirst);
            sortFirst.Start(new BubbleSort<int>());

            var sortSecond = new SortHandler<int>(RndArray.Get(75));

            var visualSecond = new Visualiser<int>(pictureBox2);
            sortSecond.SortableArray.RegisterObserver(visualSecond);
            sortSecond.Start(new GnomeSort<int>());
        }
    }
}
