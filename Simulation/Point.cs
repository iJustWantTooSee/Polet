using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public class Point
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point()
        {

        }
    }
}
