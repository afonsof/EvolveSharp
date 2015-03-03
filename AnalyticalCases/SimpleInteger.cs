using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticalCases
{
    class SimpleInteger
    {
        class FitnessFunction : EvolveSharp.IFitnessFunction<int>
        {
            public double Evaluate(EvolveSharp.Individuals.IIndividual<int> individual)
            {
                double x = individual.Genes[0];
                double y = individual.Genes[1];
                double z = (x - 1.1) * (x - 1.1) + (y - 2.6) * (y - 2.6);
                return -z;
            }
        }

        public static void Run()
        {
            var ga = EvolveSharp.GeneticAlgorithm.CreateInteger(1000, 2, 0, 4, new FitnessFunction());
            ga.Evolve(50);
            Console.ReadKey();
        }
    }
}
