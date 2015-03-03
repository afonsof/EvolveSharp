using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvolveSharp.Mutators;

namespace EvolveSharp.Samples.Tsp
{
    public partial class DefaultForm : Form
    {
        private static List<Point> _travelingSalesman = new List<Point>();
        private int _numNodes = 30;
        private const int MapSize = 200;
        private readonly Random _random = new Random();
        private Thread _thread;
        private Graphics _graphics;
        private bool _disposed;

        public DefaultForm()
        {
            InitializeComponent();
        }

        private void InitNodes()
        {
            _numNodes = Convert.ToInt32(numberOfPoints.Text);
            _travelingSalesman = new List<Point>();
            for (var i = 0; i < _numNodes; i++)
            {
                _travelingSalesman.Add(new Point((int)(_random.NextDouble() * MapSize), (int)(_random.NextDouble() * MapSize)));
            }
        }

        private void Draw(Graphics g, GeneticAlgorithm<double> ga)
        {
            if (_disposed) return;

            g.Clear(Color.White);

            g.DrawString("Generation #" + ga.GenerationIndex, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(0, 0));

            for (var i = 0; i < _numNodes; i++)
            {
                g.DrawRectangle(new Pen(Color.Red), _travelingSalesman[i].X, _travelingSalesman[i].Y, 3, 3);
            }

            var sortedNums = new List<KeyValuePair<int, double>>();

            var bestIndividual = ga.BestIndividual;
            for (var i = 0; i < _travelingSalesman.Count; i++)
            {
                sortedNums.Add(new KeyValuePair<int, double>(i, bestIndividual.Genes[i]));
            }
            sortedNums = sortedNums.OrderBy(n => n.Value).ToList();

            for (var i = 0; i < sortedNums.Count - 1; i++)
            {
                var firstOne = _travelingSalesman[sortedNums[i].Key];
                var secondOne = _travelingSalesman[sortedNums[i + 1].Key];
                g.DrawLine(new Pen(Color.Black), firstOne, secondOne);
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (generateButton.Text == "Generate")
            {
                generateButton.Text = "Stop";
                _thread = new Thread(Generate);
                _thread.Start();
            }
            else
            {
                generateButton.Text = "Generate";
                _thread.Abort();
            }
        }

        private void Generate()
        {
            InitNodes();

            var populationCount = Convert.ToInt32(populationSize.Text);
            var generationCount = Convert.ToInt32(numberOfGenerations.Text);

            var tsmFitnessFunction = new TsmFitnessFunction(_travelingSalesman);

            var ga = GeneticAlgorithm.CreateDouble(populationCount, _numNodes,0,1, tsmFitnessFunction);
                // Elitism = true,
            ga.AfterCallback = i => { Draw(_graphics, i); };
            
            ga.Evolve(generationCount);
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _disposed = true;
            if (_thread != null && _thread.IsAlive)
            {
                _thread.Abort();
            }
            _graphics.Dispose();
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            _graphics = panel1.CreateGraphics();
        }
    }
}
