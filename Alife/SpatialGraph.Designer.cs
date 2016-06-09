namespace Alife
{
    partial class SpatialGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "2,0");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 1D);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox_refresh_rate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.label_niter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_iteration_time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_preds = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_nb_preys = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.SystemColors.WindowFrame;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.ImeMode = System.Windows.Forms.ImeMode.On;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderWidth = 0;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.IsDockedInsideChartArea = false;
            legend1.MaximumAutoSize = 5F;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.MinimumSize = new System.Drawing.Size(400, 500);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.MarkerSize = 2;
            series1.Name = "Prey";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Predator";
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(859, 617);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // textBox_refresh_rate
            // 
            this.textBox_refresh_rate.Location = new System.Drawing.Point(79, 12);
            this.textBox_refresh_rate.Name = "textBox_refresh_rate";
            this.textBox_refresh_rate.Size = new System.Drawing.Size(100, 20);
            this.textBox_refresh_rate.TabIndex = 2;
            this.textBox_refresh_rate.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "refresh-rate";
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(201, 9);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 4;
            this.button_update.Text = "Apply";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label_niter
            // 
            this.label_niter.AutoSize = true;
            this.label_niter.Location = new System.Drawing.Point(807, 37);
            this.label_niter.Name = "label_niter";
            this.label_niter.Size = new System.Drawing.Size(13, 13);
            this.label_niter.TabIndex = 16;
            this.label_niter.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(702, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nb of iterations : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(674, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Iteration Time (ms) :";
            // 
            // label_iteration_time
            // 
            this.label_iteration_time.Location = new System.Drawing.Point(779, 9);
            this.label_iteration_time.Name = "label_iteration_time";
            this.label_iteration_time.Size = new System.Drawing.Size(69, 17);
            this.label_iteration_time.TabIndex = 13;
            this.label_iteration_time.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Number of preds : ";
            // 
            // nb_preds
            // 
            this.nb_preds.AutoSize = true;
            this.nb_preds.Location = new System.Drawing.Point(628, 37);
            this.nb_preds.Name = "nb_preds";
            this.nb_preds.Size = new System.Drawing.Size(13, 13);
            this.nb_preds.TabIndex = 20;
            this.nb_preds.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Number of preys : ";
            // 
            // label_nb_preys
            // 
            this.label_nb_preys.AutoSize = true;
            this.label_nb_preys.Location = new System.Drawing.Point(628, 9);
            this.label_nb_preys.Name = "label_nb_preys";
            this.label_nb_preys.Size = new System.Drawing.Size(13, 13);
            this.label_nb_preys.TabIndex = 18;
            this.label_nb_preys.Text = "0";
            // 
            // SpatialGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 617);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nb_preds);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_nb_preys);
            this.Controls.Add(this.label_niter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_iteration_time);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_refresh_rate);
            this.Controls.Add(this.chart1);
            this.Name = "SpatialGraph";
            this.Text = "Spatial simulation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpatialGraph_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox_refresh_rate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_niter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_iteration_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nb_preds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_nb_preys;
    }
}