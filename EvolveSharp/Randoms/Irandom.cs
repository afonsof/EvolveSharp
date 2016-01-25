using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveSharp.Randoms
{
    /// <summary>
    /// Interface to support randoms.
    /// </summary>
    public interface IRandom<T>
    {
        /// <summary>
        /// Generates a random value between min and max.
        /// </summary>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns>Random value</returns>
        T GetNext(T min, T max);
    }
}
