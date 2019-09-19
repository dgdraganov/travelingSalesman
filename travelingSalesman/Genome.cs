using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travelingSalesman
{
    public class Genome
    {
        public static Random rand = new Random();
        public IEnumerable<string> genes;


        public Genome(IEnumerable<string> genes)
        {
            this.genes = genes;
        }

        public override string ToString()
        {
            return string.Join(" ", genes);
        }

        public static IEnumerable<Genome> Mate(Genome first, Genome second, int mutationChance)
        {
            var children = new List<Genome>();

            var newGenes = new List<string>();
            var genomeSize = first.genes.Count();
            var halfGenes = (first.genes.Count() + 1) / 2;
            int skipIndex = 0;
            while (skipIndex + halfGenes <= genomeSize)
            {
                var firstParrentGenes = first.genes.Skip(skipIndex).Take(halfGenes); 
                newGenes.AddRange(second.genes.Where(g => !firstParrentGenes.Contains(g)).Take(skipIndex));
                newGenes.AddRange(firstParrentGenes);
                newGenes.AddRange(second.genes.Where(g => !newGenes.Contains(g)));

                var newGenome = new Genome(newGenes);
                Mutator(newGenome, mutationChance);
                children.Add(newGenome);
                
                newGenes = new List<string>();
                skipIndex++;
            }
            return children;
        }

        public static void Mutator(Genome genome, int mutationChance)
        {
            var willMutate = rand.Next(1, 101) <= mutationChance;

            if (willMutate)
            {
                // choose gene that will mutate
                var genomeSize = genome.genes.Count();
                var mutatableGeneIndex = rand.Next(0, genomeSize);
                var swapWithIndex = -1;
                do
                {    //make sure there will be a mutation
                    swapWithIndex = rand.Next(0, genomeSize);
                } while (swapWithIndex == mutatableGeneIndex);

                var genes = genome.genes.ToList();
                var bufferGene = genes[mutatableGeneIndex];
                genes[mutatableGeneIndex] = genes[swapWithIndex];
                genes[swapWithIndex] = bufferGene;
                genome.genes = genes;
            }
        }
    }
}
