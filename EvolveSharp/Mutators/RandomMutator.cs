using EvolveSharp.Individuals;
using EvolveSharp.Randoms;
using System.Collections.Generic;

namespace EvolveSharp.Mutators
{
    /// <summary>
    /// Class implements the interface 'IMutator'.
    /// This kind of Mutation is called of Random.
    /// Using the parameter 'RateMutation' is decided if should happen a mutation or not.
    /// If true, so is chosen a random gene to change its value.
    /// </summary>
    public class RandomMutator<T> : IMutator<T>
    {
        double rateMutation;
        IList<T> mins, maxs;
        IRandom<T> geneRandom;
        IRandom<double> rateRandom;
        IRandom<int> locusRandom;

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="rateMutation">Likely to happen Mutation</param>
        public RandomMutator(IList<T> mins, IList<T> maxs, IRandom<T> geneRandom,
            IRandom<double> rateRandom, IRandom<int> locusRandom, double rateMutation = 0.1)
        {
            this.mins = mins;
            this.maxs = maxs;
            this.rateRandom = rateRandom;
            this.geneRandom = geneRandom;
            this.locusRandom = locusRandom;
            this.rateMutation = rateMutation;
        }

        /// <summary>
        /// Execute Mutation in the individual for reference with based in the rate
        /// </summary>
        /// <param name="individual">Individual</param>
        public void Mutate(IIndividual<T> individual)
        {
            if (rateRandom.GetNext(0d, 1d) < rateMutation)
            {
                var locus = locusRandom.GetNext(0, individual.Length);
                individual.Genes[locus] = geneRandom.GetNext(mins[locus], maxs[locus]);
            }
        }
    }
}