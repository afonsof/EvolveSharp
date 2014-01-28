using System;
using EvolveSharp;
using EvolveSharp.Individuals;

namespace UnitTests
{
    //Search for [0.1, 0.2, 0.3, 0.4, 0.5] individual
    public class TestFitnessFunction : IFitnessFunction<double>
    {
        public double Evaluate(IIndividual<double> individual)
        {
            var d = GetRate(individual[0], 0.1);
            d += GetRate(individual[1], 0.2);
            d += GetRate(individual[2], 0.3);
            d += GetRate(individual[3], 0.4);
            d += GetRate(individual[4], 0.5);

            return d / 5;
        }

        public double GetRate(double value, double target)
        {
            if (value <= target - 1 || value >= target + 1)
            {
                return 0;
            }
            if (Math.Abs(value - target) < 0.0001)
            {
                return 1;
            }
            if (value < target)
            {
                return (value - (target - 1)) / 1;
            }
            return (value - target) / 1;
        }
    }
}