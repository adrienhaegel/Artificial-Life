using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Predator : Gridable, Animal
    {
        public static Parameters parameters;
        public Random rand;
        public double x;
        public double y;


        public int xindex;
        public int yindex;



        public Predator()
        {
            this.rand = parameters.rand;
            this.x = rand.NextDouble() * parameters.Length_x;
            this.y = rand.NextDouble() * parameters.Length_y;

            
        }

        public Predator(double x, double y)
        {
            this.rand = parameters.rand;
            this.x = x;
            this.y = y;


        }

        public Predator Copy()
        {
            return new Predator(this.x, this.y);
        }

        public bool Reproduce(Grid<Prey> preys)
        {

           Tuple<double,Prey> closestprey = preys.FindClosestinRadius(this.x, this.y, parameters.huntingarea);

               


                if (closestprey.Item1 < parameters.huntingarea)
                {
                    preys.Remove(closestprey.Item2);
                    return (rand.NextDouble() < parameters.fertilitypredator*parameters.timestep);
                }
            

            return false;

        }

        public void Move()
        {
            ; //reuse this if you are generating many
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormalx = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormalx =
                      Math.Sqrt(parameters.timestep) * parameters.predatorspeed * randStdNormalx; //random normal(mean,stdDev^2)

            this.x += randNormalx;

            double v1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double v2 = rand.NextDouble();
            double randStdNormaly = Math.Sqrt(-2.0 * Math.Log(v1)) *
                         Math.Sin(2.0 * Math.PI * v2); //random normal(0,1)
            double randNormaly =
                        Math.Sqrt(parameters.timestep)  * parameters.predatorspeed* randStdNormaly; //random normal(mean,stdDev^2)
            this.y += randNormaly;

            Rebound();
        }

        private void Rebound()
        {
            if (x < 0)
            {
                this.x = -this.x;
            }
            if (x > parameters.Length_x)
            {
                this.x = 2 * parameters.Length_x - this.x;
            }

            if (y < 0)
            {
                this.y = -this.y;
            }
            if (y > parameters.Length_y)
            {
                this.y = 2 * parameters.Length_y - this.y;
            }
        }

        public bool Die()
        {
            return (rand.NextDouble() < parameters.deathratepredator * parameters.timestep);
        }

        public int Getxindex()
        {
            return xindex;
        }

        public int Getyindex()
        {
            return yindex;
        }

        public double Getx()
        {
            return this.x;
        }

        public double Gety()
        {
            return this.y;
        }

        public void Setx(double a)
        {
            this.x = a;
        }

        public void Sety(double a)
        {
            this.y = a;
        }

        public void Setindex(int xindex, int yindex)
        {
            this.xindex = xindex;
            this.yindex = yindex;
        }
    }
}
