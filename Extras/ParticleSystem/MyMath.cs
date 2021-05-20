using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class MyMath
    {
        private static double Lerp(double a, double b, double weight)
        {
            double result = a * (1 - weight) + b * weight;

            return result;
        }
    }
}
