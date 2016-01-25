using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Randoms;

namespace EvolveSharp.Selectors
{
    /// <summary>
    /// This a kind of Selection called of Roulette Wheel.
    /// It chooses a individual at random using the Fitness function as a weight of choice
    /// </summary>
    public class RouletteWheelSelector<T> : ISelector<T>
    {
        IRandom<double> random;

        public RouletteWheelSelector(IRandom<double> random)
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
            var tournament = random.GetNext(0d, 1d);
            double aux = 0;
            double sum = 0;

            for (var i = 0; i < population.Count; i++)
                sum += population[i].Fitness;

            for (var i = 0; i < population.Count; i++)
            {
                aux += population[i].Fitness / sum;
                if (tournament <= aux)
                    return population[i];
            }

            return null;
        }
    }
}
