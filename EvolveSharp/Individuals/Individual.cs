using System.Collections.Generic;
using System.Text;
using EvolveSharp.FitnessFunction;

namespace EvolveSharp.Individuals
{
    public class Individual<T> : IIndividual<T>
    {
        private readonly IList<T> _genes;
        private IFitnessFunction<T> _fitnessFunction;

        /// <summary>
        /// Builder a new genome from a list of genes
        /// </summary>
        /// <param name="genes">List of genes which forms a Genome</param>
        public Individual(IList<T> genes)
        {
            _genes = genes;
        }

        public T this[int key]
        {
            get { return _genes[key]; }
            set
            {
                _fitness = null;
                _genes[key] = value;
            }
        }

        /// <summary>
        /// Builder a new genome from other Binary Genome
        /// </summary>
        /// <param name="genome">Binary Genome</param>
        public Individual(Individual<T> genome)
        {
            _genes = genome._genes;
            _fitnessFunction = genome._fitnessFunction;
        }

        public int Length
        {
            get { return _genes.Count; }
        }

        /// <summary>
        /// Get the last fitness evaluated
        /// </summary>
        private double? _fitness;

        public double Fitness
        {
            get
            {
                if (_fitness.HasValue)
                {
                    return _fitness.Value;
                }
                _fitness = _fitnessFunction.Evaluate(this);
                return _fitness.Value;
            }
        }

        /*public IList<double> Genes {
                get { return _genes; }
            }*/

        /// <summary>
        /// Compare if the value this genome is equal to other genome
        /// </summary>
        /// <param name="obj">The genome to compare with this</param>
        /// <returns>if the genomes are equal or not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var genome = obj as Individual<T>;
            if (genome == null)
                return false;

            for (var locus = 0; locus != _genes.Count; locus++)
            {
                if (!EqualityComparer<T>.Default.Equals(_genes[locus], genome._genes[locus]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            foreach (var gene in _genes)
            {
                hash = hash * 31 + gene.GetHashCode();
            }
            return hash;
        }

        /// <summary>
        /// Print the values of each locus of genome
        /// </summary>
        /// <returns>Values of genome in a string</returns>
        public override string ToString()
        {
            var output = new StringBuilder(_genes.Count);
            foreach (var gene in _genes)
                output.AppendFormat(" {0:0.00}", gene);

            return output.ToString();
        }

        public IList<T> Genes
        {
            get { return _genes; }
        }

        public int CompareTo(IIndividual<T> other)
        {
            if (Fitness < other.Fitness)
            {
                return -1;
            }
            if (Fitness > other.Fitness)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Set Fitness Function in the Genome
        /// </summary>
        /// <param name="fitnessFunction">Class Implements in the Code of user</param>
        public void SetFitnessFunction(IFitnessFunction<T> fitnessFunction)
        {
            _fitnessFunction = fitnessFunction;
            _fitness = null;
        }

        /// <summary>
        /// Create a identical Genome with other memory address
        /// </summary>
        /// <returns>A copy of genome passed in the parameters</returns>
        public object Clone()
        {
            var newGenes = new T[_genes.Count];
            for (var i = 0; i < _genes.Count; i++)
            {
                newGenes[i] = _genes[i];
            }
            return new Individual<T>(_genes) { _fitnessFunction = _fitnessFunction };
        }
    }
}
