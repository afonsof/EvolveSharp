using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EvolveSharp.Individuals;

namespace EvolveSharp.Samples.Tsp
{
    class TsmFitnessFunction : IFitnessFunction<double>
    {
        private readonly List<Point> _travelingSalesman;

        public TsmFitnessFunction(List<Point> travelingSalesman)
        {
            _travelingSalesman = travelingSalesman;
        }

        public double Evaluate(IIndividual<double> individual)
        {
            var sortedNums = new List<KeyValuePair<int, double>>();

            for (var i = 0; i < _travelingSalesman.Count; i++)
            {
                sortedNums.Add(new KeyValuePair<int, double>(i, individual.Genes[i]));
            }
            sortedNums = sortedNums.OrderBy(n => n.Value).ToList();

            var totalDistance = 0.0;

            for (var i = 0; i < sortedNums.Count - 1; i++)
            {
                var firstOne = _travelingSalesman[sortedNums[i].Key];
                var secondOne = _travelingSalesman[sortedNums[i + 1].Key];
                totalDistance += DistanceTo(firstOne, secondOne);
            }
            return -totalDistance;
        }

        private static double DistanceTo(Point pointA, Point pointB)
        {
            return Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2);
        }
    }
}