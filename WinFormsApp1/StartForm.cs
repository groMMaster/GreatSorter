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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            comboBoxes = new System.Windows.Forms.ComboBox[] { comboBox1, comboBox2 }; //массив чекбоксов
            foreach (var cb in comboBoxes)
                cb.SelectedIndexChanged += someChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var count = trackBar1.Value;

            var type1 = comboBox1.SelectedItem.ToString();
            var sortFirst = SortingFactory.CreateSort(type1, RndArray.Get(count));

            var visualFirst = new Visualiser<int>(pictureBox1);
            sortFirst.SortableArray.RegisterObserver(visualFirst);
            

            var type2 = comboBox2.SelectedItem.ToString();
            var sortSecond = SortingFactory.CreateSort(type2, RndArray.Get(count));

            var visualSecond = new Visualiser<int>(pictureBox2);
            sortSecond.SortableArray.RegisterObserver(visualSecond);
            
            await ParallelSortExecutor<int>.Execute(sortFirst, sortSecond);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
