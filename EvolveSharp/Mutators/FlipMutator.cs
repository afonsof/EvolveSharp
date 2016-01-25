using EvolveSharp.Individuals;
using EvolveSharp.Randoms;
using System;
using System.Collections.Generic;

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
    public class FlipMutator<T> : IMutator<T>
    {
        double ratePerGene;
        IList<T> mins, maxs;
        IRandom<double> rateRandom;
        Func<T, T, T, T> flip;

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="ratePerGene">Likely to happen Mutation</param>
        public FlipMutator(IList<T> mins, IList<T> maxs, IRandom<double> rateRandom, Func<T, T, T, T> flip, double ratePerGene = 0.5)
        {
            this.mins = mins;
            this.maxs = maxs;
            this.rateRandom = rateRandom;
            this.ratePerGene = ratePerGene;
            this.flip = flip;
        }

        /// <summary>
        /// Execute Mutation in the individual for reference with based in the rate
        /// </summary>
        /// <param name="individual">Individual</param>
        public void Mutate(IIndividual<T> individual)
        {
            for (var locus = 0; locus < individual.Length; locus++)
            {
                if (rateRandom.GetNext(0d, 1d) < ratePerGene)
                    individual.Genes[locus] = flip(mins[locus], maxs[locus], individual.Genes[locus]);
            }
        }
    }
}
