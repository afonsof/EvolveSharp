using System;
using System.Collections.Generic;
using EvolveSharp.Individuals;
using EvolveSharp.Util;

namespace EvolveSharp.CrossoverMethods
{
    public class UniformCrossoverMethod : ICrossoverMethod
    {
        private readonly double _ratePerGene;
        private const double RatePerGeneDefault = 0.5;

        public UniformCrossoverMethod()
        {
            _ratePerGene = RatePerGeneDefault;
        }

        public UniformCrossoverMethod(double ratePerGene)
        {
            _ratePerGene = ratePerGene;
        }

        public Tuple<IIndividual<T>, IIndividual<T>> Crossover<T>(IIndividual<T> inidividual1, IIndividual<T> individual2)
        {
            var offspring1 = new List<T>();
            var offspring2 = new List<T>();

            for (var locus = 0; locus < inidividual1.Length; locus++)
            {
                if (Helper.Random.NextDouble() < _ratePerGene)
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
            return new Tuple<IIndividual<T>, IIndividual<T>>(new Individual<T>(offspring1), new Individual<T>(offspring2));
        }
    }
}

