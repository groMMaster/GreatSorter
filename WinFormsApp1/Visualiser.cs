using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GreatSorter;

namespace WinFormsApp1
{
    public class Visualiser<T> : IObserver
    {
        public PictureBox PictureBox;
        private int width;
        private int height;

        public Visualiser(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            width = pictureBox.Width;
            height = pictureBox.Height;
        }
        public void Make(T[] array)
        {
            var count = array.Length;
            var widthPen = 6;

            Graphics g = PictureBox.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, widthPen);

            var x = 50;
            var stepX = (int)((width - 50 - widthPen * (count - 2)) / (count + 1));
            var y1 = height - 50;

            foreach (var e in array)
            {
                x += stepX;
                var p1 = new Point(x, y1);
                var y2 = y1 - 20 * (int)(object)e;
                var p2 = new Point(x, y2);

                g.DrawLine(pen, p1, p2);
            }
            
            Thread.Sleep(450);
        }

        public void Update(object sender, object eventData)
        {
            Make(((ChangedArray<T>)eventData).Value);
        }
    }
}
