using System.Collections.Generic;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.Initializators
{
    /// <summary>
    /// Creates a new population based in the geneCount of population and its Fitness Function
    /// </summary>
    public class RandomInitializator : IInitializator
    {
        private readonly int _geneCount;

        public RandomInitializator(int geneCount)
        {
            _geneCount = geneCount;
        }

        public IEnumerable<IIndividual> Generate(int size, IFitnessFunction fitnessFunction)
        {
            var population = new List<IIndividual>();

            for (var i = 0; i < size; i++)
            {
                var genes = new List<double>();
                for (int locus = 0; locus < _geneCount; locus++)
                {
                    genes.Add(Helper.Random.NextDouble());
                }
                population.Add(new Individual(genes));
                population[i].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}
