using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.SelectionFunctions
{
    /// <summary>
    /// This a kind of Selection called of Tournament.
    /// It chooses two genomes at random and compare between them which has a
    /// better evaluate through the Fitness Function
    /// </summary>
    public class TournamentSelector : ISelector
    {
        /// <summary>
        /// Select one genome of population
        /// </summary>
        /// <param name="population">Population with genomes</param>
        /// <returns>The genome chosen</returns>
        public IIndividual<T> Select<T>(IList<IIndividual<T>> population)
        {
            var genome1 = Helper.Random.Next(0, population.Count);
            var genome2 = Helper.Random.Next(0, population.Count);

            if (population[genome1].CompareTo(population[genome2]) < 0)
            {
                return population[genome2];
            }
            return population[genome1];
        }
    }
}
