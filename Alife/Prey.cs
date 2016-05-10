﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Prey : Animal,Gridable //This class implements a prey
    {
        public static Parameters parameters; //the parameters used
        public Random rand; //a random number generator. WARNING: since a lot of them are declared at the same time, this should use the same object for all the animals.

        //positions
        public double x;
        public double y;

        //index position in the grid
        public int xindex;
        public int yindex;

        //The grid containing all the preys
        public static Grid<Prey> preygrid;
        public static Grid<Predator> predatorgrid;

        public Prey() //constructor of random prey
        {
            this.rand = parameters.rand;
            this.x = rand.NextDouble()*parameters.Length_x;
            this.y = rand.NextDouble() * parameters.Length_y;
        }

        public Prey(double x, double y) //constructor at a given position
        {
            this.rand = parameters.rand;
            this.x = x;
            this.y = y;

        }

        public Prey Copy()
        {
            return new Prey(this.x, this.y);
        }

        public Prey GetOffspring() //Returns a new prey at the same position
        {
            return new Prey(this.x, this.y);
        }

        public bool Reproduce() //the probability of reproducing is prey_fertility
        {
            return (rand.NextDouble() < parameters.timestep*parameters.prey_fertility);
        }

        public double GetFromNormalDistrib(double mean, double deviation) //Generates a double from normal distribution. The distribution is truncated at -10 and 10 to avoid very high unexpected values.
        {
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)

            randStdNormal = Math.Max(randStdNormal, -10);
            randStdNormal = Math.Min(randStdNormal, 10 );

            return mean + deviation * randStdNormal;
        }

        public void Move()
        {
            if (parameters.prey_chemotaxis)
            {
                Tuple<double,Predator> closestpred = predatorgrid.FindClosestinRadius(this.x, this.y, parameters.prey_chemotaxis_area);
                if (closestpred.Item1 < parameters.prey_chemotaxis_area)
                {

                    double xdirection = (closestpred.Item2.x - this.x) / Math.Sqrt((closestpred.Item2.x - this.x) * (closestpred.Item2.x - this.x) + (closestpred.Item2.y - this.y) * (closestpred.Item2.y - this.y));
                    double ydirection = (closestpred.Item2.y - this.y) / Math.Sqrt((closestpred.Item2.x - this.x) * (closestpred.Item2.x - this.x) + (closestpred.Item2.y - this.y) * (closestpred.Item2.y - this.y));

                    double randNormalx = GetFromNormalDistrib(-parameters.prey_chemotaxis_speed * parameters.timestep *xdirection, Math.Sqrt(parameters.timestep) * parameters.prey_speed); //get brownian motion
                    double randNormaly = GetFromNormalDistrib(-parameters.prey_chemotaxis_speed * parameters.timestep * ydirection, Math.Sqrt(parameters.timestep) * parameters.prey_speed);

                    double newx_cor;
                    double newy_cor;
                    Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently

                    preygrid.Update(this, newx_cor, newy_cor); //update positions
                }
                else
                {
                    double randNormalx = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.prey_speed); //get brownian motion
                    double randNormaly = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.prey_speed);

                    double newx_cor;
                    double newy_cor;
                    Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently

                    preygrid.Update(this, newx_cor, newy_cor); //update positions
                }
            }
            else
            {
                double randNormalx = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.prey_speed); //get brownian motion
                double randNormaly = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.prey_speed);

                double newx_cor;
                double newy_cor;
                Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently

                preygrid.Update(this, newx_cor, newy_cor); //update positions
            }

        }

        private void Rebound(out double newx_cor,out double newy_cor,double x, double y) //Check if the new positions are within the boundaries
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

        public bool Die() //This is the natural death rate of animals
        {
                return (rand.NextDouble() < parameters.timestep * parameters.prey_deathrate);
        }

        //get set for x and y
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
