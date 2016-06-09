using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alife
{
    public partial class Simulation_Planner : Form
    {
        public static int nbthreads = 4;
        public static string savefolder; //Contains a string to save the results

        Thread[] workerthreads;
        List<Simulation> simulations;
        object datagrid_lock;

        BiomassGraph biomassform;


        public void SetNbThreads(int i)
        {
            nbthreads = i;
        }

        public Simulation_Planner(int nbth)
        {
            nbthreads = nbth;
            datagrid_lock = new object();
            InitializeComponent();
            workerthreads = new Thread[nbthreads];
            simulations = new List<Simulation>();
            timer_simulation_update.Interval = 1000;
            timer_simulation_update.Start();
            folderBrowserDialog1.ShowDialog();
            textBox_path.Text = folderBrowserDialog1.SelectedPath;
        }




        private void button_add_simulation_Click(object sender, EventArgs e)
        {
            lock (datagrid_lock)
            {
                Simulation s = new Simulation(UIParameters().Copy());
                simulations.Add(s);
                Reload_data_grid_view();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parameters p = UIParameters();

            double[] fertilityvariation = {0.005,0.01,  0.025,  0.05,0.075,0.1,0.2};

            double[] delay = { 40 };
            double[] speedage = { 0, 0.1, 0.2, 0.4, 0.6};
            foreach (double speed in speedage)
            {
                foreach (double del in delay)
                {
                    foreach (double fert in fertilityvariation)
                    {
                        p.prey_fertility = fert;


                            
                        
                        p.time_between_hunts = del;
                        p.gestation = del*2;
                     
                        p.speed_age[0] = 1 - speed;
                        p.speed_age[4] = 1 - speed;
                        p.speed_age[2] = 1 + speed;

                        Update_equilibrium_values(p, out p.a, out p.b, out p.c, out p.d, out p.e, out p.f, out p.ratio, out p.prey_eq, out p.pred_eq);

                        p.fertility_age[0] = 0;
                        p.fertility_age[1] = fert;
                        p.fertility_age[2] = 2 * fert;
                        p.fertility_age[3] = fert;
                        p.fertility_age[4] = 0;
                        
                        //  p.predator_chemotaxis_speed = mult * chemosp;
                        lock (datagrid_lock)
                        {
                            Simulation s = new Simulation(p.Copy());
                            simulations.Add(s);
                            Reload_data_grid_view();
                        }
                        System.Threading.Thread.Sleep(2);
                    }
                }
            }
            




        }






        private Parameters UIParameters() //This fetches all the values in textboxes and returns a parameter object with the corresponding values.
        {
   
            Parameters p = new Parameters();
            p.Length_x = Convert.ToDouble(textBox_Lx.Text, CultureInfo.InvariantCulture);
            p.Length_y = Convert.ToDouble(textBox_Ly.Text, CultureInfo.InvariantCulture);
            p.timestep = double.Parse(textBox_time_step.Text, CultureInfo.InvariantCulture);




            p.prey_speed = double.Parse(textBox_speed_prey.Text, CultureInfo.InvariantCulture);
            p.predator_speed = double.Parse(textBox_speed_predator.Text, CultureInfo.InvariantCulture);

            p.prey_fertility = double.Parse(textBox_fertility_prey.Text, CultureInfo.InvariantCulture);
            p.predator_fertility = double.Parse(textBox_fertility_predator.Text, CultureInfo.InvariantCulture);

            p.prey_deathrate = double.Parse(textBox_deathrate_prey.Text, CultureInfo.InvariantCulture);
            p.predator_deathrate = double.Parse(textBox_deathrate_predator.Text, CultureInfo.InvariantCulture);

            p.hunting_area = double.Parse(textBox_hunting_surface.Text, CultureInfo.InvariantCulture);
            p.hunting_fertility = double.Parse(textBox_hunting_fertility.Text, CultureInfo.InvariantCulture);

            p.prey_competition = checkBox_Prey_Competition.Checked;
            p.prey_competition_area = double.Parse(textBox_prey_competition_area.Text, CultureInfo.InvariantCulture);
            p.prey_competition_strength = double.Parse(textBox_Prey_competition_strength.Text, CultureInfo.InvariantCulture);

            p.predator_competition = checkBox_Predator_Competition.Checked;
            p.predator_competition_area = double.Parse(textBox_predator_competition_area.Text, CultureInfo.InvariantCulture);
            p.predator_competition_strength = double.Parse(textBox_predator_competition_strength.Text, CultureInfo.InvariantCulture);

            p.prey_chemotaxis = checkBox_Prey_chemotaxis.Checked;
            p.prey_chemotaxis_area = double.Parse(textBox_Prey_chemotaxis_area.Text, CultureInfo.InvariantCulture);
            p.prey_chemotaxis_speed = double.Parse(textBox_Prey_chemotaxis_speed.Text, CultureInfo.InvariantCulture);


            p.predator_chemotaxis = checkBox_Predator_chemotaxis.Checked;
            p.predator_chemotaxis_area = double.Parse(textBox_Predator_chemotaxis_area.Text, CultureInfo.InvariantCulture);
            p.predator_chemotaxis_speed = double.Parse(textBox_Predator_chemotaxis_speed.Text, CultureInfo.InvariantCulture);

            p.final_time_stop = true;
            p.final_time = double.Parse(textBox_final_time.Text, CultureInfo.InvariantCulture);
            p.name = textBox_name.Text;




            p.fertility_age[0] = double.Parse(textBox_fertility_age_0.Text, CultureInfo.InvariantCulture);
            p.deathrate_age[0] = double.Parse(textBox_mortality_age_0.Text, CultureInfo.InvariantCulture);
            p.speed_age[0] = double.Parse(textBox_speed_age_0.Text, CultureInfo.InvariantCulture);

            p.fertility_age[1] = double.Parse(textBox_fertility_age_1.Text, CultureInfo.InvariantCulture);
            p.deathrate_age[1] = double.Parse(textBox_mortality_age_1.Text, CultureInfo.InvariantCulture);
            p.speed_age[1] = double.Parse(textBox_speed_age_1.Text, CultureInfo.InvariantCulture);

            p.fertility_age[2] = double.Parse(textBox_fertility_age_2.Text, CultureInfo.InvariantCulture);
            p.deathrate_age[2] = double.Parse(textBox_mortality_age_2.Text, CultureInfo.InvariantCulture);
            p.speed_age[2] = double.Parse(textBox_speed_age_2.Text, CultureInfo.InvariantCulture);

            p.fertility_age[3] = double.Parse(textBox_fertility_age_3.Text, CultureInfo.InvariantCulture);
            p.deathrate_age[3] = double.Parse(textBox_mortality_age_3.Text, CultureInfo.InvariantCulture);
            p.speed_age[3] = double.Parse(textBox_speed_age_3.Text, CultureInfo.InvariantCulture);

            p.fertility_age[4] = double.Parse(textBox_fertility_age_4.Text, CultureInfo.InvariantCulture);
            p.deathrate_age[4] = double.Parse(textBox_mortality_age_4.Text, CultureInfo.InvariantCulture);
            p.speed_age[4] = double.Parse(textBox_speed_age_4.Text, CultureInfo.InvariantCulture);

            p.maxage = double.Parse(textBox_Maxage.Text, CultureInfo.InvariantCulture);


            Update_equilibrium_values(p, out p.a, out p.b, out p.c, out p.d, out p.e, out p.f, out p.ratio, out p.prey_eq, out p.pred_eq);


            if (checkBox_initvalue_eq.Checked)
            {
                textBox_initial_prey.Text = Math.Floor(p.prey_eq).ToString();
                textBox_initial_predator.Text = Math.Floor(p.pred_eq).ToString();
            }
            p.initialpredator = Convert.ToInt32(textBox_initial_predator.Text, CultureInfo.InvariantCulture);
            p.initialprey = Convert.ToInt32(textBox_initial_prey.Text, CultureInfo.InvariantCulture);


            // p.path = textBox_path.Text;
            string file = folderBrowserDialog1.SelectedPath;
            if (textBox_subfolder.Text != "")
            {
                file += "\\" + textBox_subfolder.Text;
            }
            textBox_path.Text = file;
            savefolder = file;
            p.path = file;

            p.time_between_hunts = double.Parse(textBox_time_between_hunts.Text, CultureInfo.InvariantCulture);
            p.gestation = double.Parse(textBox_gestation.Text, CultureInfo.InvariantCulture);
            p.time_between_reproduction = double.Parse(textBox_time_between_reproductions.Text, CultureInfo.InvariantCulture);

            return p;
        }


        public void Update_simulations()
        {

            for (int i = 0; i < nbthreads; i++)
            {
                if (workerthreads[i] == null || workerthreads[i].ThreadState == ThreadState.Stopped || workerthreads[i].ThreadState == ThreadState.Aborted)
                {
                    Simulation simtolaunch = simulations.FirstOrDefault(s => s.thread_assigned == false && s.currentstatus == Simulation.Status.Waiting);
                    if (simtolaunch != null)
                    {
                        workerthreads[i] = new Thread(simtolaunch.Run);
                        workerthreads[i].IsBackground = true;
                        simtolaunch.thread_assigned = true;
                        simtolaunch.threadid = i;
                        workerthreads[i].Start();
                    }
                }
            }




            Update_data_grid_view();

        }

        public void Update_data_grid_view()
        {
            for (int i = 0; i < dataGridView_simulations.RowCount; i++)
            {
                int simid = (int)dataGridView_simulations.Rows[i].Cells[0].Value;
                Simulation s = simulations.Find(sim => sim.index == simid);
                dataGridView_simulations.Rows[i].SetValues(s.index, s.name, s.currentstatus, s.GetProgress(), s.GetNbPrey(), s.GetNbPred());
            }
        }


        public void Reload_data_grid_view()
        {
            dataGridView_simulations.Rows.Clear();
            foreach (Simulation s in simulations)
            {
                /*
                if ( s.index >= dataGridView_simulations.Rows.Count  )
                {
                    dataGridView_simulations.Rows.Add(s.index, s.name, s.currentstatus,s.GetProgress());
                    
                }
                else
                {
                */
                dataGridView_simulations.Rows.Add(s.index, s.name, s.currentstatus, s.GetProgress(), s.GetNbPrey(), s.GetNbPred());
                // dataGridView_simulations.Rows[s.index].SetValues(s.index, s.name, s.currentstatus, s.GetProgress());
                //}
            }
        }


        private void button_eq_values_Click(object sender, EventArgs e)
        {
            Update_equilibrium_values();
        }
        public void Update_equilibrium_values()
        {
            Parameters parameters = UIParameters();
            double a = parameters.prey_fertility - parameters.prey_deathrate;
            double b;
            if (parameters.prey_competition)
            {
                b = (-Math.PI * parameters.prey_competition_area * parameters.prey_competition_area * parameters.prey_competition_strength / (parameters.Length_x * parameters.Length_y));

            }
            else
            {
                b = 0;
            }
            double c = -Math.PI * parameters.hunting_area * parameters.hunting_area / (parameters.Length_x * parameters.Length_y);
            double d = parameters.predator_fertility - parameters.predator_deathrate;
            double e;
            if (parameters.predator_competition)
            {
                e = -Math.PI * parameters.predator_competition_area * parameters.predator_competition_area * parameters.predator_competition_strength / (parameters.Length_x * parameters.Length_y);

            }
            else
            {
                e = 0;
            }


            double f = -parameters.hunting_fertility * c;

            double ratio = (c * d - a * e) / (f * a - b * d);
            double prey_eq = (c * d - a * e) / (b * e - f * c);
            double pred_eq = (f * a - b * d) / (b * e - f * c);

            label_a.Text = a.ToString("e1");
            label_b.Text = b.ToString("e1");
            label_c.Text = c.ToString("e1");
            label_d.Text = d.ToString("e1");
            label_e.Text = e.ToString("e1");
            label_f.Text = f.ToString("e1");

            label_prey_eq.Text = prey_eq.ToString("F2");
            label_predator_eq.Text = pred_eq.ToString("F2");
            label_ratio.Text = ratio.ToString("F2");

        }

        public void Update_equilibrium_values(Parameters parameters, out double a, out double b, out double c, out double d, out double e, out double f, out double ratio, out double prey_eq, out double pred_eq)
        {
            a = parameters.prey_fertility - parameters.prey_deathrate;

            if (parameters.prey_competition)
            {
                b = (-Math.PI * parameters.prey_competition_area * parameters.prey_competition_area * parameters.prey_competition_strength / (parameters.Length_x * parameters.Length_y));

            }
            else
            {
                b = 0;
            }
            c = -Math.PI * parameters.hunting_area * parameters.hunting_area / (parameters.Length_x * parameters.Length_y);
            d = parameters.predator_fertility - parameters.predator_deathrate;
            if (parameters.predator_competition)
            {
                e = -Math.PI * parameters.predator_competition_area * parameters.predator_competition_area * parameters.predator_competition_strength / (parameters.Length_x * parameters.Length_y);

            }
            else
            {
                e = 0;
            }


            f = -parameters.hunting_fertility * c;

            ratio = (c * d - a * e) / (f * a - b * d);
            prey_eq = (c * d - a * e) / (b * e - f * c);
            pred_eq = (f * a - b * d) / (b * e - f * c);

            label_a.Text = a.ToString("e1");
            label_b.Text = b.ToString("e1");
            label_c.Text = c.ToString("e1");
            label_d.Text = d.ToString("e1");
            label_e.Text = e.ToString("e1");
            label_f.Text = f.ToString("e1");

            label_prey_eq.Text = prey_eq.ToString("F2");
            label_predator_eq.Text = pred_eq.ToString("F2");
            label_ratio.Text = ratio.ToString("F2");

        }
        private void checkBox_Prey_chemotaxis_CheckedChanged(object sender, EventArgs e) //Displays chemotaxis parameters if chemotaxis is activated : PREY
        {
            if (this.checkBox_Prey_chemotaxis.Checked)
            {
                label_Prey_chemotaxis_speed.Visible = true;
                label_Prey_chemotaxis_area.Visible = true;
                textBox_Prey_chemotaxis_area.Visible = true;
                textBox_Prey_chemotaxis_speed.Visible = true;
            }
            else
            {
                label_Prey_chemotaxis_speed.Visible = false;
                label_Prey_chemotaxis_area.Visible = false;
                textBox_Prey_chemotaxis_area.Visible = false;
                textBox_Prey_chemotaxis_speed.Visible = false;
            }
        }

        private void checkBox_Predator_chemotaxis_CheckedChanged(object sender, EventArgs e) //Displays chemotaxis parameters if chemotaxis is activated : PREDATOR
        {
            if (this.checkBox_Predator_chemotaxis.Checked)
            {

                label_Predator_chemotaxis_area.Visible = true;
                label_Predator_chemotaxis_speed.Visible = true;
                textBox_Predator_chemotaxis_area.Visible = true;
                textBox_Predator_chemotaxis_speed.Visible = true;
            }
            else
            {
                label_Predator_chemotaxis_area.Visible = false;
                label_Predator_chemotaxis_speed.Visible = false;
                textBox_Predator_chemotaxis_area.Visible = false;
                textBox_Predator_chemotaxis_speed.Visible = false;
            }
        }



        private void checkBox_Prey_Competition_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Prey_Competition.Checked)
            {
                label_prey_competition_area.Visible = true;
                textBox_prey_competition_area.Visible = true;
                label_prey_competiton_strength.Visible = true;
                textBox_Prey_competition_strength.Visible = true;
            }
            else
            {
                label_prey_competition_area.Visible = false;
                textBox_prey_competition_area.Visible = false;
                label_prey_competiton_strength.Visible = false;
                textBox_Prey_competition_strength.Visible = false;
            }
        }

        private void checkBox_Predator_Competition_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Predator_Competition.Checked)
            {
                label_predator_competition_area.Visible = true;
                textBox_predator_competition_area.Visible = true;
                label_predator_competition_strength.Visible = true;
                textBox_predator_competition_strength.Visible = true;
            }
            else
            {
                label_predator_competition_area.Visible = false;
                textBox_predator_competition_area.Visible = false;
                label_predator_competition_strength.Visible = false;
                textBox_predator_competition_strength.Visible = false;
            }
        }





        private void button_change_directory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    string file = folderBrowserDialog1.SelectedPath;
                    if (textBox_subfolder.Text != "")
                    {
                        file += "\\" + textBox_subfolder.Text;
                    }


                    textBox_path.Text = file;
                    savefolder = file;
                }
                catch (IOException)
                {
                }
            }

        }


        private void textBox_path_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_subfolder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string file = folderBrowserDialog1.SelectedPath;
                if (textBox_subfolder.Text != "")
                {
                    file += "\\" + textBox_subfolder.Text;
                }


                textBox_path.Text = file;
                savefolder = file;
            }
            catch (IOException)
            {
            }
        }

        private void timer_simulation_update_Tick(object sender, EventArgs e)
        {
            timer_simulation_update.Stop();
            lock (datagrid_lock)
            {
                Update_simulations();
            }
            timer_simulation_update.Start();
        }

        private void dataGridView_simulations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 5)
            {
                Highlight_information(e.RowIndex);
            }
            if (e.ColumnIndex == 6)
            {
                Display_Spatial(e.RowIndex);
            }
            if (e.ColumnIndex == 7)
            {

                Display_biomass(e.RowIndex);
            }
            if (e.ColumnIndex == 8)
            {
                Delete_Simulation(e.RowIndex);
            }

        }

        public void Delete_Simulation(int rowIndex)
        {
            try
            {
                lock (datagrid_lock)
                {
                    int simid = (int)dataGridView_simulations.Rows[rowIndex].Cells[0].Value;
                    Simulation s = simulations.Find(sim => sim.index == simid);
                    s.Require_Stop();
                    if (s.thread_assigned)
                    {
                        workerthreads[s.threadid].Abort();
                    }
                    simulations.Remove(s);
                    Reload_data_grid_view();
                }
            }
            catch
            {

            }

        }

        public void Display_biomass(int rowIndex)
        {
            try
            {
                if (biomassform != null)
                {
                    biomassform.Close();
                }
                biomassform = new BiomassGraph(simulations[rowIndex].driver);
                biomassform.Show();
            }
            catch
            {

            }

        }

        public void Display_Spatial(int rowIndex)
        {
            try
            {
                Form spatialform = new SpatialGraph(simulations[rowIndex].driver);
                spatialform.Show();
            }
            catch
            {

            }

        }

        public void Highlight_information(int rowindex)
        {
            try
            {
                textBox_information.Text = simulations[rowindex].parameters.ToString();
            }
            catch
            {

            }

        }



        private void form_planner_Load(object sender, EventArgs e)
        {
            //button_change_directory_Click(sender, e);
        }

        private void textBox_prey_competition_area_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_initvalue_eq_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_initvalue_eq.Checked)
            {
                textBox_initial_prey.Enabled = false;
                textBox_initial_predator.Enabled = false;
            }
            else
            {
                textBox_initial_prey.Enabled = true;
                textBox_initial_predator.Enabled = true;
            }
        }

        private void checkBox_age_dependency_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_age_dependency.Checked)
            {
                textBox_fertility_age_0.Enabled = true;
                textBox_fertility_age_1.Enabled = true;
                textBox_fertility_age_2.Enabled = true;
                textBox_fertility_age_3.Enabled = true;
                textBox_fertility_age_4.Enabled = true;

                textBox_fertility_age_0.Text = textBox_fertility_prey.Text;
                textBox_fertility_age_1.Text = textBox_fertility_prey.Text;
                textBox_fertility_age_2.Text = textBox_fertility_prey.Text;
                textBox_fertility_age_3.Text = textBox_fertility_prey.Text;
                textBox_fertility_age_4.Text = textBox_fertility_prey.Text;



                textBox_mortality_age_0.Enabled = true;
                textBox_mortality_age_1.Enabled = true;
                textBox_mortality_age_2.Enabled = true;
                textBox_mortality_age_3.Enabled = true;
                textBox_mortality_age_4.Enabled = true;

                textBox_mortality_age_0.Text = textBox_deathrate_prey.Text;
                textBox_mortality_age_1.Text = textBox_deathrate_prey.Text;
                textBox_mortality_age_2.Text = textBox_deathrate_prey.Text;
                textBox_mortality_age_3.Text = textBox_deathrate_prey.Text;
                textBox_mortality_age_4.Text = textBox_deathrate_prey.Text;




                textBox_speed_age_0.Enabled = true;
                textBox_speed_age_1.Enabled = true;
                textBox_speed_age_2.Enabled = true;
                textBox_speed_age_3.Enabled = true;
                textBox_speed_age_4.Enabled = true;

                textBox_speed_age_0.Text = 1.ToString();
                textBox_speed_age_1.Text = 1.ToString();
                textBox_speed_age_2.Text = 1.ToString();
                textBox_speed_age_3.Text = 1.ToString();
                textBox_speed_age_4.Text = 1.ToString();
            }
            else
            {
                textBox_fertility_age_0.Enabled = false;
                textBox_fertility_age_1.Enabled = false;
                textBox_fertility_age_2.Enabled = false;
                textBox_fertility_age_3.Enabled = false;
                textBox_fertility_age_4.Enabled = false;

                textBox_mortality_age_0.Enabled = false;
                textBox_mortality_age_1.Enabled = false;
                textBox_mortality_age_2.Enabled = false;
                textBox_mortality_age_3.Enabled = false;
                textBox_mortality_age_4.Enabled = false;

                textBox_speed_age_0.Enabled = false;
                textBox_speed_age_1.Enabled = false;
                textBox_speed_age_2.Enabled = false;
                textBox_speed_age_3.Enabled = false;
                textBox_speed_age_4.Enabled = false;
            }



        }

        private void textBox_deathrate_prey_TextChanged(object sender, EventArgs e)
        {
            textBox_mortality_age_0.Text = textBox_deathrate_prey.Text;
            textBox_mortality_age_1.Text = textBox_deathrate_prey.Text;
            textBox_mortality_age_2.Text = textBox_deathrate_prey.Text;
            textBox_mortality_age_3.Text = textBox_deathrate_prey.Text;
            textBox_mortality_age_4.Text = textBox_deathrate_prey.Text;

        }

        private void textBox_fertility_prey_TextChanged(object sender, EventArgs e)
        {
            textBox_fertility_age_0.Text = textBox_fertility_prey.Text;
            textBox_fertility_age_1.Text = textBox_fertility_prey.Text;
            textBox_fertility_age_2.Text = textBox_fertility_prey.Text;
            textBox_fertility_age_3.Text = textBox_fertility_prey.Text;
            textBox_fertility_age_4.Text = textBox_fertility_prey.Text;


        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Simulation_Planner_FormClosing(object sender, FormClosingEventArgs e) //This requests everything to terminate.
        {


        }
    }
}
