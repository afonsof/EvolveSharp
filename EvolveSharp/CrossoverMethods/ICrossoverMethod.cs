using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.CrossoverMethods
{
    public interface ICrossoverMethod
    {
        /// <summary>
        /// Execute crossover between two genomes and return other two genomes mixed
        /// </summary>
        /// <param name="inidividual1">Genome</param>
        /// <param name="individual2">Genome</param>
        /// <returns>Two new genomes, that are a mixture of genome1 and genome2</returns>
        IList<IIndividual> Crossover(IIndividual inidividual1, IIndividual individual2);
    }
}
