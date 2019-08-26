using System;
using System.Collections.Generic;
using System.Text;

namespace travelingSalesman
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; private set; }
        public double Y { get; private set; }

        public static double GetDistance(Point one, Point two)
        {
            var a = Math.Pow(Math.Abs(one.X - two.X), 2);
            var b = Math.Pow(Math.Abs(one.Y - two.Y), 2);
            return Math.Round(Math.Sqrt(a + b), 2);
        }
    }
}
