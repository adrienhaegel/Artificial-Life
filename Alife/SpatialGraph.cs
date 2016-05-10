using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alife
{
    public partial class SpatialGraph : Form
    {


        public Timer update_timer;

        private int refreshrate;
        public Driver driver;
        object closing_lock;


        public SpatialGraph(Driver driver)
        {

            closing_lock = new object();
            this.driver = driver; //The driver is given, so that the graph can access the data
            InitializeComponent();
            this.refreshrate = (int)double.Parse(textBox_refresh_rate.Text, CultureInfo.InvariantCulture);
            Initialize_Chart();
            Launch_Graphic_interface();
        }



        public void Initialize_Chart() //This sets the chart display parameters
        {
            //sets the window size
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = driver.parameters.Length_x;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = driver.parameters.Length_y;

            // axis properties
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisX.Interval = driver.parameters.Length_x / 10;
            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisY.Interval = driver.parameters.Length_y / 10;
        }


        //Initiates a timer. Each tick, the graph is updated
        private void Launch_Graphic_interface()
        {
            update_timer = new Timer();
            update_timer.Interval = (refreshrate); // 10 secs
            update_timer.Tick += new EventHandler(Spatial_Graph_update);
            update_timer.Start();
        }


        private void Spatial_Graph_update(object sender, EventArgs e) //This is called on each tick of timer_graph_update. Refreshes the graph
        {
            lock (closing_lock)
            {
                //Stops the timer (if the graph update takes long, we do not want the updates to stack up)
                update_timer.Stop();
                try
                {


                    //Resets the axis lengths
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = driver.parameters.Length_x;
                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = driver.parameters.Length_y;

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
                    nb_preds.Text = predserie.Count.ToString();
                    label_nb_preys.Text = preyserie.Count.ToString();
                    label_iteration_time.Text = driver.executiontime.ToString();
                    label_niter.Text = driver.Niter.ToString();
                }

                catch
                {

                }
                //Restarts the timer
                update_timer.Start();
            }
        }





        private void button_update_Click(object sender, EventArgs e)
        {
            this.refreshrate = (int)double.Parse(textBox_refresh_rate.Text, CultureInfo.InvariantCulture);
            update_timer.Interval = refreshrate;
        }




        private void SpatialGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            update_timer.Stop();
            lock (closing_lock)
            {
                update_timer.Dispose();
            }
        }
    }
}
