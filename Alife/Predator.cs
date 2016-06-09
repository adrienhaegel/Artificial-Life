using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Predator : Gridable //This class implements a predator. For comments check prey class
    {
        [ThreadStatic]
        public static Parameters parameters;
        [ThreadStatic]
        public static Random rand;
        public double x;
        public double y;


        public int xindex;
        public int yindex;
        [ThreadStatic]
        public static Grid<Predator> predatorgrid;
        [ThreadStatic]
        public static Grid<Prey> preygrid;

        public double hasfood;
        public double hasreproduced;
        public bool ispregant;
        public double gestation;

        public Predator()
        {

            this.x = rand.NextDouble() * parameters.Length_x;
            this.y = rand.NextDouble() * parameters.Length_y;

            hasfood = 0;
            hasreproduced = parameters.time_between_reproduction;
            ispregant = false;
            gestation = 0;
        }

        public Predator(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Predator Copy()
        {
            return new Predator(this.x, this.y);
        }

        public Predator GetOffspring()
        {
            double randNormalx = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.predator_speed); //get brownian motion
            double randNormaly = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.predator_speed);

            double newx_cor;
            double newy_cor;
            Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently
            return new Predator(newx_cor, newy_cor);
        }

        public void HuntAndReproduce()
        {

            if (hasfood <= 0)
            {
                if (rand.NextDouble() < parameters.timestep)
                {


                    Tuple<double, Prey> closestprey = preygrid.FindClosestinRadius(this.x, this.y, parameters.hunting_area);


                    if (closestprey.Item1 < parameters.hunting_area)
                    {
                        preygrid.Remove(closestprey.Item2);
                        hasfood = parameters.time_between_hunts;
                        Reproduce();

                    }
                }

            }

        }


        public void Reproduce()
        {




            if (hasreproduced <= 0 && !ispregant)
            {
                if (rand.NextDouble() < parameters.hunting_fertility )
                {
                    ispregant = true;
                    hasreproduced = parameters.time_between_reproduction;
                    gestation = parameters.gestation;

                }
            }







        }

        public bool Birth()
        {
            if (ispregant && gestation < 0)
            {
                ispregant = false;
                gestation = 0;
                return true;
            }
            return false;
        }

        public double GetFromNormalDistrib(double mean, double deviation) //Generates a double from normal distribution. The distribution is truncated at -10 and 10 to avoid very high unexpected values.
        {
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)

            randStdNormal = Math.Max(randStdNormal, -10);
            randStdNormal = Math.Min(randStdNormal, 10);

            return mean + deviation * randStdNormal;
        }


        public void Move()
        {
            if (parameters.predator_chemotaxis)
            {
                Tuple<double, Prey> closestprey = preygrid.FindClosestinRadius(this.x, this.y, parameters.predator_chemotaxis_area);
                if (closestprey.Item1 < parameters.predator_chemotaxis_area)
                {

                    double xdirection = (closestprey.Item2.x - this.x) / Math.Sqrt((closestprey.Item2.x - this.x) * (closestprey.Item2.x - this.x) + (closestprey.Item2.y - this.y) * (closestprey.Item2.y - this.y));
                    double ydirection = (closestprey.Item2.y - this.y) / Math.Sqrt((closestprey.Item2.x - this.x) * (closestprey.Item2.x - this.x) + (closestprey.Item2.y - this.y) * (closestprey.Item2.y - this.y));
                    /*
                    if ((xdirection * xdirection + ydirection * ydirection) > parameters.predator_chemotaxis_speed)
                    {
                        xdirection = parameters.predator_chemotaxis_speed * xdirection / Math.Sqrt((closestprey.Item2.x - this.x) * (closestprey.Item2.x - this.x) + (closestprey.Item2.y - this.y) * (closestprey.Item2.y - this.y));
                        ydirection = parameters.predator_chemotaxis_speed * ydirection / Math.Sqrt((closestprey.Item2.x - this.x) * (closestprey.Item2.x - this.x) + (closestprey.Item2.y - this.y) * (closestprey.Item2.y - this.y));
                    }
                    */
                    double randNormalx = GetFromNormalDistrib(parameters.timestep * xdirection * parameters.predator_chemotaxis_speed, Math.Sqrt(parameters.timestep) * parameters.predator_speed); //get brownian motion
                    double randNormaly = GetFromNormalDistrib(parameters.timestep * ydirection * parameters.predator_chemotaxis_speed, Math.Sqrt(parameters.timestep) * parameters.predator_speed);

                    double newx_cor;
                    double newy_cor;
                    Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently

                    Tuple<double, Predator> closestpredator = predatorgrid.FindClosestinRadius_Not_Self(newx_cor, newy_cor, parameters.predator_competition_area);
                    if (closestpredator.Item1 < parameters.predator_competition_area)
                    {
                        xdirection = (closestpredator.Item2.x - newx_cor) / Math.Sqrt((closestpredator.Item2.x - newx_cor) * (closestpredator.Item2.x - newx_cor) + (closestpredator.Item2.y - newy_cor) * (closestpredator.Item2.y - newy_cor));
                        ydirection = (closestpredator.Item2.y - newy_cor) / Math.Sqrt((closestpredator.Item2.x - newx_cor) * (closestpredator.Item2.x - newx_cor) + (closestpredator.Item2.y - newy_cor) * (closestpredator.Item2.y - newy_cor));

                        randNormalx = GetFromNormalDistrib(-parameters.timestep * xdirection * parameters.predator_speed, Math.Sqrt(parameters.timestep) * parameters.predator_speed); //get brownian motion
                        randNormaly = GetFromNormalDistrib(-parameters.timestep * ydirection * parameters.predator_speed, Math.Sqrt(parameters.timestep) * parameters.predator_speed);

                        double newx_cor_pred;
                        double newy_cor_pred;
                        Rebound(out newx_cor_pred, out newy_cor_pred, newx_cor + randNormalx, newy_cor + randNormaly); //Check if no boundaries and update position consequently
                        predatorgrid.Update(this, newx_cor_pred, newy_cor_pred); //update positions
                    }
                    else
                    {
                        predatorgrid.Update(this, newx_cor, newy_cor);
                    }

         


                    
                }
                else
                {
                    double randNormalx = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.predator_speed); //get brownian motion
                    double randNormaly = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.predator_speed);

                    double newx_cor;
                    double newy_cor;
                    Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently

                    predatorgrid.Update(this, newx_cor, newy_cor); //update positions
                }
            }
            else
            {
                double randNormalx = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.predator_speed); //get brownian motion
                double randNormaly = GetFromNormalDistrib(0, Math.Sqrt(parameters.timestep) * parameters.predator_speed);

                double newx_cor;
                double newy_cor;
                Rebound(out newx_cor, out newy_cor, this.x + randNormalx, this.y + randNormaly); //Check if no boundaries and update position consequently

                predatorgrid.Update(this, newx_cor, newy_cor); //update positions
            }





        }

        private void Rebound(out double newx_cor, out double newy_cor, double x, double y)
        {
            newx_cor = x;
            newy_cor = y;

            if (newx_cor < 0)
            {
                newx_cor = -newx_cor;
            }
            if (newx_cor > parameters.Length_x)
            {
                newx_cor = 2 * parameters.Length_x - newx_cor;
            }

            if (newy_cor < 0)
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
            Age();
            if (hasfood <= 0)
            {
                return (rand.NextDouble() < parameters.predator_deathrate * parameters.timestep);
            }
            return false;
        }

        public void Age()
        {
            this.hasfood -= parameters.timestep;
            this.hasreproduced -= parameters.timestep;
            this.gestation -= parameters.timestep;
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
