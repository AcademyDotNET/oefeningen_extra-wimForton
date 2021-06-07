using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class MyMath
    {
        public static double Lerp(double a, double b, double weight)
        {
            double result = a * (1 - weight) + b * weight;

            return result;
        }
    }
}
