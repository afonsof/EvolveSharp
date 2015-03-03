using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.Selectors
{
    /// <summary>
    /// Interface to support implementation of several selection Methods.
    /// </summary>
    public interface ISelector<T>
    {
        /// <summary>
        /// Select one individual of population
        /// </summary>
        /// <param name="population">population which want to select a individual</param>
        /// <returns>The individual selected</returns>
        IIndividual<T> Select(IList<IIndividual<T>> population);
    }
}