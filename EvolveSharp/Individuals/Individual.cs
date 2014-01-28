using System.Collections.Generic;
using System.Text;

namespace EvolveSharp.Individuals
{
    public class Individual<T> : IIndividual<T>
    {
        private readonly IList<T> _genes;
        private IFitnessFunction<T> _fitnessFunction;

        /// <summary>
        /// Builder a new individual from a list of genes
        /// </summary>
        /// <param name="genes">List of genes which forms a Individual</param>
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
        /// Builder a new individual from another
        /// </summary>
        /// <param name="individual">Individual</param>
        public Individual(Individual<T> individual)
        {
            _genes = individual._genes;
            _fitnessFunction = individual._fitnessFunction;
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

        /// <summary>
        /// Compare if the value this individual is equal to other individual
        /// </summary>
        /// <param name="obj">The individual to compare with this</param>
        /// <returns>if the individuals are equal or not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var individual = obj as Individual<T>;
            if (individual == null)
                return false;

            for (var locus = 0; locus != _genes.Count; locus++)
            {
                if (!EqualityComparer<T>.Default.Equals(_genes[locus], individual._genes[locus]))
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
        /// Print the values of each gene of individual
        /// </summary>
        /// <returns>Values of individual in a string</returns>
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
        /// Set Fitness Function in the Individual
        /// </summary>
        /// <param name="fitnessFunction">Fitness Function</param>
        public void SetFitnessFunction(IFitnessFunction<T> fitnessFunction)
        {
            _fitnessFunction = fitnessFunction;
            _fitness = null;
        }

        /// <summary>
        /// Create a identical Individual with other memory address
        /// </summary>
        /// <returns>A copy of individual</returns>
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
