using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Parameters
    {
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

        public Parameters()
        {
            this.rand = new Random();
        }

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
    }
}
