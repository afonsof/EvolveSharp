using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticalCases
{
    class RosenbrockDouble
    {
        class FitnessFunction : EvolveSharp.IFitnessFunction<double>
        {
            public double Evaluate(EvolveSharp.Individuals.IIndividual<double> individual)
            {
                double x = individual.Genes[0];
                double y = individual.Genes[1];
                return -Functions.Rosenbrock(x - 2.1, y - 3.9);
            }
        }

        public static void Run()
        {
            var ga = EvolveSharp.GeneticAlgorithm.CreateDouble(100000, 2, -10, 10, new FitnessFunction());
            ga.Evolve(50);
            Console.ReadKey();
        }
    }
}
