using System;
using EvolveSharp.Individuals;

namespace EvolveSharp.CrossoverMethods
{
    public interface ICrossoverMethod
    {
        /// <summary>
        /// Performs a crossover between two individuals
        /// </summary>
        /// <param name="individual1">Individual</param>
        /// <param name="individual2">Individual</param>
        /// <returns>Two sons of individuals</returns>
        Tuple<IIndividual<T>,IIndividual<T>>  Crossover<T>(IIndividual<T> individual1, IIndividual<T> individual2);
    }
}
