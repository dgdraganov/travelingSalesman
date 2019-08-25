using System;
using System.Collections.Generic;
using System.Text;

namespace travelingSalesman
{
    public class Genome
    {
        private readonly IEnumerable<string> genes;

        public Genome(IEnumerable<string> genes)
        {
            this.genes = genes;
        }
    }
}
