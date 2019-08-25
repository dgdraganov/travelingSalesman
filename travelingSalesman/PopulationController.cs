using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travelingSalesman
{
    public class PopulationController
    {
        private Random random;
        public PopulationController()
        {
            CashDistance = new Dictionary<string, double>();
            random = new Random();
        }

        private IEnumerable<Genome> Population { get; set; }
        private Dictionary<string, Point> Genes { get; set; }
        private Dictionary<string, double> CashDistance { get; set; }

        public void Initialize(Dictionary<string, Point> genes, int size)
        {
            Genes = genes;
            Population = GenerateRandomPopulation(size);
        }

        private IEnumerable<Genome> GenerateRandomPopulation(int size)
        {
            var newPopulation = new List<Genome>();
            var allGenes = this.Genes.Keys.ToList();

            for (int i = 0; i < size; i++)
            {
                var genes = allGenes.GetCopy().ToList();
                var randomGenes = new Queue<string>();
                while (genes.Count > 0)
                {
                    var index = random.Next(0, genes.Count);
                    randomGenes.Enqueue(genes[index]);
                    genes.RemoveAt(index);
                }
                var newGenome = new Genome(randomGenes);
                newPopulation.Add(newGenome);
            }

            return newPopulation;
        }

    }
}
