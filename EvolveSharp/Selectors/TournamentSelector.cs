using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.Selectors
{
    /// <summary>
    /// This a kind of Selection called of Tournament.
    /// It chooses two individuals at random and compare between them which has a
    /// better evaluate through the Fitness Function
    /// </summary>
    public class TournamentSelector : ISelector
    {
        /// <summary>
        /// Select one individual of population
        /// </summary>
        /// <param name="population">Population with individuals</param>
        /// <returns>The individual chosen</returns>
        public IIndividual<T> Select<T>(IList<IIndividual<T>> population)
        {
            var index1 = Helper.Random.Next(0, population.Count);
            var index2 = Helper.Random.Next(0, population.Count);

            if (population[index1].CompareTo(population[index2]) < 0)
            {
                return population[index2];
            }
            return population[index1];
        }
    }
}
