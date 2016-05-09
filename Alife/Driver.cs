using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alife
{

    public class Driver  //This is the main class where all the calculations are done. 
    {
        public static readonly object lockiteration = new object(); //LOCK for threading: is locked when the driver is in an iteration, is freed at the end of each iteration.

        private volatile bool stop_required; // The driver has been asked to stop. Will terminate once the iteration is complete.

        public Parameters parameters; //The parameters used for calculation, comes from UI

        //Grid is a data structure that contains all the animals. This is where all the animals are stored
        private Grid<Prey> preys;
        private Grid<Predator> predators;

        //time in ms for one iteration
        public double executiontime;

        //number of iterations and current simulation time (number of iterations * timestep)
        public int Niter;
        public double currenttime;

        public int result_counter; //This counter is used to return the results of the algorithm after a given nb of iterations.
        public Queue<Result> queueresults;

        public class Result
        {
            public double time;
            public double preybiomass;
            public double predatorbiomass;
            public List<Prey> preylist;
            public List<Predator> predatorlist;
        }

        public void ge()
        {

        }

        //Constructor
        public Driver(Parameters parameters)
        {
            //set the parameters
            SetParameters(parameters);

            // preys = new Grid<Prey>((int)Math.Floor(parameters.Length_x/parameters.huntingarea),(int)Math.Floor(parameters.Length_x / parameters.huntingarea));

            //Define the grid for the preys and links it with the static value in Prey
            preys = new Grid<Prey>(25, 25);
            Prey.preygrid = preys;
            Predator.preygrid = preys;
            //Define the grid for the predators and links it with the static value in Predator
            predators = new Grid<Predator>(25, 25);
            Predator.predatorgrid = predators;
            Prey.predatorgrid = predators;
            //initialize counters
            stop_required = false;
            Niter = 0;
            executiontime = 0;
            result_counter = 0;
            queueresults = new Queue<Result>();
        }

        public void SetParameters(Parameters parameters) //sets all the static references to parameters in all the classes
        {
            this.parameters = parameters;
            Prey.parameters = parameters;
            Predator.parameters = parameters;
            Grid<Prey>.parameters = parameters;
            Grid<Predator>.parameters = parameters;
        }

        public void Update_parameters(Parameters newparameters) //Update the parameters, this is called from outside the thread
        {
            lock (lockiteration) //is locked to avoid a change of parameters during an iteration
            {
                SetParameters(newparameters);
            }
        }



        public void Require_Stop() //Require the driver to stop at the next iteration
        {
            this.stop_required = true;
        }

        public void Relaunch() //Starts the driver again from the current state
        {
            this.stop_required = false;
            Run();
        }


        public void Add_Random_Prey(int count) //Add preys to the simulation
        {
            lock (lockiteration) //is locked to avoid a change of parameters during an iteration
            {
                for (int i = 1; i < count; i++)
                {
                    preys.Add(new Prey());
                }
            }
        }

        public void Add_Random_Predator(int count) //Add predators to the simulation
        {
            lock (lockiteration) //is locked to avoid a change of parameters during an iteration
            {
                for (int i = 1; i < count; i++)
                {
                    predators.Add(new Predator());
                }
            }
        }

        // *********  ITERATION Functions ********** //

        //Each iteration consist of 3 phases:  Move, Reproduce, and Die.

        public void Iteration()
        {
            lock (lockiteration) //Gets the lock until the end of iteration
            {
                var watch = System.Diagnostics.Stopwatch.StartNew(); //Watch to get the elpased time per iteration

                // START
                Move();

                Reproduce();

                Die();
                // END

                //End of iteration, gets elapsed time and update counters
                watch.Stop();
                this.executiontime = watch.ElapsedMilliseconds;
                Niter += 1;
                this.currenttime += parameters.timestep;
                result_counter += 1;
                if (result_counter == parameters.result_frequency)
                {
                    result_counter = 0;
                    Add_Result_to_Queue();
                }
            }
        }

        public void Add_Result_to_Queue()
        {
            Result res = new Result();
            res.preybiomass = ReturnPreyBiomass();
            res.predatorbiomass = ReturnPredatorBiomass();
            res.time = ReturnCurrentTime();
            res.preylist = Return_Preys_UI();
            res.predatorlist = Return_Preds_UI();
            queueresults.Enqueue(res);
            if (queueresults.Count > 100000)
            {
                queueresults.Clear();
            }
        }

        public void Reproduce() //Reproduce preys and predators. Natural birth + hunting
        {
            //Reproduce Preys
            List<Prey> newborn = new List<Prey>();//A List that contains the offspring
            foreach (Prey p in this.preys.Iterator())
            {
                if (p.Reproduce()) //If the prey p gets the chance to reproduce, add the offspring.
                {
                    newborn.Add(p.GetOffspring());
                }
            }
            this.preys.AddRange(newborn); //Add the offspring to the prey grid


            //Reproduce predators
            List<Predator> newbornpred = new List<Predator>();//A List that contains the offspring

            foreach (Predator p in this.predators.Iterator())
            {
                if (p.Reproduce())//If the prey p gets the chance to reproduce, add the offspring.
                {
                    newbornpred.Add(p.GetOffspring());
                }
            }
            this.predators.AddRange(newbornpred); //Add the offspring to the predator grid
        }


        public void Move() //Moves the animals
        {
            foreach (Prey p in this.preys.ToList())
            {
                p.Move();
            }
            foreach (Predator p in this.predators.ToList())
            {
                p.Move();
            }
        }


        public void Die() // Kills the animals
        {
            // ! PREYS ! //

            List<Prey> deadpreys = new List<Prey>(); //List of deceased preys, will be killed afterwards
            // PREY COMPETITION ON : preys may be killed if they are too close to each other: this is a negative quadratic term. This ensures a carrying capacity on the model 
            if (parameters.prey_competition)
            {
                foreach (Prey p in preys.Iterator())
                {
                    Tuple<double, Prey> closest = preys.FindClosestinRadius_Not_Self(p.x, p.y, parameters.prey_competition_area); //Find the closest animal in the competition area
                    if (closest.Item1 < parameters.prey_competition_area) //If the closest prey is in the competition area, kills this prey with the competition strength probability
                    {
                        if (parameters.rand.NextDouble() < parameters.prey_competition_strength * parameters.timestep) //Competition death
                        {
                            deadpreys.Add(p);
                        }
                        else
                        {
                            if (p.Die()) //if competition death did not occur, this is natural death rate
                            {
                                deadpreys.Add(p);
                            }
                        }
                    }
                    //If there is no prey in the competition area, natural death rate
                    else
                    {
                        if (p.Die())
                        {
                            deadpreys.Add(p);
                        }
                    }
                }
            }
            // PREY COMPETITION OFF : Natural death rate
            else
            {
                foreach (Prey p in preys.Iterator())
                {
                    if (p.Die())
                    {
                        deadpreys.Add(p);
                    }
                }
            }

            //Remove dead preys from grid
            this.preys.RemoveRange(deadpreys);


            // ! PREDATORS ! //

            List<Predator> deadpreds = new List<Predator>(); //List of dead predators
            if (parameters.predator_competition)// PREDATOR COMPETITION ON : predators may be killed if they are too close to each other: this is a negative quadratic term. This ensures a carrying capacity on the model 
            {
                foreach (Predator p in predators.Iterator())
                {
                    Tuple<double, Predator> closest = predators.FindClosestinRadius_Not_Self(p.x, p.y, parameters.predator_competition_area); //Find the closest animal in the competition area
                    if (closest.Item1 < parameters.predator_competition_area) //If the closest predator is in the competition area, kills this predator with the competition strength probability
                    {
                        if (parameters.rand.NextDouble() < parameters.predator_competition_strength * parameters.timestep)
                        {
                            deadpreds.Add(p);
                        }
                        else
                        {
                            if (p.Die()) //if competition death did not occur, this is natural death rate
                            {
                                deadpreds.Add(p);
                            }
                        }
                    }
                    else  //If there is no prey in the competition area, natural death rate
                    {
                        if (p.Die())
                        {
                            deadpreds.Add(p);
                        }
                    }
                }
            }
            else   // PREY COMPETITION OFF : Natural death rate
            {
                foreach (Predator p in predators.Iterator())
                {
                    if (p.Die())
                    {
                        deadpreds.Add(p);
                    }
                }
            }
            //Remove dead predators from grid
            this.predators.RemoveRange(deadpreds);
        }


        public void Start() //Launch a new simulation
        {
            Add_Random_Prey(parameters.initialprey);

            Add_Random_Predator(parameters.initialpredator);

            Run();
        }

        public void Run() // Run the iteration, returns if required
        {
            while (!stop_required) //the iterations stops if this is required
            {
                System.Threading.Thread.Sleep(parameters.simulation_delay); //used to artificially slow the simulation
                Iteration();
            }
        }


        public List<Prey> Return_Preys_UI() //return List of preys. Is used for display in UI
        {
            lock (lockiteration) //The List should not be modified while it is returned to the UI: Only between iterations
            {
                return new List<Prey>(this.preys.ToList());
            }
        }

        public double ReturnPreyBiomass() //Returns amount of prey biomass
        {
            lock (lockiteration)
            {
                return (this.preys.ToList().Count);
            }
        }



        public List<Predator> Return_Preds_UI() //return List of predators. Is used for display in UI
        {
            lock (lockiteration) //The List should not be modified while it is returned to the UI: Only between iterations
            {
                return new List<Predator>(this.predators.ToList());
            }

        }

        public double ReturnPredatorBiomass() // Returns amount of predator biomass
        {
            lock (lockiteration)
            {
                return (this.predators.ToList().Count);
            }
        }

        public double ReturnCurrentTime() //Return simulation time
        {
            lock (lockiteration)
            {
                return (this.currenttime);
            }
        }

    }
}
