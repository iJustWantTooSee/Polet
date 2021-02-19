using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public class Engine
    {       
        private double _initialSpeed = 0;
        private ObjectInSimulation obj = null;
        public double Time { get; private set; }
        public double DTime { get; private set; }
        public double GravityX { get; private set; }
        public double GravityY { get; private set; }

        public Engine(Point initialPosition, double initialSpeed, double dt, double gX, double gY, double angle)
        {
            obj = new ObjectInSimulation(initialPosition, initialSpeed, angle);
            Time = 0;
            DTime = dt;
            GravityX = gX;
            GravityY = gY;
        }

        

        

        public Point GetNextPoint()
        {
            Time += DTime;
            return  new Point(Calculations
                .GetXFlight(obj.InitialPosition.X, obj.InitialSpeed, obj.Angle, Time, GravityX),
                Calculations.
                GetYFlight(obj.InitialPosition.Y, obj.InitialSpeed, obj.Angle, Time, GravityY));
        }
    }
}
