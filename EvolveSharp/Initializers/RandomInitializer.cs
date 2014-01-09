using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.Initializers
{
    /// <summary>
    /// Creates a new population based in the geneCount of population and its Fitness Function
    /// </summary>
    public class RandomInitializer : IInitializer<double>
    {
        private readonly int _geneCount;

        public RandomInitializer(int geneCount)
        {
            _geneCount = geneCount;
        }

        public IEnumerable<IIndividual<double>> Generate(int size, IFitnessFunction<double> fitnessFunction)
        {
            var population = new List<IIndividual<double>>();

            for (var i = 0; i < size; i++)
            {
                var genes = new List<double>();
                for (int locus = 0; locus < _geneCount; locus++)
                {
                    genes.Add(Helper.Random.NextDouble());
                }
                population.Add(new Individual<double>(genes));
                population[i].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}
