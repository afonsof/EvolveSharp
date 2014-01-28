using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.Mutators
{
    /// <summary>
    /// Class implements the interface 'IMutator'.
    /// This kind of Mutation is called of Random.
    /// Using the parameter 'RateMutation' is decided if should happen a mutation or not.
    /// If true, so is chosen a random gene to change its value.
    /// </summary>
    public class RandomMutator : IMutator<double>
    {
        private readonly double _rateMutation;
        private const double RateMutationDefault = 0.1;

        /// <summary>
        /// Builder set 'RateMutation' with a Default value
        /// </summary>
        public RandomMutator()
        {
            _rateMutation = RateMutationDefault;
        }

        /// <summary>
        /// Builder set 'ratePerGene' with a parameter passed by the user
        /// </summary>
        /// <param name="rateMutation">Likely to happen Mutation</param>
        public RandomMutator(double rateMutation)
        {
            _rateMutation = rateMutation;
        }

        /// <summary>
        /// Execute Mutation in the individual for reference with based in the rate
        /// </summary>
        /// <param name="individual">Individual</param>
        public void Mutate(IIndividual<double> individual)
        {
            if (Helper.Random.NextDouble() < _rateMutation)
            {
                var locus = Helper.Random.Next(individual.Length);
                individual[locus] = Helper.Random.NextDouble();
            }
        }
    }
}