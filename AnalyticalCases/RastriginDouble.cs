using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticalCases
{
    class RastriginDouble
    {
        class FitnessFunction : EvolveSharp.IFitnessFunction<double>
        {
            public double Evaluate(EvolveSharp.Individuals.IIndividual<double> individual)
            {
                double x = individual.Genes[0];
                double y = individual.Genes[1];
                return -Functions.Rastrigin(x - 2.1, y - 3.9);
                // return -Functions.Rastrigin(x, y);
            }
        }

        public static void Run()
        {
            var ga = EvolveSharp.GeneticAlgorithm.CreateDouble(10000, 2, -80, 80, new FitnessFunction());
            //ga.Crossover = new EvolveSharp.Crossovers.ScatteredCrossover<double>(new EvolveSharp.Randoms.BooleanRandom(), 2);
            ga.Evolve(50);
            Console.ReadKey();
        }
    }
}
