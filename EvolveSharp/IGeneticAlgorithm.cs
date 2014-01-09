using EvolveSharp.CrossoverMethods;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;
using EvolveSharp.Initializators;
using EvolveSharp.Mutators;
using EvolveSharp.Reporters;
using EvolveSharp.SelectionFunctions;
using EvolveSharp.Util;

namespace EvolveSharp
{
    /// <summary>
    /// Interface to support implementation of populations
    /// </summary>
    public interface IGeneticAlgorithm<T>
    {
        bool Elitism { get; set; }
        ISelector Selector { get; set; }
        ICrossoverMethod CrossoverMethod { get; set; }
        IMutator<T> Mutator { get; set; }
        IFitnessFunction<T> FitnessFunction { get; set; }
        IInitializer<T> Initializer { get; set; }
        IReporter Reporter { get; set; }

        /// <summary>
        /// Access each genome of population
        /// </summary>
        /// <param name="index">index of individual in the population</param>
        /// <returns>the individual with the corresponding index</returns>
        IIndividual<T> this[int index] { get; set; }

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
        IIndividual<T> BestIndividual { get; }
    }
}
