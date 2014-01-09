using System;
using System.Collections.Generic;
using EvolveSharp.Individuals;

namespace EvolveSharp.CrossoverMethods
{

    public class PointCrossoverMethod : ICrossoverMethod
    {
        private readonly List<int> _positions;

        public PointCrossoverMethod(params int[] positions)
        {
            _positions = new List<int> {0};
            foreach (var t in positions)
            {
                _positions.Add(t);
            }
            _positions.Sort();
        }

        public Tuple<IIndividual<T>, IIndividual<T>> Crossover<T>(IIndividual<T> inidividual1, IIndividual<T> individual2)
        {
            _positions.Add(inidividual1.Length);
            var genes1 = new List<T>();
            var genes2 = new List<T>();
            var i = 0;
            var flag = true;
            while (i < _positions.Count - 1)
            {
                for (var index = _positions[i]; index < _positions[i + 1]; index++)
                {
                    if (flag)
                    {
                        genes1.Add(inidividual1[index]);
                        genes2.Add(individual2[index]);
                    }
                    else
                    {
                        genes1.Add(individual2[index]);
                        genes2.Add(inidividual1[index]);
                    }
                }
                flag = !flag;
                i++;
            }
            return new Tuple<IIndividual<T>, IIndividual<T>>(new Individual<T>(genes1), new Individual<T>(genes2));
        }
    }
}