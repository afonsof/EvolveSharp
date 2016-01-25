using EvolveSharp.Individuals;
using EvolveSharp.Randoms;
using System;
using System.Collections.Generic;

namespace EvolveSharp.Mutators
{
    /// <summary>
    /// Class implements the  interface 'IMutator'.
    /// This kind of Mutation is called of Flip Gene.
    /// It used to Double Individuals. It reverses all genes to value opposite.
    /// </summary>
    public class FlipAllMutator<T> : IMutator<T>
    {
        IList<T> mins, maxs;
        IRandom<double> rateRandom;
        Func<T, T, T, T> flip;

        public FlipAllMutator(IList<T> mins, IList<T> maxs, IRandom<double> rateRandom, Func<T, T, T, T> flip)
        {
            this.mins = mins;
            this.maxs = maxs;
            this.rateRandom = rateRandom;
            this.flip = flip;
        }

        /// <summary>
        /// Execute Mutation in the individual for reference
        /// </summary>
        /// <param name="individual">Individual</param>
        public void Mutate(IIndividual<T> individual)
        {
            for (var locus = 0; locus < individual.Length; locus++)
                individual.Genes[locus] = flip(mins[locus], maxs[locus], individual.Genes[locus]);
        }
    }
}
