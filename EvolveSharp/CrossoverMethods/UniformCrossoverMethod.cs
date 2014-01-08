using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.CrossoverMethods
{
    /// <summary>
    /// Class implements the  interface 'ICrossoverMethod'.
    /// This kind of Crossover is called of Uniform.
    /// It mixes the two genomes received based in a rate set as a parameter: 'ratePerLocus'.
    /// All of genes are analized and for each of them a Random number is generated, so 
    /// according to the rate parameter is decided if this locus will be changed for other 
    /// corresponding gene between genome1 and genome2 or if this gene remains the same.
    /// </summary>
    public class UniformCrossoverMethod : ICrossoverMethod
    {
        private readonly double _ratePerGene;
        private const double RatePerGeneDefault = 0.5;

        /// <summary>
        /// Builder set 'ratePerGene' with a Default value
        /// </summary>
        public UniformCrossoverMethod()
        {
            _ratePerGene = RatePerGeneDefault;
        }

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="ratePerGene">Likely to happen Crossover</param>
        public UniformCrossoverMethod(double ratePerGene)
        {
            _ratePerGene = ratePerGene;
        }

        /// <summary>
        /// Execute crossover between two genomes and return other two genomes mixed
        /// </summary>
        /// <param name="inidividual1">Genome</param>
        /// <param name="individual2">Genome</param>
        /// <returns>Two new genomes, that are a mixture of genome1 and genome2</returns>
        public IList<IIndividual> Crossover(IIndividual inidividual1, IIndividual individual2)
        {
            var offspring1 = new List<double>();
            var offspring2 = new List<double>();

            for (var locus = 0; locus < inidividual1.Length; locus++)
            {
                if (Helper.Random.NextDouble() < _ratePerGene)
                {
                    offspring1.Add(inidividual1[locus]);
                    offspring2.Add(individual2[locus]);
                }
                else
                {
                    offspring1.Add(individual2[locus]);
                    offspring2.Add(inidividual1[locus]);
                }
            }

            return new List<IIndividual>
            {
                new Individual(offspring1),
                new Individual(offspring2)
            };
        }
    }
}

