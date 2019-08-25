using System;
using System.Collections.Generic;

namespace travelingSalesman
{
    class Startup
    {
        static void Main(string[] args)
        {
            var load = new Dictionary<string, Point>()
            {
                ["A"] = new Point(2, 2),
                ["B"] = new Point(3, 7),
                ["C"] = new Point(10, 4),
            };
        }
    }
}
