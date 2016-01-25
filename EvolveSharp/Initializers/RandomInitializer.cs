using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Randoms;

namespace EvolveSharp.Initializers
{
    /// <summary>
    /// Creates a new population based in the geneCount of population and its Fitness Function
    /// </summary>
    public class RandomInitializer<T> : IInitializer<T>
    {
        private readonly int geneCount;
        IList<T> mins, maxs;
        IRandom<T> random;

        public RandomInitializer(int geneCount, IList<T> mins, IList<T> maxs, IRandom<T> random)
        {
            this.geneCount = geneCount;
            this.mins = mins;
            this.maxs = maxs;
            this.random = random;
        }

        public IEnumerable<IIndividual<T>> Generate(int size, IFitnessFunction<T> fitnessFunction)
        {
            var population = new List<IIndividual<T>>();

            for (var i = 0; i < size; i++)
            {
                var genes = new T[geneCount];
                for (int locus = 0; locus < geneCount; locus++)
                    genes[locus] = random.GetNext(mins[locus], maxs[locus]);

                population.Add(new Individual<T>(genes));
                population[i].FitnessFunction = fitnessFunction;
            }

            return population;
        }
    }
}
