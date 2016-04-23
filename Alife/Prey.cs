using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Prey : Animal,Gridable
    {
        public static Parameters parameters;
        public Random rand;
        public double x;
        public double y;

        public int xindex;
        public int yindex;

        public static Grid<Prey> preygrid;

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

        public bool Reproduce()
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

            double newx = this.x+randNormalx;

            double v1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double v2 = rand.NextDouble();
            double randStdNormaly = Math.Sqrt(-2.0 * Math.Log(v1)) *
                         Math.Sin(2.0 * Math.PI * v2); //random normal(0,1)
            double randNormaly =
                        Math.Sqrt(parameters.timestep) * parameters.preyspeed * randStdNormaly; //random normal(mean,stdDev^2)
            double newy = this.y + randNormaly;

            double newx_cor;
            double newy_cor;

            Rebound(out newx_cor,out newy_cor,newx,newy);

            preygrid.Update(this, newx_cor, newy_cor);
        }

        private void Rebound(out double newx_cor,out double newy_cor,double x, double y)
        {
            newx_cor = x;
            newy_cor = y;

            if (newx_cor < 0)
            {
                newx_cor = -newx_cor;
            }
            if(newx_cor > parameters.Length_x)
            {
                newx_cor = 2*parameters.Length_x - newx_cor;
            }

            if (newy_cor  < 0)
            {
                newy_cor = -newy_cor;
            }
            if (newy_cor > parameters.Length_y)
            {
                newy_cor = 2 * parameters.Length_y - newy_cor;
            }

                

        }

        public bool Die()
        {
            return (rand.NextDouble() < parameters.timestep * parameters.deathrateprey);
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
