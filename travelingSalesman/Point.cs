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

        public static double GetTotalDistance(Point one, Point two)
        {
            var a = Math.Pow(Math.Abs(one.X - two.X), 2);
            var b = Math.Pow(Math.Abs(one.Y - two.Y), 2);
            return Math.Sqrt(a + b);
            
        }
    }
}
