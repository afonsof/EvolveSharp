using System.Collections.Generic;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;
using EvolveSharp.Mutators;
using EvolveSharp.Util;

namespace EvolveSharp.Initializators
{
    /// <summary>
    /// Creates a population with half of genomes exactly reverse each other
    /// </summary>
    public class ComplementaryInitializator : IInitializator
    {
        private readonly IMutator _mutator;
        private readonly int _geneLength;

        public ComplementaryInitializator(IMutator mutator, int geneLength)
        {
            _mutator = mutator;
            _geneLength = geneLength;
        }

        public IEnumerable<IIndividual> Generate(int size, IFitnessFunction fitnessFunction)
        {
            var population = new List<IIndividual>();
           
            for (var i = 0; i < size; i+=2)
            {
                var genes = new List<double>();
                for (int locus = 0; locus < _geneLength; locus++)
                {
                    genes.Add(Helper.Random.NextDouble());
                }
                population.Add(new Individual(genes));
                population[i].SetFitnessFunction(fitnessFunction);

                var individual = (Individual)population[i].Clone();
                _mutator.Mutate(individual);
                population.Add(individual);
                population[i+1].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}
