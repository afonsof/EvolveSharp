using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveSharp.Randoms
{
    public class IntegerRandom : IRandom<int>
    {
        Random random;

        public IntegerRandom()
        {
            random = new Random();
        }

        public IntegerRandom(int seed)
        {
            random = new Random(seed);
        }

        public int GetNext(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
