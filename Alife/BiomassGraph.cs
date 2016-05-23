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
    public partial class BiomassGraph : Form //This window displays value and phase plots for Prey/Predator biomass
    {

        public static Timer update_timer;

        private double timeinterval;
        private int refreshrate;
        public Driver driver;
        object closing_lock;

        

        public BiomassGraph(Driver driver) //constructor
        {
            InitializeComponent();
            this.driver = driver; //The driver is given, so that the graph can access the data
            this.refreshrate = (int)double.Parse(textBox_refreshrate.Text, CultureInfo.InvariantCulture);
            this.timeinterval = double.Parse(textBox_time_interval.Text, CultureInfo.InvariantCulture);
            closing_lock = new object();
            Launch_Graphic_interface();
            
        }
        
        //A biomass point is a data point: amount of prey, amount of predator and time
        public class Biomasspoint
        {
            public double preybiomass;
            public double predbiomass;
            public double time;

            public Biomasspoint(double preybiomass, double predbiomass, double time) //constructor
            {
                this.preybiomass = preybiomass;
                this.predbiomass = predbiomass;
                this.time = time;
            }
        }

        //List of all the data points
        public LinkedList<Biomasspoint> queue;

        //Initiates a timer. Each tick, the graph is updated
        private void Launch_Graphic_interface()
        {
            update_timer = new Timer();
            queue = new LinkedList<Biomasspoint>();
            update_timer.Interval = (refreshrate); // 10 secs
            update_timer.Tick += new EventHandler(Biomass_Graph_update);
            update_timer.Start();
        }




        private void Biomass_Graph_update(object sender, EventArgs e)
        {
            update_timer.Stop();
            lock (closing_lock)
            {
                queue = new LinkedList<Biomasspoint>();
                
                foreach (Driver.Result v in driver.queueresults)
                {
                    queue.AddLast(new Biomasspoint(v.preybiomass, v.predatorbiomass, v.time));
                }
                

            //Biomasspoint newpoint = new Biomasspoint(driver.ReturnPreyBiomass(), driver.ReturnPredatorBiomass(), driver.ReturnCurrentTime());
            //queue.AddLast(newpoint);

            List<Biomasspoint> pointstoremove = queue.Where(p => p.time < queue.Last.Value.time - timeinterval*1.1).ToList();
               
            foreach(var item in pointstoremove)
            {
                queue.Remove(item);
            }

                try
                {
                    //chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Minimum + timeinterval * 1.1;
                    chart1.ChartAreas[0].AxisX.Maximum = timeinterval / 10 * Math.Ceiling(10 * queue.Last.Value.time / timeinterval);
                    //chart1.ChartAreas[0].AxisX.Minimum = timeinterval/10 * Math.Floor(10*queue.ElementAt(0).time / timeinterval);
                    chart1.ChartAreas[0].AxisX.Minimum = Math.Max(0, chart1.ChartAreas[0].AxisX.Maximum - timeinterval);

                    chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                    chart1.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
                    chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
                    chart1.ChartAreas[0].AxisX.Interval = timeinterval / 10;

                    chart1.Series.FindByName("Preys").Points.Clear();
                    var preyserie = chart1.Series.FindByName("Preys").Points;
                    chart1.Series.FindByName("Predators").Points.Clear();
                    var predserie = chart1.Series.FindByName("Predators").Points;

                    chart2.Series.FindByName("PreyPred").Points.Clear();
                    var preypredserie = chart2.Series.FindByName("PreyPred").Points;

                    foreach (var q in queue)
                    {
                        preyserie.AddXY(q.time, q.preybiomass);
                        predserie.AddXY(q.time, q.predbiomass);
                        preypredserie.AddXY(q.preybiomass, q.predbiomass * 10);
                    }
                    
                }
                catch(Exception exc)
                {

                }



                    



            }
            update_timer.Start();

        }

        private void BiomassGraph_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

                update_timer.Stop();
            lock (closing_lock)
            {
                update_timer.Dispose();
            }
        }

        private void BiomassGraph_Load(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {
           this.refreshrate =  (int)double.Parse(textBox_refreshrate.Text, CultureInfo.InvariantCulture);
            this.timeinterval = double.Parse(textBox_time_interval.Text, CultureInfo.InvariantCulture);

            update_timer.Interval = (refreshrate); // 10 secs
            
        }
    }
}
