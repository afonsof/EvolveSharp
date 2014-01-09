using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EvolveSharp.CrossoverMethods;
using EvolveSharp.Individuals;
using EvolveSharp.Initializators;
using EvolveSharp.Mutators;
using EvolveSharp.SelectionFunctions;

namespace EvolveSharp.Samples.Tsp
{
    public partial class Form1 : Form
    {
        private static List<Point> _travelingSalesman = new List<Point>();
        private const int NumNodes = 30;
        private const int MapSize = 200;
        private readonly Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitNodes()
        {
            _travelingSalesman = new List<Point>();
            for (var i = 0; i < NumNodes; i++)
            {
                _travelingSalesman.Add(new Point((int)(_random.NextDouble() * MapSize), (int)(_random.NextDouble() * MapSize)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitNodes();
            var graphics = panel1.CreateGraphics();

            var ga = new GeneticAlgorithm<double>(300, new TsmFitnessFunction(_travelingSalesman), new RandomMutator(0.7), new EmptyInitializer(NumNodes), new UniformCrossoverMethod(), new TournamentSelector())
            {
                Elitism = true,
                AfterCallback = i => Draw(graphics, i)
            };
            ga.Evolve(3000);
        }

        private void Draw(Graphics g, IIndividual<double> individual)
        {
            g.Clear(Color.White);

            for (var i = 0; i < NumNodes; i++)
            {
                g.DrawRectangle(new Pen(Color.Red), _travelingSalesman[i].X, _travelingSalesman[i].Y, 3, 3);
            }

            var sortedNums = new List<KeyValuePair<int, double>>();

            for (var i = 0; i < _travelingSalesman.Count; i++)
            {
                sortedNums.Add(new KeyValuePair<int, double>(i, individual[i]));
            }

            sortedNums = sortedNums.OrderBy(n => n.Value).ToList();

            for (var i = 0; i < sortedNums.Count - 1; i++)
            {
                var firstOne = _travelingSalesman[sortedNums[i].Key];
                var secondOne = _travelingSalesman[sortedNums[i + 1].Key];
                g.DrawLine(new Pen(Color.Black), firstOne, secondOne);
            }
        }
    }
}
