﻿using EvolveSharp.Individuals;

namespace EvolveSharp.Mutators
{
    /// <summary>
    /// Class implements the  interface 'IMutator'.
    /// This kind of Mutation is called of Flip Gene.
    /// It used to Double Individuals. It reverses all genes to value opposite.
    /// </summary>
    public class FlipGeneMutator : IMutator<double>
    {
        /// <summary>
        /// Execute Mutation in the individual for reference
        /// </summary>
        /// <param name="individual">Individual</param>
        public void Mutate(IIndividual<double> individual)
        {
            for (var locus = 0; locus < individual.Length; locus++)
            {
                individual[locus] = (1.0 - individual[locus]);
            }
        }
    }
}
