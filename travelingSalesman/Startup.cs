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
                ["H"] = new Point(11, 1),
            };

            PopulationController pc = new PopulationController();
            pc.Initialize(load, 100);
            pc.GetNextNGenerations(3);
            pc.PrintCurrentPopulation();

            pc.GetNextNGenerations(30);
            pc.PrintCurrentPopulation();

            pc.GetNextNGenerations(300);
            pc.PrintCurrentPopulation();
        }
    }
}
 