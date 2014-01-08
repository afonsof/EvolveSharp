using EvolveSharp.Individuals;

namespace EvolveSharp.Mutators
{
    /// <summary>
    /// Interface to support implementation of several Mutation Methods.
    /// </summary>
    /// <example>FlipGeneMutator.cs, RandomMutator.cs and UniformMutator</example>
    public interface IMutator
    {
        void Mutate(IIndividual individual);
    }
}
