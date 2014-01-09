using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Mutators;
using EvolveSharp.Util;

namespace EvolveSharp.Initializers
{
    /// <summary>
    /// Creates a population with half of genomes exactly reverse each other
    /// </summary>
    public class ComplementaryInitializer : IInitializer<double>
    {
        private readonly IMutator<double> _mutator;
        private readonly int _geneLength;

        public ComplementaryInitializer(IMutator<double> mutator, int geneLength)
        {
            _mutator = mutator;
            _geneLength = geneLength;
        }

        public IEnumerable<IIndividual<double>> Generate(int size, IFitnessFunction<double> fitnessFunction)
        {
            var population = new List<IIndividual<double>>();
           
            for (var i = 0; i < size; i+=2)
            {
                var genes = new List<double>();
                for (int locus = 0; locus < _geneLength; locus++)
                {
                    genes.Add(Helper.Random.NextDouble());
                }
                population.Add(new Individual<double>(genes));
                population[i].SetFitnessFunction(fitnessFunction);

                var individual = (Individual<double>)population[i].Clone();
                _mutator.Mutate(individual);
                population.Add(individual);
                population[i+1].SetFitnessFunction(fitnessFunction);
            }

            return population;
        }
    }
}
