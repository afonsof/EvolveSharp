using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticalCases
{
    class RastriginInteger
    {
        class FitnessFunction : EvolveSharp.IFitnessFunction<int>
        {
            public double Evaluate(EvolveSharp.Individuals.IIndividual<int> individual)
            {
                double x = individual.Genes[0];
                double y = individual.Genes[1];
                return -Functions.Rastrigin(x - 2.1, y - 3.9);
            }
        }

        public static void Run()
        {
            var ga = EvolveSharp.GeneticAlgorithm.CreateInteger(10000, 2, -100, 100, new FitnessFunction());
            ga.Evolve(50);
            Console.ReadKey();
        }
    }
}
