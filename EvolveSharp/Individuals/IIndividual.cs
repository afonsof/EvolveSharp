using System;
using System.Collections.Generic;
using EvolveSharp.FitnessFunction;

namespace EvolveSharp.Individuals
{
    /// <summary>
    /// Interface to support implementation of several kind of individual
    /// </summary>
    public interface IIndividual : IComparable<IIndividual>, ICloneable
    {
        /// <summary>
        /// Length of individual
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Access each locus of individual
        /// </summary>
        /// <param name="locus">Lower part of individual</param>
        /// <returns>Value this position</returns>
        double this[int locus] { get; set; }

        /// <summary>
        /// Get the gene list
        /// </summary>
        IList<double> Genes { get; }

        /// <summary>
        /// Returns the Fitness of this individual
        /// </summary>
        double Fitness { get; }

        /// <summary>
        /// Compare if the Fitness this individual is equal, smaller or larger than Fitness other individual
        /// </summary>
        /// <param name="other">Individual that want to compare with this</param>
        new int CompareTo(IIndividual other);

        /// <summary>
        /// Compare if the value this individual is equal to vaule other individual
        /// </summary>
        void SetFitnessFunction(IFitnessFunction fitnessFunction);
    }
}
