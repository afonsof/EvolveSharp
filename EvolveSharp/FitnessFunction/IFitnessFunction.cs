using EvolveSharp.Individuals;

namespace EvolveSharp.FitnessFunction
{
    /// <summary>
    /// Interface to support implementation of Fitness function
    /// </summary>
    public interface IFitnessFunction
    {
        /// <summary>
        /// Calculates the value of Fitness function
        /// </summary>
        /// <param name="individual">The individual that have calculated the Fitness</param>
        /// <returns>Fitness' value</returns>
        double Evaluate(IIndividual individual);
    }
}
