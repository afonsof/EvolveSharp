using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.CrossoverMethods
{
    /// <summary>
    /// Class implements the  interface 'ICrossoverMethod'.
    /// This kind of Crossover is called of Several Points.
    /// It mixes the two genomes received based in specific points set as a parameter: 'positions'. 
    /// The intervals between the points are changed alternating between genenome1 and genome2
    /// </summary>
    public class PointCrossoverMethod : ICrossoverMethod
    {
        private readonly List<int> _positions;

        /// <summary>
        /// Builder create a list of positions where the cut should be done to execute the
        /// crossover
        /// </summary>
        /// <param name="positions">Cutting positions of genome</param>
        public PointCrossoverMethod(params int[] positions)
        {
            _positions = new List<int> {0};
            foreach (var t in positions)
            {
                _positions.Add(t);
            }
            _positions.Sort();
        }

        /// <summary>
        /// Execute crossover between two genomes and return other two genomes mixed
        /// </summary>
        /// <param name="inidividual1">Genome</param>
        /// <param name="individual2">Genome</param>
        /// <returns>Two new genomes, that are a mixture of genome1 and genome2</returns>
        public IList<IIndividual> Crossover(IIndividual inidividual1, IIndividual individual2)
        {
            _positions.Add(inidividual1.Length);
            var offspring1 = new List<double>();
            var offspring2 = new List<double>();
            var contParams = 0;
            var aux = true;
            while (contParams < _positions.Count - 1)
            {
                for (int locus = _positions[contParams]; locus < _positions[contParams + 1]; locus++)
                {
                    if (aux)
                    {
                        offspring1.Add(inidividual1[locus]);
                        offspring2.Add(individual2[locus]);
                    }
                    else
                    {
                        offspring1.Add(individual2[locus]);
                        offspring2.Add(inidividual1[locus]);
                    }
                }
                aux = !aux;
                contParams++;
            }
            return new List<IIndividual>
            {
                new Individual(offspring1),
                new Individual(offspring2)
            };
        }
    }
}