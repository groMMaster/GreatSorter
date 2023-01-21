namespace MyForm
{
    public class ArrayVisualizer : IVisualizer
    {
        private PictureBox pictureBox;
        private Pen pen;
        
        private int widthPictureBox;
        private int heightPictureBox;

        private const int margin = 20;
        private const int widthPen = 2;

        public ArrayVisualizer(PictureBox pictureBox)
        {
            pen = new Pen(Color.Black, widthPen);
            this.pictureBox = pictureBox;

            widthPictureBox = pictureBox.Width;
            heightPictureBox = pictureBox.Height;
        }

        public void Draw(int[] array)
        {
            var numberElements = array.Length;
            var yHeight = (heightPictureBox - 4 * margin) / numberElements;

            var widthPen = 2;

            var x = margin * 2f;
            var y1 = heightPictureBox - margin * 2f;

            var stepX = CalcStepX(numberElements);

            pictureBox.Paint += (sender, args) =>
            {
                args.Graphics.Clear(Color.White);
                foreach (var e in array)
                {
                    var y2 = y1 - yHeight * (int)(object)e;

                    var start = new PointF(x, y1);
                    var end = new PointF(x, y2);

                    x += stepX + widthPen;
                    args.Graphics.DrawLine(pen, start, end);
                }
            };

            pictureBox.Invalidate();
        }

        private float CalcStepX(int numberElements)
        {
            return (float)(widthPictureBox - 4 * margin - widthPen * numberElements) / (numberElements - 1);
        }
    }
}
