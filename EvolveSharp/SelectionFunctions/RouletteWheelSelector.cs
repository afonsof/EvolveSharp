using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.SelectionFunctions
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
        /// <param name="geneticAlgorithm">Population with genomes</param>
        /// <returns>The genome chosen</returns>
        public IIndividual Select(IGeneticAlgorithm geneticAlgorithm)
        {
            var tournament = Helper.Random.NextDouble();
            double aux = 0;
            double sum = 0;

            for (var i = 0; i < geneticAlgorithm.Count; i++)
            {
                sum += geneticAlgorithm[i].Fitness;
            }

            for (var i = 0; i < geneticAlgorithm.Count; i++)
            {
                aux += geneticAlgorithm[i].Fitness / sum;
                if (tournament <= aux)
                {
                    return geneticAlgorithm[i];
                }
            }

            return null;
        }
    }
}
