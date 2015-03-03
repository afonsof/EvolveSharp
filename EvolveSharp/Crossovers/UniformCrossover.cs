using System;
using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Randoms;

namespace EvolveSharp.Crossovers
{
    public class UniformCrossover<T> : ICrossover<T>
    {
        double ratePerGene;
        IRandom<double> random;

        public UniformCrossover(IRandom<double> random, double ratePerGene = 0.5)
        {
            this.ratePerGene = ratePerGene;
            this.random = random;
        }

        public Tuple<IIndividual<T>, IIndividual<T>> Crossover(IIndividual<T> individual1, IIndividual<T> individual2)
        {
            var offspring1 = new List<T>();
            var offspring2 = new List<T>();

            for (var locus = 0; locus < individual1.Length; locus++)
                if (random.GetNext(0d, 1d) < ratePerGene)
                {
                    offspring1.Add(individual1.Genes[locus]);
                    offspring2.Add(individual2.Genes[locus]);
                }
                else
                {
                    offspring1.Add(individual2.Genes[locus]);
                    offspring2.Add(individual1.Genes[locus]);
                }

            return new Tuple<IIndividual<T>, IIndividual<T>>(new Individual<T>(offspring1), new Individual<T>(offspring2));
        }
    }
}

