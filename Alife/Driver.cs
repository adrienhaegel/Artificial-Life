using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class Driver
    {

        public static readonly object lockiteration = new object();

        private volatile bool stop_required;

        Parameters parameters;

        private List<Prey> preys;
        private List<Predator> predators;

        public double executiontime;

        public int Niter;

        public Driver(Parameters parameters)
        {
            this.parameters = parameters;
            Prey.parameters = parameters;
            Predator.parameters = parameters;
            stop_required = false;
            preys = new List<Prey>();
            predators = new List<Predator>();
            Niter = 0;

        }

        public void Update_parameters(Parameters newparameters)
        {
            lock (lockiteration)
            {
                this.parameters = newparameters;
                Prey.parameters = newparameters;
                Predator.parameters = newparameters;
            }
        }



        public void Require_Stop()
        {
            this.stop_required = true;
        }




        public void Add_Random_Prey(int count)
        {
            lock (lockiteration)
            {
                for (int i = 1; i < count; i++)
                {
                    preys.Add(new Prey());
                }
            }
        }

        public void Add_Random_Predator(int count)
        {
            lock (lockiteration)
            {
                for (int i = 1; i < count; i++)
                {
                    predators.Add(new Predator());
                }
            }
        }



        public void Reproduce()
        {
            List<Prey> newborn = new List<Prey>();
            int nb = this.preys.Count;
            foreach (var p in this.preys)
            {
                if (p.Reproduce(nb))
                {
                    newborn.Add(p.Copy());
                }

            }
            this.preys.AddRange(newborn);

            List<Predator> newbornpred = new List<Predator>();
            int nbPredator = this.predators.Count;
            foreach (var p in this.predators)
            {
                if (p.Reproduce(preys))
                {
                    newbornpred.Add(p.Copy());
                }

            }
            this.predators.AddRange(newbornpred);
        }


        public void Move()
        {
            foreach (Prey p in this.preys)
            {
                p.Move();
            }
            foreach (Predator p in this.predators)
            {
                p.Move();
            }
        }

        public void Die()
        {
            this.preys.RemoveAll(p => p.Die());
            this.predators.RemoveAll(p => p.Die());
        }



        public void Iteration()
        {
            lock (lockiteration)
            {

                var watch = System.Diagnostics.Stopwatch.StartNew();

                Move();

                Reproduce();

                Die();
                watch.Stop();
                this.executiontime = watch.ElapsedMilliseconds;
                Niter += 1;

            }
        }



        public void Run_test()
        {

            Add_Random_Prey(parameters.initialprey);
         
            Add_Random_Predator(parameters.initialpredator);


            while (!stop_required)
            {

                System.Threading.Thread.Sleep(parameters.simulation_delay);

                Iteration();


            }

        }


        public List<Prey> Return_Preys()
        {
            lock (lockiteration)
            {
                return new List<Prey>(this.preys);
            }

        }

        public List<Predator> Return_Preds()
        {
            lock (lockiteration)
            {
                return new List<Predator>(this.predators);
            }

        }

        public void Update_Graph()
        {
            // Alife.Form1.
        }

    }
}
