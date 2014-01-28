using System;
using System.Collections.Generic;
using EvolveSharp.CrossoverMethods;
using EvolveSharp.Individuals;
using EvolveSharp.Initializers;
using EvolveSharp.Mutators;
using EvolveSharp.Reporters;
using EvolveSharp.Selectors;

namespace EvolveSharp
{
    /// <summary>
    /// Controller class of population's generation
    /// </summary>
    public class GeneticAlgorithm : List<IIndividual<double>>
    {
        public bool Elitism { get; set; }
        public ISelector Selector { get; set; }
        public ICrossoverMethod CrossoverMethod { get; set; }
        public IMutator<double> Mutator { get; set; }
        public IFitnessFunction<double> FitnessFunction { get; set; }
        public IInitializer<double> Initializer { get; set; }
        public IReporter Reporter { get; set; }
        public int GenerationIndex { get; set; }

        public Action<GeneticAlgorithm> AfterCallback { get; set; }

        public GeneticAlgorithm(int populationCount, int geneCount, IFitnessFunction<double> fitnessFunction, IMutator<double> mutator = null,
                                IInitializer<double> initializer = null, ICrossoverMethod crossoverMethod = null,
                                ISelector selector = null, IReporter reporter = null)
        {
            GenerationIndex++;

            FitnessFunction = fitnessFunction;
            Mutator = mutator;
            Initializer = initializer;
            Mutator = mutator ?? new RandomMutator();
            Initializer = initializer ?? new EmptyInitializer(geneCount);
            Reporter = reporter ?? new ConsoleReporter();
            CrossoverMethod = crossoverMethod ?? new UniformCrossoverMethod();
            Selector = selector ?? new TournamentSelector();

            Clear();
            var initialPopulation = Initializer.Generate(populationCount, FitnessFunction);
            foreach (var individual in initialPopulation) { Add(individual); }
        }

        /// <summary>
        /// Get the best individual based in the fitness' value
        /// </summary>
        /// <returns>The best Individual</returns>
        public IIndividual<double> BestIndividual
        {
            get
            {
                if (Count <= 0) return null;
                var best = this[0];
                for (var i = 1; i < Count; i++)
                {
                    if (this[i].Fitness > best.Fitness)
                        best = this[i];
                }
                return best;
            }
        }

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
                NextGeneration();
                var bestIndividual = BestIndividual;

                if (AfterCallback != null)
                {
                    AfterCallback(this);
                }

                Reporter.ReportLine("Generation #{0}", GenerationIndex);
                Reporter.ReportLine("  Best Individual: {0}\n  Fitness: {1}\n", bestIndividual.ToString(), bestIndividual.Fitness);

                if (minRateToSuccess > 0 && bestIndividual.Fitness > minRateToSuccess)
                {
                    break;
                }
            }

            Reporter.ReportLine("Evolution finished.");
        }

        #region PrivateMethods
        private void NextGeneration()
        {
            var newGeneration = new List<IIndividual<double>>();

            for (var i = 0; i < Count; i += 2)
            {
                var aux = CrossoverMethod.Crossover(Selector.Select(this), Selector.Select(this));

                Mutator.Mutate(aux.Item1);
                Mutator.Mutate(aux.Item2);

                newGeneration.Add(aux.Item1);
                newGeneration.Add(aux.Item2);

                newGeneration[i].SetFitnessFunction(FitnessFunction);
                newGeneration[i + 1].SetFitnessFunction(FitnessFunction);
            }

            if (newGeneration.Count > Count)
            {
                newGeneration.RemoveAt(Count);
            }

            if (Elitism)
            {
                newGeneration[0] = BestIndividual;
            }

            Clear();
            AddRange(newGeneration);
            GenerationIndex++;
        }
        #endregion
    }
}
