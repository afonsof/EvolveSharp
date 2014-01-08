using System.Collections.Generic;
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
    /// Controller class of population's generation
    /// </summary>
    public class GeneticAlgorithm : List<IIndividual>, IGeneticAlgorithm
    {
        public bool Elitism { get; set; }
        public ISelector Selector { get; set; }
        public ICrossoverMethod CrossoverMethod { get; set; }
        public IMutator Mutator { get; set; }
        public IFitnessFunction FitnessFunction { get; set; }
        public IInitializator Initializator { get; set; }
        public IReporter Reporter { get; set; }

        private int _generation;
        private readonly int _populationCount;
        private readonly int _geneCount;

        public GeneticAlgorithm(int populationCount, int geneCount, IFitnessFunction fitnessFunction)
        {
            FitnessFunction = fitnessFunction;
            _populationCount = populationCount;
            _geneCount = geneCount;
            _generation++;
        }

        public IIndividual BestIndividual
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
            Init();
            Reporter.ReportLine("Starting evolution...");

            for (var i = 0; i < generationCount; i++)
            {
                NextGeneration();
                var bestIndividual = BestIndividual;
                Reporter.ReportLine("Generation #{0}", _generation);
                Reporter.ReportLine("  Best Individual: {0}\n  Fitness: {1}\n", bestIndividual.ToString(), bestIndividual.Fitness);

                if (minRateToSuccess > 0 && bestIndividual.Fitness > minRateToSuccess)
                {
                    break;
                }
            }

            Reporter.ReportLine("Evolution finished.");
        }

        #region PrivateMethods

        private void Init()
        {
            if (Selector == null)
            {
                Selector = new TournamentSelector();
            }
            if (CrossoverMethod == null)
            {
                CrossoverMethod = new UniformCrossoverMethod();
            }
            if (Mutator == null)
            {
                Mutator = new RandomMutator();
            }
            if (Reporter == null)
            {
                Reporter = new ConsoleReporter();
            }
            if (Initializator == null)
            {
                //todo:
                Initializator = new RandomInitializator(_geneCount);
            }
            Clear();
            var initialPopulation = Initializator.Generate(_populationCount, FitnessFunction);
            foreach (var individual in initialPopulation)
            {
                Add(individual);
            }
        }

        private void NextGeneration()
        {
            var newGeneration = new List<IIndividual>();

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
            _generation++;
        }

        #endregion
    }
}
