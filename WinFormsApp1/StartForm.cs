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
using System.Runtime.CompilerServices;

namespace WinFormsApp1
{
    public partial class StartForm : Form
    {
        private ComboBox comboBox1;
        private ComboBox comboBox2;

        public StartForm(SortAlgorithm<int>[] sortAlgorithms)
        {
            InitializeComponent();
            DoubleBuffered = true;

            comboBox1 = getComboBoxOfSorts(sortAlgorithms, new Point(50, 425));
            
            comboBox2 = getComboBoxOfSorts(sortAlgorithms, new Point(500, 425));
            Controls.Add(comboBox1);
            Controls.Add(comboBox2);
            //comboBoxes = new System.Windows.Forms.ComboBox[] { comboBox1, comboBox2 }; //массив чекбоксов
            //foreach (var cb in comboBoxes)
            //   cb.SelectedIndexChanged += someChanged;
        }

        private ComboBox getComboBoxOfSorts(SortAlgorithm<int>[] sortAlgorithms, Point location)
        {
            var result = new ComboBox
            {
                Location = location,
                Size = new Size(400, 25),
            };
            result.Items.AddRange(sortAlgorithms);
            return result;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var count = trackBar1.Value;

            //var type1 = comboBox1.SelectedItem;
            //var sortFirst = SortingFactory.CreateSort(type1.ToString(), RndArray.Get(count));
            var sortFirst = (SortAlgorithm<int>)comboBox1.SelectedItem;

            var visualFirst = new Visualiser<int>(pictureBox1);
            sortFirst.SortableArray.RegisterObserver(visualFirst);


            //var type2 = comboBox2.SelectedItem.ToString();
            //var sortSecond = SortingFactory.CreateSort(type2, RndArray.Get(count));
            var sortSecond = (SortAlgorithm<int>)comboBox2.SelectedItem;

            var visualSecond = new Visualiser<int>(pictureBox2);
            sortSecond.SortableArray.RegisterObserver(visualSecond);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox2.SelectedItem.ToString();
        }

        System.Windows.Forms.ComboBox[] comboBoxes;

        void someChanged(object sender, EventArgs e)
        {
            button1.Enabled = CheckEnabled();
        }

        bool CheckEnabled()
        {
            foreach (var cb in comboBoxes)
                if (cb.SelectedItem is null) return false;
            return true;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Enter(object sender, EventArgs e)
        {

        }
    }
}
