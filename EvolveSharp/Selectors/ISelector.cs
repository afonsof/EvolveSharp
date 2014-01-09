﻿using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.Selectors
{
    /// <summary>
    /// Interface to support implementation of several selection Methods.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Select a genome of population
        /// </summary>
        /// <param name="geneticAlgorithm">population which want to select a genome</param>
        /// <returns>the genome selected</returns>
        IIndividual<T> Select<T>(IList<IIndividual<T>> population);
    }
}