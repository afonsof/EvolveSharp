using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveSharp.Randoms
{
    public class DoubleRandom : IRandom<double>
    {
        Random random;

        public DoubleRandom()
        {
            random = new Random();
        }

        public DoubleRandom(int seed)
        {
            random = new Random(seed);
        }

        public double GetNext(double min, double max)
        {
            return min + random.NextDouble() * (max - min);
        }
    }
}
