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
                ["B"] = new Point(5, 5),
                ["C"] = new Point(1, 6),
                ["D"] = new Point(3, 9),
                ["E"] = new Point(8, 7),
                ["F"] = new Point(6, 1),
                ["G"] = new Point(3, 4),
                ["H"] = new Point(7, 1),
                ["I"] = new Point(13, 8),
                ["J"] = new Point(11, 2),
                ["K"] = new Point(19, 11),
                ["L"] = new Point(4, 3)
            };

            PopulationController pc = new PopulationController();
            pc.Initialize(load, 1000, 7);
            pc.GetNextNGenerations(5);
            pc.PrintCurrentPopulation();
        }
    }
}
 