using EvolveSharp.CrossoverMethods;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;
using EvolveSharp.Initializators;
using EvolveSharp.Mutators;
using EvolveSharp.SelectionFunctions;
using EvolveSharp.Util;

namespace EvolveSharp
{
    /// <summary>
    /// Interface to support implementation of populations
    /// </summary>
    public interface IGeneticAlgorithm
    {
        bool Elitism { get; set; }
        ISelector Selector { get; set; }
        ICrossoverMethod CrossoverMethod { get; set; }
        IMutator Mutator { get; set; }
        IFitnessFunction FitnessFunction { get; set; }
        IInitializator Initializator { get; set; }
        IReporter Reporter { get; set; }

        /// <summary>
        /// Access each genome of population
        /// </summary>
        /// <param name="index">index of individual in the population</param>
        /// <returns>the individual with the corresponding index</returns>
        IIndividual this[int index] { get; set; }

        /// <summary>
        /// Return the size of population
        /// </summary>
        int Count { get; }

        /// <summary>
        ///  Do the evolution
        /// </summary>
        /// <param name="generationCount">Number of generations to evolve</param>
        /// <param name="minRateToSuccess"></param>
        void Evolve(int generationCount, double minRateToSuccess);

        /// <summary>
        /// Get the best individual based in the fitness' value
        /// </summary>
        /// <returns>the best genome</returns>
        IIndividual BestIndividual { get; }
    }
}
