﻿using System;
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
            var widthPen = 2;

            Graphics g = PictureBox.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, widthPen);

            var x = 15;
            var stepX = (int)((width - widthPen * count) / (count + 1));
            var y1 = height - 50;
            var yE = (int)((height - 100) / count);

            foreach (var e in array)
            {
                x += stepX;
                var p1 = new Point(x, y1);
                var y2 = y1 - yE * (int)(object)e;
                var p2 = new Point(x, y2);

                g.DrawLine(pen, p1, p2);
                x += widthPen;
            }
            
            Thread.Sleep(10);
        }

        public void Update(object sender, object eventData)
        {
            Make(((ChangedArray<T>)eventData).Value);
        }
    }
}