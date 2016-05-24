using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Simulation
    {

        static int index_counter = 0;
        public int index;
        public bool thread_assigned = false;
        public int threadid;
        public Driver driver;
        public Parameters parameters;
        public Status currentstatus;
        public ResultsHandler rh;
        public string name;

        public enum Status { Waiting, Running, Writing_Data , Making_Video ,Finished, Aborted,        }

        public Simulation(Parameters p)
        {
            index = index_counter;
            parameters = p;
            name = p.name;
            parameters = p;
            p.fullpath = p.path + "\\" + GetStringName() + "\\"; 
            currentstatus = Status.Waiting;
   
            index_counter++;
        }

        public String GetStringName()
        {
            string simname;
            if (this.name != "")//if the name of the simulation is defined, append "_name" to the simulation number
            {
                simname = this.name + "_" + this.index.ToString();
            }
            else
            {
                simname = this.index.ToString();
            }
            return simname;
        }

        public void Run()
        {
            driver = new Driver(parameters.Copy());
            currentstatus = Status.Running;
            Run_Simulation();

            
            rh = new ResultsHandler(this);
            currentstatus = Status.Writing_Data;
            rh.WriteData();
            currentstatus = Status.Making_Video;
            Make_Video();
            currentstatus = Status.Finished;
            threadid = -1;
            thread_assigned = false;

            
            
        }

        public void Run_Simulation()
        {
            driver.Add_Random_Prey(parameters.initialprey);
            driver.Add_Random_Predator(parameters.initialpredator);
            driver.Run();
        }



        public string GetProgress()
        {
            if (driver == null)
            {
                return "0 %";
            }
            else
            {
                if(currentstatus == Status.Running)
                {
                    int percent = Math.Min((int)Math.Floor(100 * driver.currenttime / parameters.final_time), 100);
                    return percent.ToString() + " %";
                }
                else if(currentstatus == Status.Writing_Data)
                {
                    return rh.GetProgress_Write_Data();
                }
                else if(currentstatus == Status.Making_Video)
                {
                    return rh.GetProgress_Make_Video();
                }
                else if(currentstatus == Status.Finished)
                {
                    return "100%";
                }
                else
                {
                    return "ERROR";
                }
            }

        }

        public int GetNbPrey()
        {
            if(driver == null)
            {
                return 0;
            }
            return driver.Return_Preys_UI().Count; 
        }

        public int GetNbPred()
        {
            if (driver == null)
            {
                return 0;
            }
            return driver.Return_Preds_UI().Count;
        }



        public void Write_Results(string path)
        {

        }

        public void Export_Data()
        {

        }

        public void Make_Video()
        {
            rh.Make_Video();
        }

        public void Require_Stop()
        {
            if (currentstatus == Status.Running)
            {
                driver.Require_Stop();
                currentstatus = Status.Aborted;
            }


        }



    }

}
