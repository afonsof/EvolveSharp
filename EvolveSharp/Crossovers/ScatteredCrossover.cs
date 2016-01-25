using EvolveSharp.Randoms;
using EvolveSharp.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveSharp.Crossovers
{
    public class ScatteredCrossover<T> : ICrossover<T>
    {
        bool[] scatterVector;

        public ScatteredCrossover(IRandom<bool> random, int geneCount)
        {
            scatterVector = new bool[geneCount];
            for (int i = 0; i < geneCount; i++) scatterVector[i] = random.GetNext(false, true);
        }

        public Tuple<IIndividual<T>, IIndividual<T>> Crossover(IIndividual<T> individual1, IIndividual<T> individual2)
        {
            var offspring1 = new List<T>();
            var offspring2 = new List<T>();

            for (var locus = 0; locus < individual1.Length; locus++)
                if (scatterVector[locus])
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
