using System.Collections.Generic;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;

namespace EvolveSharp.Initializators
{
    /// <summary>
    /// Creates a new empty population based in the geneCount of population and its Fitness Function
    /// </summary>
    public class EmptyInitializer : IInitializer<double>
    {
        private readonly int _geneCount;

        public EmptyInitializer(int geneCount)
        {
            _geneCount = geneCount;
        }

        public IEnumerable<IIndividual<double>> Generate(int size, IFitnessFunction<double> fitnessFunction)
        {
            var population = new List<IIndividual<double>>();

            for (var i = 0; i < size; i++)
            {
                var genes = new double[_geneCount];
                population.Add(new Individual<double>(genes));
                population[i].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}