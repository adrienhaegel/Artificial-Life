using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Parameters
    {
        public Parameters()
        {
            this.rand = new Random();
            deathrate_age = new double[5];
            fertility_age = new double[5];
            speed_age = new double[5];
        }

        public Random rand;

        public double Length_x;
        public double Length_y;

        public double timestep;
        public int simulation_delay;

        public int initialprey;
        public int initialpredator;

        public double prey_speed;
        public double predator_speed;

        public double prey_deathrate;
        public double predator_deathrate;

        public double prey_fertility;
        public double predator_fertility;

        public double hunting_area;
        public double hunting_fertility;





        public int nbthreads = 4;

        public bool prey_competition;
        public double prey_competition_area;
        public double prey_competition_strength;
        public bool predator_competition;
        public double predator_competition_area;
        public double predator_competition_strength;



        public bool prey_chemotaxis;
        public double prey_chemotaxis_speed;
        public double prey_chemotaxis_area;

        public bool predator_chemotaxis;
        public double predator_chemotaxis_speed;
        public double predator_chemotaxis_area;

        public int result_frequency = 100;

        public bool final_time_stop = false;
        public double final_time;


        public double a;
        public double b;
        public double c;
        public double d;
        public double e;
        public double f;

        public double ratio;
        public double prey_eq;
        public double pred_eq;

        public string name;
        public string path;
        public string fullpath;

        public int age_categories = 5;
        public bool age_enabled;
        public double maxage;
        public double[] deathrate_age;
        public double[] fertility_age;
        public double[] speed_age;

        public bool hunting_limitation;
        public double time_between_hunts = 0;
        public double gestation = 0;
        public double time_between_reproduction = 0;

        public Parameters Copy()
        {
            Parameters p = new Parameters();
            p.Length_x = Length_x;
            p.Length_y = Length_y;

            p.timestep = timestep;
            p.simulation_delay = simulation_delay;

            p.initialprey = initialprey;
            p.initialpredator = initialpredator;

            p.prey_speed = prey_speed;
            p.predator_speed = predator_speed;

            p.prey_deathrate = prey_deathrate;
            p.predator_deathrate = predator_deathrate;

            p.prey_fertility = prey_fertility;
            p.predator_fertility = predator_fertility;

            p.hunting_area = hunting_area;
            p.hunting_fertility = hunting_fertility;



            p.nbthreads = nbthreads;

            p.prey_competition = prey_competition;
            p.prey_competition_area = prey_competition_area;
            p.prey_competition_strength = prey_competition_strength;
            p.predator_competition = predator_competition;
            p.predator_competition_area = predator_competition_area;
            p.predator_competition_strength = predator_competition_strength;


            p.prey_chemotaxis = prey_chemotaxis;
            p.prey_chemotaxis_speed = prey_chemotaxis_speed;
            p.prey_chemotaxis_area = prey_chemotaxis_area;

            p.predator_chemotaxis = predator_chemotaxis;
            p.predator_chemotaxis_speed = predator_chemotaxis_speed;
            p.predator_chemotaxis_area = predator_chemotaxis_area;



            p.final_time_stop = final_time_stop;
            p.final_time = final_time;
            p.name = name;

            p.a = a;
            p.b = b;
            p.c = c;
            p.d = d;
            p.e = e;
            p.f = f;

            p.ratio = ratio;
            p.prey_eq = prey_eq;
            p.pred_eq = pred_eq;

            p.path = path;
            p.fullpath = fullpath;

            p.age_enabled = age_enabled;
            deathrate_age.CopyTo(p.deathrate_age, 0);
            fertility_age.CopyTo(p.fertility_age, 0);
            speed_age.CopyTo(p.speed_age, 0);

            p.maxage = maxage;

            p.hunting_limitation = hunting_limitation;
            p.time_between_hunts = time_between_hunts;
            p.gestation = gestation;
                    p.time_between_reproduction = time_between_reproduction;

            return p;
        }

        public override string ToString()
        {
            string s = "";
            s += "Lx : " + this.Length_x + "  Ly : " + this.Length_y + "    timestep : " + this.timestep + Environment.NewLine;
            s += " fertility  | deathrate " + " Prey : " + this.prey_fertility + " | " + this.prey_deathrate + " Predator : " + this.predator_fertility + " | " + this.predator_deathrate + Environment.NewLine;
            s += "hunting area : " + hunting_area + "    hunting fertility : " + hunting_fertility + Environment.NewLine;

            if (prey_competition)
            {
                s += "Prey competition : YES    area : " + prey_competition_area + "   strength : " + prey_competition_strength + Environment.NewLine;
            }
            else
            {
                s += "Prey competition : NO" + Environment.NewLine;
            }
            if (predator_competition)
            {
                s += "Predator competition : YES    area : " + predator_competition_area + "   strength : " + predator_competition_strength + Environment.NewLine;
            }
            else
            {
                s += "Predator competition : NO" + Environment.NewLine;
            }

            s += "Speed    Prey : " + this.prey_speed + "   Predator : " + this.predator_speed + Environment.NewLine;


            if (prey_chemotaxis)
            {
                s += "Prey chemotaxis : YES    area : " + prey_chemotaxis_area + "   speed : " + prey_chemotaxis_speed + Environment.NewLine;
            }
            else
            {
                s += "Prey chemotaxis : NO" + Environment.NewLine;
            }

            if (predator_chemotaxis)
            {
                s += "Predator chemotaxis : YES    area : " + predator_chemotaxis_area + "   speed : " + predator_chemotaxis_speed + Environment.NewLine;
            }
            else
            {
                s += "Predator chemotaxis : NO" + Environment.NewLine;
            }


            s += "ratio : " + ratio.ToString("F2") + "  prey eq : " + prey_eq.ToString("F2") + "   pred eq : " + pred_eq.ToString("F2") + Environment.NewLine;

            return s;
        }
    }
}
