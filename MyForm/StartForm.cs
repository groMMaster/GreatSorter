using GreatSorter;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace MyForm
{
    public partial class StartForm : Form
    {
        private TextBox sortSize;
        private Label textSelectSortingType;
        private Button start;
        private Button getLog;
        private PictureBox firstSortingPicture;
        private PictureBox secondSortingPicture;
        private ComboBox firstSelectSortingType;
        private ComboBox secondSelectSortingType;
        private TableLayoutPanel table;

        public StartForm(SortAlgorithm<int>[] sortAlgorithms)
        {
            InitializeComponent(sortAlgorithms);
        }

        private void InitializeComponent(SortAlgorithm<int>[] sortAlgorithms)
        {
            this.SuspendLayout();

            Size = new Size(960, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            DoubleBuffered = true;

            textSelectSortingType = new Label
            {
                Text = "�������� ����������, ������� ������ ��������",
                Font = new Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Point),
                Dock = DockStyle.Bottom
            };

            start = new Button
            {
                Size = new Size(150, 37),
                Text = "����",
                Dock = DockStyle.Top,
                Enabled = false
            };

            start.Click += new EventHandler(StartClick);

            getLog = new Button
            {
                Size = new Size(150, 37),
                Text = "��������� ������ ����������",
                Dock = DockStyle.Top,
                Enabled = false
            };

            firstSortingPicture = new PictureBox
            {
                Size = new Size(360, 225),
                BackColor = Color.White,
                Dock = DockStyle.Top,

            };

            secondSortingPicture = new PictureBox
            {
                Size = new Size(360, 225),
                BackColor = Color.White,
                Dock = DockStyle.Top
            };

            var comboBoxItems = new string[] {
            "Bubble Sort",
            "Gnome Sort",
            "Quick Sort",
            "Selection Sort",
            "Stooge Sort"};

            firstSelectSortingType = new ComboBox
            {
                Dock = DockStyle.Fill
            };

            firstSelectSortingType.SelectedValueChanged += (sender, args) => IsPossibleStart();
            firstSelectSortingType.Items.AddRange(sortAlgorithms);

            secondSelectSortingType = new ComboBox
            {
                Dock = DockStyle.Fill
            };

            secondSelectSortingType.SelectedValueChanged += (sender, args) => IsPossibleStart();
            secondSelectSortingType.Items.AddRange(sortAlgorithms);

            sortSize = new TextBox
            {
                Text = "������� ���-�� ��������� ��� ���������� (min - 10, max - 100)",
                Dock = DockStyle.Top
            };

            sortSize.Enter += (sender, args) =>
            {
                if (sortSize.Text == "������� ���-�� ��������� ��� ���������� (min - 10, max - 100)")
                {
                    sortSize.Text = "";
                }
            };

            sortSize.Leave += (sender, args) => IsPossibleStart();
            sortSize.Leave += new EventHandler(textBox_Leave);

            table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.Dock = DockStyle.Fill;

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 280));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(textSelectSortingType, 0, 0);

            table.Controls.Add(firstSelectSortingType, 0, 1);
            table.Controls.Add(secondSelectSortingType, 1, 1);

            table.Controls.Add(firstSortingPicture, 0, 2);
            table.Controls.Add(secondSortingPicture, 1, 2);

            table.Controls.Add(sortSize, 1, 3);
            table.Controls.Add(start, 1, 4);
            table.Controls.Add(getLog, 0, 4);


            Controls.Add(table);
            PerformLayout();
            ResumeLayout(false);
        }

        private void IsPossibleStart()
        {
            if (firstSelectSortingType.SelectedItem != null && secondSelectSortingType.SelectedItem != null)
            {
                if (sortSize.Text != "������� ���-�� ��������� ��� ���������� (min - 10, max - 100)")
                {
                    start.Enabled = true;
                }
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (sortSize.Text == "")
            {
                start.Enabled = false;
                sortSize.Text = "������� ���-�� ��������� ��� ���������� (min-10, max-100)";
                return;
            }

            int input;
            try
            {
                input = int.Parse(sortSize.Text);

                if (input < 10 || input > 100)
                {
                    SortSizeExeption("����� ������ ���� �� 10 �� 100");
                }
            }
            catch (Exception)
            {
                SortSizeExeption("������� �����");
            }
        }

        private void SortSizeExeption(string message)
        {
            MessageBox.Show(message, "������ ��� ����� �������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sortSize.Text = "������� ���-�� ��������� ��� ���������� (min - 10, max - 100)";
        }

        private async void StartClick(object sender, EventArgs e)
        {
            var firstVisualiser = new Visualiser(firstSortingPicture);
            var secondVisualiser = new Visualiser(secondSortingPicture);


            var firstSort = (SortAlgorithm<int>)firstSelectSortingType.SelectedItem;
            var secondSort = (SortAlgorithm<int>)secondSelectSortingType.SelectedItem;

            var randomArray = RndArray.Get(int.Parse(sortSize.Text));

            firstSort.SetArray(randomArray);
            secondSort.SetArray((int[])randomArray.Clone());

            firstSort.SortableArray.RegisterObserver(firstVisualiser);
            secondSort.SortableArray.RegisterObserver(secondVisualiser);

            await ParallelSortExecutor<int>.Execute(firstSort, secondSort);
        }
    }

    public class Visualiser : IObserver
    {
        private PictureBox pictureBox;

        public Visualiser(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void Drawing(int[] array)
        {
            var width = pictureBox.Width;
            var height = pictureBox.Height;
            var count = array.Length;
            var margin = 20;
            var yHeight = (height - 2 * margin) / count;

            var widthPen = 2;
            Pen pen = new Pen(Color.Black, widthPen);

            var y1 = height - 20;

            var stepX = (double)(width - 2 * margin - widthPen * count) / (count - 1);
            var remStepX = stepX - (int)stepX;
            var sumRemStepX = 0.0;
            var f = true;
            Thread.Sleep(50);

            pictureBox.Paint += (sender, args) =>
            {
                var x = margin;
                args.Graphics.Clear(Color.White);
                foreach (var e in array)
                {
                    CalcRemStepX(ref sumRemStepX, ref x, remStepX);
                    var y2 = y1 - yHeight * (int)(object)e;

                    var p1 = new Point(x, y1);
                    var p2 = new Point(x, y2);

                    x += (int)stepX + widthPen;

                    args.Graphics.DrawLine(pen, p1, p2);
                }

            };

            pictureBox.Invalidate();
            
        }

        public void Update(object sender, object eventData)
        {
            Drawing(((ChangedArray<int>)eventData).Value);
        }

        private void CalcRemStepX(ref double sumRemStepX, ref int x, double remStepX)
        {
            if (sumRemStepX < 2)
            {
                sumRemStepX += remStepX;
            }
            else
            {
                sumRemStepX -= 2;
                x += 2;
            }
            if (sumRemStepX < 1)
            {
                sumRemStepX += remStepX;
            }
            else
            {
                sumRemStepX--;
                x++;
            }
        }
    }
}
