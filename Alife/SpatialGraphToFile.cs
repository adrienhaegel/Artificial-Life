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
    public partial class SpatialGraphToFile : Form
    {

        public Parameters parameters;
        public int iteration_nb;
        public string pathname;
        public double time;
        List<Prey> listprey;
        List<Predator> listpred;

        public SpatialGraphToFile(List<Prey> listprey, List<Predator> listpred,double time, Parameters parameters, int iteration_nb, string pathname)
        {
            this.iteration_nb = iteration_nb;
            this.listprey = listprey;
            this.listpred = listpred;
          this.time = time;
            this.parameters = parameters;
            this.pathname = pathname;
            InitializeComponent();
            Initialize_Chart();
            Spatial_Graph_update();
            SaveChart();
        }

        public void SaveChart()
        {
           
            chart1.SaveImage(pathname + "\\images\\" + this.iteration_nb.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
            this.Close();
        }

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
            chart1.ChartAreas[0].AxisX.Interval = parameters.Length_x / 10;
            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.None;
            chart1.ChartAreas[0].AxisY.Interval = parameters.Length_y / 10;
        }

        private void Spatial_Graph_update() //This is called on each tick of timer_graph_update. Refreshes the graph
        {

            chart1.Legends[1].CustomItems[0].Name = "time : " + time.ToString("F2"); 

            //Resets the axis lengths
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = parameters.Length_x;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = parameters.Length_y;

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
            label_niter.Text =time.ToString("F2") ;
        }







        private void SpatialGraphToFile_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void label_nb_preys_Click(object sender, EventArgs e)
        {

        }
    }
}
