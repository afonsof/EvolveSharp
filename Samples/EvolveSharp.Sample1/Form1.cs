using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EvolveSharp.FitnessFunction;
using EvolveSharp.Individuals;

namespace EvolveSharp.Sample1
{
    public partial class Form1 : Form
    {
        //Fitness function!
        private static List<Point> travelingSalesman = new List<Point>();
        private const int numNodes = 30;
        private const int mapSize = 200;

        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            var numNodes = 10;
            initNodes();

            var ga = new GeneticAlgorithm(300, 10, new FitnessFunction1());
            ga.Evolve(300);
        }

        private void drawMap(IIndividual generation)
        {
            var graphics = CreateGraphics();

            graphics.Clear(Color.White);
            Text = generation.ToString();

            for (var i = 0; i < numNodes; i++)
            {
                graphics.DrawArc(new Pen(Color.Black), travelingSalesman[i].X, travelingSalesman[i].Y, 1, 0, (int)(2 * Math.PI), 360);
            }
        }

        private void initNodes()
        {
            travelingSalesman = new List<Point>();
            for (var i = 0; i < numNodes; i++)
            {
                travelingSalesman.Add(new Point((int)random.NextDouble() * mapSize, (int)random.NextDouble() * mapSize));

            }
        }

        private static double distanceTo(Point pointA, Point pointB)
        {
            return Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2);
        }

        private class FitnessFunction1 : IFitnessFunction
        {
            public double Evaluate(IIndividual individual)
            {
                var sortedNums = new List<KeyValuePair<int, double>>();

                for (var i = 0; i < travelingSalesman.Count; i++)
                {
                    sortedNums.Add(new KeyValuePair<int, double>(i, individual[i]));
                }

                sortedNums = sortedNums.OrderBy(n => n.Value).ToList();

                var totalDistance = 0.0;

                /*if (draw)
                {
                    var ctx = document.getElementById('gacanvas');
                    ctx = ctx.getContext('2d');
                }*/

                for (var i = 0; i < sortedNums.Count - 1; i++)
                {
                    var firstOne = travelingSalesman[sortedNums[i].Key];
                    var secondOne = travelingSalesman[sortedNums[i + 1].Key];
                    totalDistance += distanceTo(firstOne, secondOne);

                    /*if (ctx)
                    {
                        ctx.beginPath();
                        ctx.moveTo(firstOne[0], firstOne[1]);
                        ctx.lineTo(secondOne[0], secondOne[1]);
                        ctx.stroke();
                    }*/

                }
                return -totalDistance;
            }
        }

        //Specify my individual - including chromosome length, mate, and init
        /*private void Individual()
        {
            this.fitness = 0;
            this.chromosomeLength = numNodes;
            this.chromosome = new Array();
            this.mate = function(mutability, mate)
            {
                if (!mate.chromosome)
                {
                    throw "Mate does not have a chromosome";
                }
                var newGuy = new Environment.Individual();
                newGuy.chromosome =
                    this.chromosome.slice(0, Math.floor(this.chromosomeLength))
                        .concat(mate.chromosome.slice(Math.floor(this.chromosomeLength)));

                while (Math.random() < mutability)
                {
                    var mutateIndex = Math.floor(Math.random()*this.chromosomeLength);
                    //a random gene will be mutated;                     
                    newGuy.chromosome[mutateIndex] = (1 << (Math.floor(Math.random()*16))) ^
                                                     newGuy.chromosome[mutateIndex];
                }
                return newGuy;
            }

            Environment.Individual.prototype.init = function()
            {
                for (var i = 0; i < this.chromosomeLength; i++)
                {
                    this.chromosome.push(Math.random());
                }
            }
            ;
        }*/

        /*private Environment.beforeGeneration =

        private function(generation )
        {
            drawMap(generation);
        }

    ;

        private Environment.afterGeneration 
    =

        private function(generation )
        {
            for (individual in Environment.inhabitants)
            {
                console.log(Environment.inhabitants[individual].fitness);
            }
            Environment.fitnessFunction(Environment.inhabitants[0], true);
            setTimeout("Environment.generation()", 500);
        }

    ;*/
    }
}
