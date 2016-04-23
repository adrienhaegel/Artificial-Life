using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alife
{
    public partial class Form1 : Form
    {
        Thread WorkerThread;
        Driver driver;
        public Parameters parameters;

        public Form1()
        {

            InitializeComponent();
            parameters = UIParameters();
            Initialize_Chart();
        }

        public void Initialize_Chart()
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = parameters.Length_x;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = parameters.Length_y;
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisY.Interval = 10;
        }

        private void Run_button_Click(object sender, EventArgs e)
        {
            // Stop and launch buttons
            Run_button.Visible = false;
            Stop_button.Visible = true;

            //Update the parameters
            Update_parameters();


            // Create a driver and assign a thread
            driver = new Driver(parameters);
            WorkerThread = new Thread(driver.Start);
            WorkerThread.Start();

            //Calls the graphic interface
            Launch_Graphic_interface();

        }

        private void Launch_Graphic_interface()
        {

            timer1.Interval = (1); // 10 secs
            timer1.Tick += new EventHandler(Main_Graph_update);
            timer1.Start();
        }


        private void Main_Graph_update(object sender, EventArgs e)
        {
            timer1.Stop();

            List<Prey> listprey = driver.Return_Preys();
            List<Predator> listpred = driver.Return_Preds();
            chart1.Series.FindByName("Prey").Points.Clear();
            var preyserie = chart1.Series.FindByName("Prey").Points;
            foreach (Prey p in listprey)
            {
                preyserie.AddXY(p.x, p.y);
            }
            label_nb_preys.Text = preyserie.Count.ToString();
            label_iteration_time.Text = driver.executiontime.ToString();


            chart1.Series.FindByName("Predator").Points.Clear();
            var predserie = chart1.Series.FindByName("Predator").Points;
            foreach (Predator p in listpred)
            {
                predserie.AddXY(p.x, p.y);
            }
            nb_preds.Text = predserie.Count.ToString();
            label_niter.Text = driver.Niter.ToString();
            timer1.Start();

        }





        private void Stop_button_Click(object sender, EventArgs e)
        {
            Run_button.Visible = true;
            Stop_button.Visible = false;
            driver.Require_Stop();
            WorkerThread.Join();
            timer1.Stop();
        }

       
        private Parameters UIParameters()
        {
            Parameters p = new Parameters();
            p.Length_x = Convert.ToDouble(textBox_Lx.Text, CultureInfo.InvariantCulture);
            p.Length_y = Convert.ToDouble(textBox_Ly.Text, CultureInfo.InvariantCulture);
            p.timestep = double.Parse(textBox_time_step.Text, CultureInfo.InvariantCulture);
            p.simulation_delay = Convert.ToInt32(textBox_simulation_delay.Text, CultureInfo.InvariantCulture);
            p.initialpredator = Convert.ToInt32(textBox_initial_predator.Text, CultureInfo.InvariantCulture);
            p.initialprey = Convert.ToInt32(textBox_initial_prey.Text, CultureInfo.InvariantCulture);

            p.preyspeed = double.Parse(textBox_speed_prey.Text, CultureInfo.InvariantCulture);
            p.predatorspeed = double.Parse(textBox_speed_predator.Text, CultureInfo.InvariantCulture);

            p.fertilityprey = double.Parse(textBox_fertility_prey.Text, CultureInfo.InvariantCulture);
            p.fertilitypredator = double.Parse(textBox_fertility_predator.Text, CultureInfo.InvariantCulture);

            p.deathrateprey = double.Parse(textBox_deathrate_prey.Text, CultureInfo.InvariantCulture);
            p.deathratepredator = double.Parse(textBox_deathrate_predator.Text, CultureInfo.InvariantCulture);

            p.huntingarea = double.Parse(textBox_hunting_surface.Text, CultureInfo.InvariantCulture);

            return p;
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
            if(driver != null)
            {
                driver.Update_parameters(this.parameters);
            }
            
        }

        private void label_niter_Click(object sender, EventArgs e)
        {

        }

        private void textBox_time_step_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
