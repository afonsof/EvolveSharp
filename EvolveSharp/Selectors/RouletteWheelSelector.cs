using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.Selectors
{
    /// <summary>
    /// This a kind of Selection called of Roulette Wheel.
    /// It chooses a genome at random using the Fitness function as a weight of choice
    /// </summary>
    public class RouletteWheelSelector : ISelector
    {
        /// <summary>
        /// Select one genome of population
        /// </summary>
        /// <param name="population">Population with genomes</param>
        /// <returns>The genome chosen</returns>
        public IIndividual<T> Select<T>(IList<IIndividual<T>> population)
        {
            var tournament = Helper.Random.NextDouble();
            double aux = 0;
            double sum = 0;

            for (var i = 0; i < population.Count; i++)
            {
                sum += population[i].Fitness;
            }

            for (var i = 0; i < population.Count; i++)
            {
                aux += population[i].Fitness / sum;
                if (tournament <= aux)
                {
                    return population[i];
                }
            }

            return null;
        }
    }
}
