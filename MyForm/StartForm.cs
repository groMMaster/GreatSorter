using GreatSorter;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

namespace MyForm
{
    public class StartForm : Form
    {
        private TableLayoutPanel body = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel menu = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel picters = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel bottom = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel parameters = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private TableLayoutPanel actions = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke
        };

        private PictureBox firstPicture = new()
        {
            Dock = DockStyle.Top,
            Size = new Size(400, 400),
            BackColor = Color.White
        };

        private PictureBox secondPicture = new()
        {
            Dock = DockStyle.Top,
            Size = new Size(400, 400),
            BackColor = Color.White
        };

        private ComboBox firstSelectSortingType = new()
        {
            Dock = DockStyle.Bottom
        };

        private ComboBox secondSelectSortingType = new()
        {
            Dock = DockStyle.Bottom
        };

        private NumericUpDown size = new()
        {
            Dock = DockStyle.Top,
            Value = 10,
            Increment = 5,
            Maximum = 50,
            Minimum = 10
        };

        private ComboBox delay = new()
        {
            Dock = DockStyle.Top
        };

        private Button start = new()
        {
            Dock = DockStyle.Fill,
            Text = "Пуск",
        };

        private Button stop = new()
        {
            Dock = DockStyle.Fill,
            Text = "Прервать",
            Enabled = false
        };

        private Button log = new()
        {
            Dock = DockStyle.Fill,
            Text = "Загрузить журнал",
            Enabled = false
        };

        private Timer timer;
        private ArrayVisualizer firstArrayVisualizer;
        private ArrayVisualizer secondArrayVisualizer;

        public StartForm(SortAlgorithm<int>[] sortAlgorithms)
        {
            InitializeComponent(sortAlgorithms);
            Load += SetDelayValues;
        }

        private void SetDelayValues(object sender, EventArgs e)
        {
            var defaultDelay = 50;

            var speedByDelay = new Dictionary<int, string>()
            {
                {100, "Медленно"},
                {defaultDelay, "По умолчанию"},
                {10, "Быстро"},
            };

            delay.DataSource = new BindingSource(speedByDelay, null);
            delay.DisplayMember = "Value";
            delay.ValueMember = "Key";

            delay.SelectedValue = defaultDelay;
        }

        private void InitializeComponent(SortAlgorithm<int>[] sortAlgorithms)
        {
            SuspendLayout();

            Size = new Size(1080, 720);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
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
                Text = "Сравнение сортировок",
                Font = new Font("Arial", 14, FontStyle.Bold)
            });

            body.Controls.Add(picters);

            picters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            picters.RowStyles.Add(new RowStyle(SizeType.Absolute, 400));

            picters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 525));
            picters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 525));

            picters.Controls.Add(firstSelectSortingType, 0, 0);
            picters.Controls.Add(secondSelectSortingType, 1, 0);

            firstSelectSortingType.DataSource = new BindingSource(sortAlgorithms, null);
            firstSelectSortingType.DisplayMember = "Name";

            secondSelectSortingType.DataSource = new BindingSource(sortAlgorithms, null);
            secondSelectSortingType.DisplayMember = "Name";

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
                Text = "Кол-во элементов для сортировки \n(min 10, max 50)",
                Font = new Font("Arial", 12)
            },
            0, 0);

            parameters.Controls.Add(size, 1, 0);

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Top,
                Text = "Выберите скорость сортировки",
                Font = new Font("Arial", 12)
            },
            0, 1);

            delay.DropDownStyle = ComboBoxStyle.DropDownList;
            parameters.Controls.Add(delay, 1, 1);

            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            actions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            actions.Controls.Add(start);
            actions.Controls.Add(stop);
            actions.Controls.Add(log);

            start.Click += (sender, args) => StartClick();
            stop.Click += (sender, args) =>
            {
                stop.Enabled = false;
                start.Enabled = true;
                timer.Stop();
            };

            firstArrayVisualizer = new ArrayVisualizer(firstPicture);
            secondArrayVisualizer = new ArrayVisualizer(secondPicture);

            Controls.Add(body);
            PerformLayout();
            ResumeLayout(false);
        }

        private void StartClick()
        {
            stop.Enabled = true;
            start.Enabled = false;

            var selectedDelay = ((KeyValuePair<int, string>)delay.SelectedItem).Key;
            timer = new Timer();

            var firstSort = (SortAlgorithm<int>)firstSelectSortingType.SelectedItem;
            var secondSort = (SortAlgorithm<int>)secondSelectSortingType.SelectedItem;

            var randomArray = new Random().CreateArray(int.Parse(size.Text));

            var firstLog = firstSort.Sort(randomArray).Logger.GetLog();
            var secondLog = secondSort.Sort((int[])randomArray.Clone()).Logger.GetLog();

            int tickCount = 0;
            timer.Interval = selectedDelay;
            timer.Tick += (sender, args) =>
            {
                tickCount++;
                int[] e;
                if (firstLog.TryDequeue(out e))
                {
                    firstArrayVisualizer.Draw(e);
                }

                if (secondLog.TryDequeue(out e))
                {
                    secondArrayVisualizer.Draw(e);
                }

                if (tickCount > firstLog.Count && tickCount > secondLog.Count)
                {
                    stop.Enabled = false;
                    start.Enabled = true;
                    tickCount = 0;
                    timer.Stop();
                }
            };

            timer.Start();
        }
    }
}
