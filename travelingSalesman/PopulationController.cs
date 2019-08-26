using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travelingSalesman
{
    public class PopulationController
    {
        private const double SELECTION_COEFFICIENT = 0.3;
        private int generationCount;
        private Random random;
        public PopulationController()
        {
            CashDistance = new Dictionary<string, double>();
            random = new Random();
            generationCount = 0;
        }

        private IEnumerable<Genome> Population { get; set; }
        private Dictionary<string, Point> Genes { get; set; }
        private Dictionary<string, double> CashDistance { get; set; }

        public void Initialize(Dictionary<string, Point> genes, int size)
        {
            Genes = genes;
            Population = GenerateRandomPopulation(size);
            generationCount = size;
        }

        public void GetNextNGenerations(int generations = 1)
        {
            for (int i = 0; i < generations; i++)
            {
                var bestIndividuals = GetBestIndividuals();


            }
        }

        private IEnumerable<Genome> GetBestIndividuals()
        {
            var numberOfSelected = Math.Round(generationCount * SELECTION_COEFFICIENT);
            var queue = new Queue<Genome>(Population);

            while (queue.Count > numberOfSelected)
            {
                var first = queue.Dequeue();
                var second = queue.Dequeue();
                var winner = GetBetterGenome(first, second);
                queue.Enqueue(winner);
            }

            return queue;
        }

        private Genome GetBetterGenome(Genome first, Genome second)
        {
            var firstDistance = GetGenomeTotalDistance(first);
            var secondDistance = GetGenomeTotalDistance(second);

            return firstDistance > secondDistance ? second : first;
        }

        private double GetGenomeTotalDistance(Genome genome)
        {
            var distance = 0.0;
            var genes = genome.genes.ToList(); ;
            for (int i = 0; i < genes.Count - 1; i++)
            {
                var geneA = genes[i];
                var geneB = genes[i + 1];
                var key = $"{geneA}:{geneB}";
                if (CashDistance.ContainsKey(key))
                {
                    distance += CashDistance[key];
                    continue;
                }
                var dist = Point.GetDistance(Genes[geneA], Genes[geneB]);
                distance += dist;
                CashDistance.Add(key, dist);
            }
            return Math.Round(distance, 2);
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
