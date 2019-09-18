using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travelingSalesman
{
    public class Genome
    {
        public readonly IEnumerable<string> genes;


        public Genome(IEnumerable<string> genes)
        {
            this.genes = genes;
        }

        public override string ToString() 
        {
            return string.Join(" ", genes);
        }

        public static IEnumerable<Genome> Mate(Genome first, Genome second)
        {
            var children = new List<Genome>();
            var halfGenes = (first.genes.Count() + 1) / 2;

            var genes = new List<string>();
            genes.AddRange(first.genes.Take(halfGenes));
            genes.AddRange(second.genes.Where(g => !genes.Contains(g)));
            Genome child = new Genome(genes);
            children.Add(child);

            genes = new List<string>();
            var lastNGenes = first.genes.Skip(halfGenes);
            genes.AddRange(second.genes.Where(g => !lastNGenes.Contains(g)));
            genes.AddRange(lastNGenes);
            child = new Genome(genes);
            children.Add(child);

            return children;
        }
    
    }
}
