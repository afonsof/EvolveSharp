using System.Collections.Generic;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;

namespace EvolveSharp.Initializators
{
    /// <summary>
    /// Interface to support implementation of population.
    /// </summary>
    public interface IInitializator
    {
        /// <summary>
        /// Creates a population based in a size
        /// </summary>
        /// <param name="size">Number of genomes should be in this population</param>
        /// <param name="fitnessFunction">Population's fitness function</param>
        /// <returns></returns>
        IEnumerable<IIndividual> Generate(int size, IFitnessFunction fitnessFunction);
    }
}
