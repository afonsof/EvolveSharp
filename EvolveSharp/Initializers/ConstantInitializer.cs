using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.Initializers
{
    /// <summary>
    /// Creates a new population with constant genes
    /// </summary>
    public class ConstantInitializer<T> : IInitializer<T>
    {
        int geneCount;
        IList<T> consts;

        public ConstantInitializer(int geneCount, IList<T> consts)
        {
            this.geneCount = geneCount;
            this.consts = consts;
        }

        public IEnumerable<IIndividual<T>> Generate(int size, IFitnessFunction<T> fitnessFunction)
        {
            var population = new List<IIndividual<T>>();

            for (var i = 0; i < size; i++)
            {
                population.Add(new Individual<T>(consts));
                population[i].FitnessFunction = fitnessFunction;
            }

            return population;
        }
    }
}