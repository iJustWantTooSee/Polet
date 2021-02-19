using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulation
{
    class ObjectInSimulation
    {   
        public Point InitialPosition { get; private set; } = new Point();
        public double InitialSpeed { get; private set; }
        public double Angle { get; private set; }
        
        public ObjectInSimulation(Point initialPosition, double initialSpeed, double angle)
        {
            InitialPosition = initialPosition;
            InitialSpeed = initialSpeed;
            Angle = angle;
        }

    }
}
