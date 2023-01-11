using GreatSorter;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace MyForm
{
    public partial class StartForm : Form
    {
        private TableLayoutPanel body = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel menu = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel picters = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel bottom = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel parameters = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel actions = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private PictureBox firstPicture = new PictureBox
        {
            Dock = DockStyle.Top,
            Size = new Size(400, 400),
            BackColor = Color.White
        };

        private PictureBox secondPicture = new PictureBox
        {
            Dock = DockStyle.Top,
            Size = new Size(400, 400),
            BackColor = Color.White
        };

        private ComboBox firstSelectSortingType = new ComboBox
        {
            Dock = DockStyle.Bottom
        };

        private ComboBox secondSelectSortingType = new ComboBox
        {
            Dock = DockStyle.Bottom
        };

        private NumericUpDown size = new NumericUpDown
        {
            Dock = DockStyle.Top,
            Value = 10,
            Increment = 5,
            Maximum = 50,
            Minimum = 10
        };

        private ComboBox speed = new ComboBox
        {
            Dock = DockStyle.Top
        };

        private Button start = new Button
        {
            Dock = DockStyle.Fill,
            Text = "����",
        };

        private Button stop = new Button
        {
            Dock = DockStyle.Fill,
            Text = "��������",
            Enabled = false
        };

        private Button log = new Button
        {
            Dock = DockStyle.Fill,
            Text = "��������� ������",
            Enabled = false
        };

        public StartForm(SortAlgorithm<int>[] sortAlgorithms)
        {
            InitializeComponent(sortAlgorithms);
        }

        private void InitializeComponent(SortAlgorithm<int>[] sortAlgorithms)
        {
            this.SuspendLayout();

            Size = new Size(1080, 720);
            
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox= false;
            MaximizeBox = false;
            DoubleBuffered = true;

            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 450));
            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));

            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1050));

            body.Controls.Add(menu);

            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 540));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1050));

            menu.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "��������� ����������",
                Font = new Font("Arial", 14, FontStyle.Bold)
            });

            body.Controls.Add(picters);

            picters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            picters.RowStyles.Add(new RowStyle(SizeType.Absolute, 400));

            picters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 525));
            picters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 525));

            picters.Controls.Add(firstSelectSortingType, 0, 0);
            picters.Controls.Add(secondSelectSortingType, 1, 0);

            firstSelectSortingType.Items.AddRange(sortAlgorithms);
            secondSelectSortingType.Items.AddRange(sortAlgorithms);

            firstSelectSortingType.SelectedItem = sortAlgorithms[0];
            secondSelectSortingType.SelectedItem = sortAlgorithms[1];

            firstSelectSortingType.DropDownStyle = ComboBoxStyle.DropDownList;
            secondSelectSortingType.DropDownStyle = ComboBoxStyle.DropDownList;

            picters.Controls.Add(firstPicture, 0, 1);
            picters.Controls.Add(secondPicture, 1, 1);

            body.Controls.Add(bottom);

            bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));

            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 525));
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 525));

            bottom.Controls.Add(parameters, 0, 0);
            bottom.Controls.Add(actions, 1, 0);

            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            parameters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            parameters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Text = "���-�� ��������� ��� ���������� \n(min 10, max 50)",
                Font = new Font("Arial", 12)
            },
            0, 0);

            parameters.Controls.Add(size, 1, 0);

            

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Top,
                Text = "�������� �������� ����������",
                Font = new Font("Arial", 12)
            }, 
            0, 1);

            parameters.Controls.Add(speed, 1, 1);
            speed.Items.AddRange(new string[]
            {
                "��������",
                "�� ���������",
                "������"
            });

            speed.SelectedItem = "�� ���������";
            speed.DropDownStyle = ComboBoxStyle.DropDownList;

            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            actions.Controls.Add(start);
            actions.Controls.Add(stop);
            actions.Controls.Add(log);

            start.Click += (sender, args) => StartClick();
            stop.Click += (sender, args) =>
            {

            };

            Controls.Add(body);
            PerformLayout();
            ResumeLayout(false);
        }

        private async void StartClick()
        {
            start.Enabled = false;
            stop.Enabled = true;

            var firstVisualiser = new Visualiser(firstPicture, speed.Text);
            var secondVisualiser = new Visualiser(secondPicture, speed.Text);

            var firstSort = (SortAlgorithm<int>)firstSelectSortingType.SelectedItem;
            var secondSort = (SortAlgorithm<int>)secondSelectSortingType.SelectedItem;

            var randomArray = new Random().CreateArray(int.Parse(size.Text));

            firstSort.SetArray(randomArray);
            secondSort.SetArray((int[])randomArray.Clone());

            firstSort.SortableArray.RegisterObserver(firstVisualiser);
            secondSort.SortableArray.RegisterObserver(secondVisualiser);

            await ParallelSortExecutor<int>.Execute(firstSort, secondSort);

            start.Enabled = true;
            stop.Enabled = false;
        }
    }
}
