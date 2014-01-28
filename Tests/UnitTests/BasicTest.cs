using EvolveSharp;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BasicTest
    {
        [Test]
        public void BasicBattery()
        {
            var ga = new GeneticAlgorithm(100, 5, new TestFitnessFunction())
            {
                Elitism = true
            };
            ga.Evolve(30000, 0.9999);

            Assert.AreEqual(1, ga.BestIndividual.Fitness, 0.001);
            Assert.AreEqual(0.1, ga.BestIndividual[0], 0.001);
            Assert.AreEqual(0.2, ga.BestIndividual[1], 0.001);
            Assert.AreEqual(0.3, ga.BestIndividual[2], 0.001);
            Assert.AreEqual(0.4, ga.BestIndividual[3], 0.001);
            Assert.AreEqual(0.5, ga.BestIndividual[4], 0.001);
        }
    }
}
