using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Randoms;

namespace EvolveSharp.Selectors
{
    /// <summary>
    /// This a kind of Selection called of Tournament.
    /// It chooses two individuals at random and compare between them which has a
    /// better evaluate through the Fitness Function
    /// </summary>
    public class TournamentSelector<T> : ISelector<T>
    {
        IRandom<int> random;

        public TournamentSelector(IRandom<int> random)
        {
            this.random = random;
        }

        /// <summary>
        /// Select one individual of population
        /// </summary>
        /// <param name="population">Population with individuals</param>
        /// <returns>The individual chosen</returns>
        public IIndividual<T> Select(IList<IIndividual<T>> population)
        {
            var index1 = random.GetNext(0, population.Count);
            var index2 = random.GetNext(0, population.Count);

            if (population[index1].CompareTo(population[index2]) > 0)
                return population[index1];
            else
                return population[index2];
        }
    }
}
