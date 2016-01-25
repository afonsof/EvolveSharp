using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveSharp.Mutators
{
    public static class Flipper
    {
        static int Integer(int min, int max, int val)
        {
            return max - (val - min);
        }

        static double Double(double min, double max, double val)
        {
            return max - (val - min);
        }

        static bool Boolean(bool min, bool max, bool val)
        {
            return !min && max ? !val : val;
        }
    }
}
