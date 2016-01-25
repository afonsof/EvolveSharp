using System;
using System.Linq;
using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.Crossovers
{

    public class PointCrossover<T> : ICrossover<T>
    {
        private readonly List<int> positions;

        public PointCrossover(params int[] positions)
        {
            this.positions = new List<int> { 0 };
            this.positions.AddRange(positions.OrderBy(x => x));
        }

        public Tuple<IIndividual<T>, IIndividual<T>> Crossover(IIndividual<T> individual1, IIndividual<T> individual2)
        {
            positions.Add(individual1.Length);
            var genes1 = new List<T>();
            var genes2 = new List<T>();
            var i = 0;
            var flag = true;
            while (i < positions.Count - 1)
            {
                for (var index = positions[i]; index < positions[i + 1]; index++)
                {
                    if (flag)
                    {
                        genes1.Add(individual1.Genes[index]);
                        genes2.Add(individual2.Genes[index]);
                    }
                    else
                    {
                        genes1.Add(individual2.Genes[index]);
                        genes2.Add(individual1.Genes[index]);
                    }
                }
                flag = !flag;
                i++;
            }
            return new Tuple<IIndividual<T>, IIndividual<T>>(new Individual<T>(genes1), new Individual<T>(genes2));
        }
    }
}