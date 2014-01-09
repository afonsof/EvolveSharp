using System;
using System.Collections.Generic;
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
    /// Controller class of population's generation
    /// </summary>
    public class GeneticAlgorithm<T> : List<IIndividual<T>>, IGeneticAlgorithm<T>
    {
        public bool Elitism { get; set; }
        public ISelector Selector { get; set; }
        public ICrossoverMethod CrossoverMethod { get; set; }
        public IMutator<T> Mutator { get; set; }
        public IFitnessFunction<T> FitnessFunction { get; set; }
        public IInitializer<T> Initializer { get; set; }
        public IReporter Reporter { get; set; }

        private int _generationIndex;
        public Action<IIndividual<T>> AfterCallback { get; set; }

        public GeneticAlgorithm(int populationCount, IFitnessFunction<T> fitnessFunction, IMutator<T> mutator,
                                IInitializer<T> initializer, ICrossoverMethod crossoverMethod = null,
                                ISelector selector = null, IReporter reporter = null)
        {
            _generationIndex++;

            FitnessFunction = fitnessFunction;
            Mutator = mutator;
            Initializer = initializer;

            Reporter = reporter ?? new ConsoleReporter();
            CrossoverMethod = crossoverMethod ?? new UniformCrossoverMethod();
            Selector = selector ?? new TournamentSelector();

            Clear();
            var initialPopulation = Initializer.Generate(populationCount, FitnessFunction);
            foreach (var individual in initialPopulation) { Add(individual); }
        }

        public IIndividual<T> BestIndividual
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

        public void Evolve(int generationCount, double minRateToSuccess = 0)
        {
            Reporter.ReportLine("Starting evolution...");

            for (var i = 0; i < generationCount; i++)
            {
                NextGeneration();
                var bestIndividual = BestIndividual;

                if (AfterCallback != null)
                {
                    AfterCallback(bestIndividual);
                }

                Reporter.ReportLine("Generation #{0}", _generationIndex);
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
            var newGeneration = new List<IIndividual<T>>();

            for (var i = 0; i < Count; i += 2)
            {
                var aux = CrossoverMethod.Crossover(Selector.Select(this), Selector.Select(this));

                Mutator.Mutate(aux[0]);
                Mutator.Mutate(aux[1]);

                newGeneration.Add(aux[0]);
                newGeneration.Add(aux[1]);

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
            _generationIndex++;
        }
        #endregion
    }
}
