using System;
using System.Collections.Generic;
using EvolveSharp.Crossovers;
using EvolveSharp.Individuals;
using EvolveSharp.Initializers;
using EvolveSharp.Mutators;
using EvolveSharp.Reporters;
using EvolveSharp.Selectors;
using System.Linq;
using EvolveSharp.Randoms;

namespace EvolveSharp
{
    /// <summary>
    /// Controller class of population's generation
    /// </summary>
    public class GeneticAlgorithm<T>
    {
        public List<IIndividual<T>> Individuals { get; private set; }
        public int EliteCount { get; set; }
        public double CrossoverFraction { get; set; }
        public ISelector<T> Selector { get; set; }
        public ICrossover<T> Crossover { get; set; }
        public IMutator<T> Mutator { get; set; }
        public IFitnessFunction<T> FitnessFunction { get; set; }
        public IInitializer<T> Initializer { get; set; }
        public IReporter Reporter { get; set; }
        public int GenerationIndex { get; set; }

        public Action<GeneticAlgorithm<T>> AfterCallback { get; set; }

        public GeneticAlgorithm(int populationCount,
                                int geneCount,
                                IFitnessFunction<T> fitnessFunction,
                                IInitializer<T> initializer,
                                IMutator<T> mutator,
                                ICrossover<T> crossover,
                                ISelector<T> selector,
                                IReporter reporter,
                                int eliteCount = 2,
                                double crossoverFraction = 0.8)
        {
            Individuals = new List<IIndividual<T>>();
            FitnessFunction = fitnessFunction;
            Initializer = initializer;
            Mutator = mutator;
            Crossover = crossover;
            Selector = selector;
            Reporter = reporter;

            EliteCount = eliteCount;
            CrossoverFraction = crossoverFraction;

            Individuals.AddRange(Initializer.Generate(populationCount, FitnessFunction));
        }

        IIndividual<T> getBestIndividual()
        {
            if (Individuals.Count <= 0) return null;
            return Individuals.Aggregate((x1, x2) => x1.Fitness > x2.Fitness ? x1 : x2);
        }

        /// <summary>
        /// Get the best individual based in the fitness' value
        /// </summary>
        /// <returns>The best Individual</returns>
        public IIndividual<T> BestIndividual { get; private set; }

        /// <summary>
        ///  Do the evolution
        /// </summary>
        /// <param name="generationCount">Number of generations to evolve</param>
        /// <param name="minRateToSuccess"></param>
        public void Evolve(int generationCount, double minRateToSuccess = 0)
        {
            Reporter.ReportLine("Starting evolution...");

            for (var i = 0; i < generationCount; i++)
            {
                nextGeneration();
                BestIndividual = getBestIndividual();

                if (AfterCallback != null) AfterCallback(this);

                Reporter.ReportLine("Generation #{0}", GenerationIndex);
                Reporter.ReportLine("  Best Individual: {0}\n  Fitness: {1}\n", BestIndividual, BestIndividual.Fitness);

                if (minRateToSuccess > 0 && BestIndividual.Fitness > minRateToSuccess)
                    break;
            }

            Reporter.ReportLine("Evolution finished.");
        }

        void nextGeneration()
        {
            var newGeneration = new List<IIndividual<T>>();

            if (EliteCount > 0)
                newGeneration.AddRange(Individuals.OrderByDescending(x => x.Fitness).Take(EliteCount));

            var crossOverCount = CrossoverFraction * (Individuals.Count - EliteCount) + 1;
            for (var i = 0; i < crossOverCount; i += 2)
            {
                var aux = Crossover.Crossover(Selector.Select(Individuals), Selector.Select(Individuals));

                aux.Item1.FitnessFunction = FitnessFunction;
                aux.Item2.FitnessFunction = FitnessFunction;

                newGeneration.Add(aux.Item1);
                newGeneration.Add(aux.Item2);
            }

            if (newGeneration.Count > Individuals.Count)
                newGeneration.RemoveAt(Individuals.Count);

            var remainingCount = Individuals.Count - newGeneration.Count;
            for (var i = 0; i < remainingCount; ++i)
            {
                var aux = (IIndividual<T>)Selector.Select(Individuals).Clone();
                Mutator.Mutate(aux);
                aux.FitnessFunction = FitnessFunction;

                newGeneration.Add(aux);
            }

            Individuals.Clear();
            Individuals.AddRange(newGeneration);
            GenerationIndex++;
        }
    }

    public static class GeneticAlgorithm
    {
        public static GeneticAlgorithm<double> CreateDouble(int populationCount,
                                                     int geneCount,
                                                     double min,
                                                     double max,
                                                     IFitnessFunction<double> fitnessFunction,
                                                     IMutator<double> mutator = null,
                                                     IInitializer<double> initializer = null,
                                                     ICrossover<double> crossover = null,
                                                     ISelector<double> selector = null,
                                                     IReporter reporter = null)
        {
            var mins = Enumerable.Repeat(min, geneCount).ToList();
            var maxs = Enumerable.Repeat(max, geneCount).ToList();

            var dRandom = new DoubleRandom();
            var iRandom = new IntegerRandom();

            mutator = mutator ?? new RandomMutator<double>(mins, maxs, dRandom, dRandom, iRandom);
            initializer = initializer ?? new RandomInitializer<double>(geneCount, mins, maxs, dRandom);
            reporter = reporter ?? new ConsoleReporter();
            crossover = crossover ?? new UniformCrossover<double>(dRandom);
            selector = selector ?? new TournamentSelector<double>(iRandom);

            return new GeneticAlgorithm<double>(populationCount, geneCount, fitnessFunction, initializer, mutator, crossover, selector, reporter);
        }

        public static GeneticAlgorithm<int> CreateInteger(int populationCount,
                                                          int geneCount,
                                                          int min,
                                                          int max,
                                                          IFitnessFunction<int> fitnessFunction,
                                                          IMutator<int> mutator = null,
                                                          IInitializer<int> initializer = null,
                                                          ICrossover<int> crossover = null,
                                                          ISelector<int> selector = null,
                                                          IReporter reporter = null)
        {
            var mins = Enumerable.Repeat(min, geneCount).ToList();
            var maxs = Enumerable.Repeat(max, geneCount).ToList();

            var dRandom = new DoubleRandom();
            var iRandom = new IntegerRandom();

            mutator = mutator ?? new RandomMutator<int>(mins, maxs, iRandom, dRandom, iRandom);
            initializer = initializer ?? new RandomInitializer<int>(geneCount, mins, maxs, iRandom);
            reporter = reporter ?? new ConsoleReporter();
            crossover = crossover ?? new UniformCrossover<int>(dRandom);
            selector = selector ?? new TournamentSelector<int>(iRandom);

            return new GeneticAlgorithm<int>(populationCount, geneCount, fitnessFunction, initializer, mutator, crossover, selector, reporter);
        }
    }
}
