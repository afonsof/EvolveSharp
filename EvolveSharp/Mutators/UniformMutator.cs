using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.Mutators
{
    /// <summary>
    /// Class implements the  interface 'IMutator'.
    /// This kind of Mutation is called of Uniform.
    /// It change the value of gene for a random gene value based in a rate set as a 
    /// parameter: 'ratePerGene'.
    /// All of genes are analized and for each of them a Random number is generated, so 
    /// according to the rate parameter is decided if this bit will be changed for other 
    /// value or if remains the same.
    /// </summary>
    public class UniformMutator : IMutator<double>
    {
        private readonly double _ratePerGene;
        private const double RatePerGeneDefault = 0.5;

        /// <summary>
        /// Builder set 'ratePerGene' with a Default value
        /// </summary>
        public UniformMutator()
        {
            _ratePerGene = RatePerGeneDefault;
        }

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="ratePerGene">Likely to happen Mutation</param>
        public UniformMutator(double ratePerGene)
        {
            _ratePerGene = ratePerGene;
        }

        /// <summary>
        /// Execute Mutation in the individual for reference with based in the rate
        /// </summary>
        /// <param name="individual">Genome</param>
        public void Mutate(IIndividual<double> individual)
        {
            for(var locus = 0; locus < individual.Length; locus++)
            {                
                if (Helper.Random.NextDouble() < _ratePerGene)
                    individual[locus] = (1.0 - individual[locus]);
            }
        }
    }
}
