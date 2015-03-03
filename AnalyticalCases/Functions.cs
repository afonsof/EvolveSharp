using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticalCases
{
    static class Functions
    {
        static double x2(double x)
        {
            return x * x;
        }

        public static double Rosenbrock(double x, double y, double a = 1, double b = 100)
        {
            return x2(a - x) + b * x2(y - x2(x));
        }

        public static double Rastrigin(double x, double y)
        {
            return 20d + x2(x) + x2(y) - 10d * (Math.Cos(2d * Math.PI * x) + Math.Cos(2d * Math.PI * y));
        }
    }
}
