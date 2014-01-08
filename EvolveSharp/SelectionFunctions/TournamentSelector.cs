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
        /// <param name="geneticAlgorithm">Population with genomes</param>
        /// <returns>The genome chosen</returns>
        public IIndividual Select(IGeneticAlgorithm geneticAlgorithm)
        {
            int genome1 = Helper.Random.Next(0, geneticAlgorithm.Count);
            int genome2 = Helper.Random.Next(0, geneticAlgorithm.Count);

            if (geneticAlgorithm[genome1].CompareTo(geneticAlgorithm[genome2]) < 0)
            {
                return geneticAlgorithm[genome2];
            }
            return geneticAlgorithm[genome1];
        }
    }
}
