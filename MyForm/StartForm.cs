using GreatSorter;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace MyForm
{
    public partial class StartForm : Form
    {
        private TableLayoutPanel table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(5),
            BackColor = Color.WhiteSmoke,
        };

        private TableLayoutPanel picters = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(5),
            BackColor = Color.WhiteSmoke,
        };

        private TableLayoutPanel parameters = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
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

        private Label firstPictureName = new Label
        {
            Text = "",
            Font = new Font("Arial", 12),
            Dock = DockStyle.Bottom
        };

        private Label secondPictureName = new Label
        {
            Text = "",
            Font = new Font("Arial", 12),
            Dock = DockStyle.Bottom
        };

        private ComboBox firstSelectSortingType = new ComboBox
        {
            Dock = DockStyle.Top
        };

        private ComboBox secondSelectSortingType = new ComboBox
        {
            Dock = DockStyle.Top,
        };

        private TextBox sortSize = new TextBox
        {
            Dock = DockStyle.Top,
            Text = textSortSize,
        };

        private ComboBox speed = new ComboBox
        {
            Dock = DockStyle.Top,
        };

        private Button start = new Button
        {
            Dock = DockStyle.Top,
            Size = new Size(380, 50),
            Text = "Пуск",
            Enabled = false,
        };

        private Button log = new Button
        {
            Dock = DockStyle.Top,
            Size = new Size(380, 50),
            Text = "Загрузить журнал",
            Enabled = false
        };

        private const string textSortSize = "min 10 - max 50";

        public StartForm(SortAlgorithm<int>[] sortAlgorithms)
        {
            InitializeComponent(sortAlgorithms);
        }

        private void InitializeComponent(SortAlgorithm<int>[] sortAlgorithms)
        {
            this.SuspendLayout();

            Size = new Size(1280, 720);
            
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            DoubleBuffered = true;

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 500));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 820));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));

            table.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "Экран домонстрации",
                Font = new Font("Arial", 12, FontStyle.Bold)
            },
            0, 0);

            table.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "Параметры",
                Font = new Font("Arial", 12, FontStyle.Bold)
            },
            1, 0);

            table.Controls.Add(picters, 0, 1);
            table.Controls.Add(parameters, 1, 1);

            picters.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            picters.RowStyles.Add(new RowStyle(SizeType.Absolute, 400));

            picters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 410));
            picters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 410));

            picters.Controls.Add(firstPictureName, 0, 0);
            picters.Controls.Add(secondPictureName, 1, 0);

            picters.Controls.Add(firstPicture, 0, 1);
            picters.Controls.Add(secondPicture, 1, 1);

            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

            parameters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "Выберите сортировки, которые хотите сравнить",
                Font = new Font("Arial", 12)
            });

            parameters.Controls.Add(firstSelectSortingType);
            parameters.Controls.Add(secondSelectSortingType);

            firstSelectSortingType.Items.AddRange(sortAlgorithms);
            secondSelectSortingType.Items.AddRange(sortAlgorithms);

            firstSelectSortingType.DropDownStyle = ComboBoxStyle.DropDownList;
            secondSelectSortingType.DropDownStyle = ComboBoxStyle.DropDownList;

            firstSelectSortingType.SelectedValueChanged += (sender, args) => IsPossibleStart();
            secondSelectSortingType.SelectedValueChanged += (sender, args) => IsPossibleStart();

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "Введите кол-во элементов для сортировки",
                Font = new Font("Arial", 12)
            });

            parameters.Controls.Add(sortSize);

            sortSize.Leave += (sender, args) => IsPossibleStart();
            sortSize.Leave += (sender, args) => TextBoxLeave();
            sortSize.Enter += (sender, args) =>
            {
                if (sortSize.Text == textSortSize)
                {
                    sortSize.Text = "";
                }
            };

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "Выберите скорость сортировки",
                Font = new Font("Arial", 12)
            });

            parameters.Controls.Add(speed);
            speed.Items.AddRange(new string[]
            {
                "Медленно",
                "По умолчанию",
                "Быстро"
            });

            speed.SelectedItem = "По умолчанию";
            speed.DropDownStyle = ComboBoxStyle.DropDownList;

            table.Controls.Add(start, 1, 2);
            table.Controls.Add(log, 1, 3);

            start.Click += (sender, args) => StartClick();

            Controls.Add(table);
            PerformLayout();
            ResumeLayout(false);
        }

        private void IsPossibleStart()
        {
            if (firstSelectSortingType.SelectedItem != null && secondSelectSortingType.SelectedItem != null)
            {
                if (sortSize.Text != textSortSize)
                {
                    start.Enabled = true;
                }
            }
        }

        private void TextBoxLeave()
        {
            if (sortSize.Text == "")
            {
                start.Enabled = false;
                sortSize.Text = textSortSize;
                return;
            }

            int input;
            try
            {
                input = int.Parse(sortSize.Text);

                if (input < 10 || input > 50)
                {
                    SortSizeExeption("Число должно быть от 10 до 50");
                }
            }
            catch (Exception)
            {
                SortSizeExeption("Введите число");
            }
        }

        private void SortSizeExeption(string message)
        {
            MessageBox.Show(message, "Ошибка при вводе размера", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sortSize.Text = textSortSize;
        }

        private async void StartClick()
        {
            start.Enabled = false;

            firstPictureName.Text = firstSelectSortingType.Text;
            secondPictureName.Text = secondSelectSortingType.Text;

            var firstVisualiser = new Visualiser(firstPicture, speed.Text);
            var secondVisualiser = new Visualiser(secondPicture, speed.Text);

            var firstSort = (SortAlgorithm<int>)firstSelectSortingType.SelectedItem;
            var secondSort = (SortAlgorithm<int>)secondSelectSortingType.SelectedItem;

            var randomArray = new Random().CreateArray(int.Parse(sortSize.Text));

            firstSort.SetArray(randomArray);
            secondSort.SetArray((int[])randomArray.Clone());

            firstSort.SortableArray.RegisterObserver(firstVisualiser);
            secondSort.SortableArray.RegisterObserver(secondVisualiser);

            await ParallelSortExecutor<int>.Execute(firstSort, secondSort);
            start.Enabled = true;
        }
    }
}
