using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Prey : Animal
    {
        public static Parameters parameters;
        public Random rand;
        public double x;
        public double y;



        public Prey()
        {
            this.rand = parameters.rand;
            this.x = rand.NextDouble()*parameters.Length_x;
            this.y = rand.NextDouble() * parameters.Length_y;


        }

        public Prey(double x, double y)
        {
            this.rand = parameters.rand;
            this.x = x;
            this.y = y;

        }

        public Prey Copy()
        {
            return new Prey(this.x, this.y);
        }

        public bool Reproduce(int nb)
        {
            return (rand.NextDouble() < parameters.timestep*parameters.fertilityprey);
        }

        public void Move()
        {
           ; //reuse this if you are generating many
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormalx = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormalx =
                      Math.Sqrt(parameters.timestep)*   parameters.preyspeed * randStdNormalx; //random normal(mean,stdDev^2)

            this.x += randNormalx;

            double v1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double v2 = rand.NextDouble();
            double randStdNormaly = Math.Sqrt(-2.0 * Math.Log(v1)) *
                         Math.Sin(2.0 * Math.PI * v2); //random normal(0,1)
            double randNormaly =
                        Math.Sqrt(parameters.timestep) * parameters.preyspeed * randStdNormaly; //random normal(mean,stdDev^2)
            this.y += randNormaly;

            Rebound();
        }

        private void Rebound()
        {
            if (x < 0)
            {
                this.x = -this.x;
            }
            if(x > parameters.Length_x)
            {
                this.x = 2*parameters.Length_x - this.x;
            }

            if (y < 0)
            {
                this.y = -this.y;
            }
            if (y > parameters.Length_y)
            {
                this.y = 2*parameters.Length_y - this.y;
            }
        }

        public bool Die()
        {
            return (rand.NextDouble() < parameters.timestep * parameters.deathrateprey);
        }
    }
}
