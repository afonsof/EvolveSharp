using System;
using EvolveSharp.Individuals;

namespace EvolveSharp.CrossoverMethods
{
    public interface ICrossoverMethod
    {
        /// <summary>
        /// Execute crossover
        /// </summary>
        /// <param name="inidividual1">Individual</param>
        /// <param name="individual2">Individual</param>
        /// <returns>Two children mixing their parents</returns>
        Tuple<IIndividual<T>,IIndividual<T>>  Crossover<T>(IIndividual<T> inidividual1, IIndividual<T> individual2);
    }
}
