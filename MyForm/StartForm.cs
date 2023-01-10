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

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 500));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 820));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));

            table.Controls.Add(picters, 0, 0);
            table.Controls.Add(parameters, 1, 0);

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
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 300));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            parameters.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

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

            firstSelectSortingType.SelectedValueChanged += (sender, args) => IsPossibleStart();
            secondSelectSortingType.SelectedValueChanged += (sender, args) => IsPossibleStart();

            parameters.Controls.Add(new Label
            {
                Dock = DockStyle.Bottom,
                Text = "Введите кол-во элементов для сортировки",
                Font = new Font("Arial", 12)
            });

            parameters.Controls.Add(sortSize, 0, 4);

            sortSize.Leave += (sender, args) => IsPossibleStart();
            sortSize.Leave += (sender, args) => TextBoxLeave();
            sortSize.Enter += (sender, args) =>
            {
                if (sortSize.Text == textSortSize)
                {
                    sortSize.Text = "";
                }
            };

            table.Controls.Add(start, 1, 1);
            table.Controls.Add(log, 1, 2);

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

            firstPictureName.Text = firstSelectSortingType.SelectedItem.ToString();
            secondPictureName.Text = secondSelectSortingType.SelectedItem.ToString();

            var firstVisualiser = new Visualiser(firstPicture);
            var secondVisualiser = new Visualiser(secondPicture);

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
