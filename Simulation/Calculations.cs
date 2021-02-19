using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public static class Calculations
    {
        public static double GetXFlight(double x0, double v0, double angle, double time, double gravityX)
        {
            return x0 + v0 * Math.Cos(GetRadianFromDegrees(angle)) * time + gravityX * time * time / 2;
        }

        public static double GetYFlight(double y0, double v0, double angle, double time, double gravityY)
        {
            return y0 + v0 * Math.Sin(GetRadianFromDegrees(angle)) * time + gravityY * time * time / 2;
        }

        public static double GetRadianFromDegrees(double andle)
        {
            return andle * Math.PI / 180;
        }

        public static double GetMaxHeight(double v0, double angle, double g)
        {
            return (v0 * v0 * Math.Pow(Math.Sin(GetRadianFromDegrees(angle)), 2)) / (2 * g);
        }

        public static double GetMaxLengthOfFlight(double v0, double angle, double g, double h)
        {
            double a = GetRadianFromDegrees(angle);
            double t1 = v0 * Math.Sin(a) / g;
            double h1 = h + v0 * Math.Sin(a) * t1 - h * t1 * t1 / g;
            double t2 = Math.Sqrt(2 * h1 / g);
            return v0 * Math.Cos(a) * (t1 + t2);
        }
    }
}
