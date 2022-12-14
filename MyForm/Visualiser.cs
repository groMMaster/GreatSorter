using GreatSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
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
            var yHeight = (height - 4 * margin) / count;

            var widthPen = 2;
            Pen pen = new Pen(Color.Black, widthPen);

            var x = margin * 2;
            var y1 = height - margin * 2;

            var stepX = (double)(width - 4 * margin - widthPen * count) / (count - 1);
            var remStepX = stepX - (int)stepX;
            var sumRemStepX = 0.0;


            pictureBox.Paint += (sender, args) =>
            {
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
            Thread.Sleep(50);
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
