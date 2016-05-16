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
    public partial class RealTimeSimulation : Form
    {
        public string savefolder;
        Thread WorkerThread; //The thread that will be used for calculations
        Driver driver; //The Driver object that manages the calculations
        public Parameters parameters; //parameters

        public RealTimeSimulation()
        {
            InitializeComponent();
            parameters = UIParameters(); //Construct the parameters with the initial values in textboxes
            //Initialize_Chart(); // Initialize the main chart

        }

        /*
        public void Initialize_Chart() //This sets the chart display parameters
        {
            //sets the window size
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = parameters.Length_x;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = parameters.Length_y;

            // axis properties
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisY.Interval = 10;
        }
        */
        private void Run_button_Click(object sender, EventArgs e) //Run the simulation
        {
            // Update stop and launch buttons
            Run_button.Visible = false;
            Pause_button.Visible = true;
            Stop_button.Visible = true;
            
            //Update the parameters
            Update_parameters();


            // Create a driver and assign a thread
            driver = new Driver(parameters);
            WorkerThread = new Thread(driver.Start);
            WorkerThread.Start();

            //Calls the graphic interface
            //Launch_Graphic_interface();
            Open_Spatial_Graph();
        }

        private void Stop_button_Click(object sender, EventArgs e) //Stops the simulation
        {
            // Update stop and launch buttons
            Run_button.Visible = true;
            Pause_button.Visible = false;

            //Ask the driver to stop
            driver.Require_Stop();

            //Stop the timer for the graph update
            timer_graph_update.Stop();

            //wait for the driver to stop
            WorkerThread.Join();
        }

        private void Pause_button_Click(object sender, EventArgs e) //Pauses the simulation
        {
            if (WorkerThread.IsAlive) //If the simulation is running : stops it
            {
                // Update stop and launch buttons
                Run_button.Visible = false;
                Pause_button.Visible = true;

                //Ask the driver to stop
                driver.Require_Stop();

                //Stop the timer for the graph update
                timer_graph_update.Stop();

                //wait for the driver to stop
                WorkerThread.Join();
            }
            else //The simulation is not running : starts it again
            {
                //Calls "Relaunch" on a new thread
                WorkerThread = new Thread(driver.Relaunch);
                WorkerThread.Start();

                //Restart graph update timer
                timer_graph_update.Start();
            }
        }

        /*
    private void Launch_Graphic_interface() //Initialize the timer
    {

        timer_graph_update.Interval = (100); // 10 secs
        timer_graph_update.Tick += new EventHandler(Main_Graph_update);
        timer_graph_update.Start();
    }



    private void Main_Graph_update(object sender, EventArgs e) //This is called on each tick of timer_graph_update. Refreshes the graph
    {
        //Stops the timer (if the graph update takes long, we do not want the updates to stack up)
        timer_graph_update.Stop();

        //Resets the axis lengths
        chart1.ChartAreas[0].AxisX.Minimum = 0;
        chart1.ChartAreas[0].AxisX.Maximum = parameters.Length_x;
        chart1.ChartAreas[0].AxisY.Minimum = 0;
        chart1.ChartAreas[0].AxisY.Maximum = parameters.Length_y;

        //Gets the lists of animals
        List<Prey> listprey = driver.Return_Preys_UI();
        List<Predator> listpred = driver.Return_Preds_UI();

        //Add "Prey" points
        chart1.Series.FindByName("Prey").Points.Clear();
        var preyserie = chart1.Series.FindByName("Prey").Points;
        foreach (Prey p in listprey)
        {
            preyserie.AddXY(p.x, p.y);
        }

        //Add "Predators" points
        chart1.Series.FindByName("Predator").Points.Clear();
        var predserie = chart1.Series.FindByName("Predator").Points;
        foreach (Predator p in listpred)
        {
            predserie.AddXY(p.x, p.y);
        }

        //Updates information labels
        nb_preds.Text = predserie.Count.ToString();
        label_nb_preys.Text = preyserie.Count.ToString();
        label_iteration_time.Text = driver.executiontime.ToString();
        label_niter.Text = driver.Niter.ToString();

        //Restarts the timer
        timer_graph_update.Start();
    }
    */
        private Parameters UIParameters() //This fetches all the values in textboxes and returns a parameter object with the corresponding values.
        {
            Parameters p = new Parameters();
            p.Length_x = Convert.ToDouble(textBox_Lx.Text, CultureInfo.InvariantCulture);
            p.Length_y = Convert.ToDouble(textBox_Ly.Text, CultureInfo.InvariantCulture);
            p.timestep = double.Parse(textBox_time_step.Text, CultureInfo.InvariantCulture);
            p.simulation_delay = Convert.ToInt32(textBox_simulation_delay.Text, CultureInfo.InvariantCulture);
            p.initialpredator = Convert.ToInt32(textBox_initial_predator.Text, CultureInfo.InvariantCulture);
            p.initialprey = Convert.ToInt32(textBox_initial_prey.Text, CultureInfo.InvariantCulture);

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
            p.prey_chemotaxis_speed= double.Parse(textBox_Prey_chemotaxis_speed.Text, CultureInfo.InvariantCulture);


            p.predator_chemotaxis = checkBox_Predator_chemotaxis.Checked;
            p.predator_chemotaxis_area = double.Parse(textBox_Predator_chemotaxis_area.Text, CultureInfo.InvariantCulture);
            p.predator_chemotaxis_speed = double.Parse(textBox_Predator_chemotaxis_speed.Text, CultureInfo.InvariantCulture);

            p.path = textBox_path.Text;

            return p;
        }

        public void Update_equilibrium_values()
        {
            double a = parameters.prey_fertility - parameters.prey_deathrate;
            double b = -Math.PI * parameters.prey_competition_area * parameters.prey_competition_area * parameters.prey_competition_strength / (parameters.Length_x * parameters.Length_y);
            double c = -Math.PI * parameters.hunting_area* parameters.hunting_area / (parameters.Length_x * parameters.Length_y);
            double d = parameters.predator_fertility - parameters.predator_deathrate;
            double e = -Math.PI * parameters.predator_competition_area * parameters.predator_competition_area * parameters.predator_competition_strength / (parameters.Length_x * parameters.Length_y);
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

        private void button_add_animals_Click(object sender, EventArgs e)
        {
            driver.Add_Random_Prey(Convert.ToInt32(textBox_Add_prey.Text));
            driver.Add_Random_Predator(Convert.ToInt32(textBox_Add_pred.Text));
        }

        private void button_modify_parameters_Click(object sender, EventArgs e)
        {
            Update_parameters();
        }

        private void Update_parameters()
        {
            this.parameters = UIParameters();
            Update_equilibrium_values();
            if (driver != null)
            {
                driver.Update_parameters(this.parameters);
            }
            
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
            Update_parameters();
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
            Update_parameters();
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
            Update_parameters();
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
            Update_parameters();
        }

        private void textBox_initial_prey_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        
        }

        private void Button_Graph_Biomass_Click(object sender, EventArgs e)
        {
            Form biomassform = new BiomassGraph(this.driver);
            biomassform.Show();

        }

        private void button_spatial_graph_Click(object sender, EventArgs e)
        {
            Open_Spatial_Graph();
        }

        public void Open_Spatial_Graph()
        {
            Form spatialgraph = new SpatialGraph(this.driver);
            spatialgraph.Show();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_change_directory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    string file = folderBrowserDialog1.SelectedPath;
                    textBox_path.Text = file;
                    savefolder = file;
                }
                catch (IOException)
                {
                }
            }
            
        }
    }
}
