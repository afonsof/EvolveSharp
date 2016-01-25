using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveSharp.Randoms
{
    public class BooleanRandom : IRandom<bool>
    {
        Random random;

        public BooleanRandom()
        {
            random = new Random();
        }

        public BooleanRandom(int seed)
        {
            random = new Random(seed);
        }

        public bool GetNext(bool min, bool max)
        {
            return random.Next(min ? 1 : 0, max ? 2 : 1) != 0;
        }
    }
}
