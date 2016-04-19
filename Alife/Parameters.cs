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

        public double preyspeed;
        public double predatorspeed;

        public double deathrateprey;
        public double deathratepredator;

        public double fertilityprey;
        public double fertilitypredator;

        public double huntingarea;

        public Parameters()
        {
            this.rand = new Random();
        }

    }
}
