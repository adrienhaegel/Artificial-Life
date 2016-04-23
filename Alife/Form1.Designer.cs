namespace Alife
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
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
            this.Run_button = new System.Windows.Forms.Button();
            this.Stop_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_nb_preys = new System.Windows.Forms.Label();
            this.label_iteration_time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_preds = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_fertility_predator = new System.Windows.Forms.TextBox();
            this.textBox_fertility_prey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_deathrate_predator = new System.Windows.Forms.TextBox();
            this.textBox_deathrate_prey = new System.Windows.Forms.TextBox();
            this.label_speed = new System.Windows.Forms.Label();
            this.textBox_speed_predator = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_speed_prey = new System.Windows.Forms.TextBox();
            this.textBox_hunting_surface = new System.Windows.Forms.TextBox();
            this.label_hunting_surface = new System.Windows.Forms.Label();
            this.textBox_Ly = new System.Windows.Forms.TextBox();
            this.label_Ly = new System.Windows.Forms.Label();
            this.textBox_Lx = new System.Windows.Forms.TextBox();
            this.label_lx = new System.Windows.Forms.Label();
            this.button_modify_parameters = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_time_step = new System.Windows.Forms.TextBox();
            this.label_time_step = new System.Windows.Forms.Label();
            this.textBox_simulation_delay = new System.Windows.Forms.TextBox();
            this.label_simulation_delay = new System.Windows.Forms.Label();
            this.button_add_animals = new System.Windows.Forms.Button();
            this.textBox_Add_pred = new System.Windows.Forms.TextBox();
            this.textBox_Add_prey = new System.Windows.Forms.TextBox();
            this.textBox_initial_predator = new System.Windows.Forms.TextBox();
            this.label_initial_pred = new System.Windows.Forms.Label();
            this.label_initial_prey = new System.Windows.Forms.Label();
            this.textBox_initial_prey = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_niter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.chart1.Location = new System.Drawing.Point(0, 100);
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
            this.chart1.Size = new System.Drawing.Size(684, 661);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Run_button
            // 
            this.Run_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Run_button.FlatAppearance.BorderSize = 3;
            this.Run_button.Location = new System.Drawing.Point(23, 703);
            this.Run_button.Name = "Run_button";
            this.Run_button.Size = new System.Drawing.Size(151, 51);
            this.Run_button.TabIndex = 3;
            this.Run_button.Text = "Run";
            this.Run_button.UseVisualStyleBackColor = false;
            this.Run_button.Click += new System.EventHandler(this.Run_button_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.BackColor = System.Drawing.Color.Tomato;
            this.Stop_button.FlatAppearance.BorderSize = 3;
            this.Stop_button.Location = new System.Drawing.Point(23, 703);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(151, 51);
            this.Stop_button.TabIndex = 4;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = false;
            this.Stop_button.Visible = false;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of preys : ";
            // 
            // label_nb_preys
            // 
            this.label_nb_preys.AutoSize = true;
            this.label_nb_preys.Location = new System.Drawing.Point(112, 19);
            this.label_nb_preys.Name = "label_nb_preys";
            this.label_nb_preys.Size = new System.Drawing.Size(13, 13);
            this.label_nb_preys.TabIndex = 6;
            this.label_nb_preys.Text = "0";
            // 
            // label_iteration_time
            // 
            this.label_iteration_time.Location = new System.Drawing.Point(615, 19);
            this.label_iteration_time.Name = "label_iteration_time";
            this.label_iteration_time.Size = new System.Drawing.Size(69, 17);
            this.label_iteration_time.TabIndex = 7;
            this.label_iteration_time.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number of preds : ";
            // 
            // nb_preds
            // 
            this.nb_preds.AutoSize = true;
            this.nb_preds.Location = new System.Drawing.Point(112, 47);
            this.nb_preds.Name = "nb_preds";
            this.nb_preds.Size = new System.Drawing.Size(13, 13);
            this.nb_preds.TabIndex = 9;
            this.nb_preds.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox_fertility_predator);
            this.panel1.Controls.Add(this.textBox_fertility_prey);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox_deathrate_predator);
            this.panel1.Controls.Add(this.textBox_deathrate_prey);
            this.panel1.Controls.Add(this.label_speed);
            this.panel1.Controls.Add(this.textBox_speed_predator);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox_speed_prey);
            this.panel1.Controls.Add(this.textBox_hunting_surface);
            this.panel1.Controls.Add(this.label_hunting_surface);
            this.panel1.Controls.Add(this.textBox_Ly);
            this.panel1.Controls.Add(this.label_Ly);
            this.panel1.Controls.Add(this.textBox_Lx);
            this.panel1.Controls.Add(this.label_lx);
            this.panel1.Controls.Add(this.button_modify_parameters);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_time_step);
            this.panel1.Controls.Add(this.label_time_step);
            this.panel1.Controls.Add(this.textBox_simulation_delay);
            this.panel1.Controls.Add(this.label_simulation_delay);
            this.panel1.Controls.Add(this.button_add_animals);
            this.panel1.Controls.Add(this.textBox_Add_pred);
            this.panel1.Controls.Add(this.textBox_Add_prey);
            this.panel1.Controls.Add(this.textBox_initial_predator);
            this.panel1.Controls.Add(this.label_initial_pred);
            this.panel1.Controls.Add(this.label_initial_prey);
            this.panel1.Controls.Add(this.textBox_initial_prey);
            this.panel1.Controls.Add(this.Stop_button);
            this.panel1.Controls.Add(this.Run_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(684, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 761);
            this.panel1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 356);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "fertility";
            // 
            // textBox_fertility_predator
            // 
            this.textBox_fertility_predator.Location = new System.Drawing.Point(146, 353);
            this.textBox_fertility_predator.Name = "textBox_fertility_predator";
            this.textBox_fertility_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_fertility_predator.TabIndex = 33;
            this.textBox_fertility_predator.Text = "1";
            this.textBox_fertility_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fertility_prey
            // 
            this.textBox_fertility_prey.Location = new System.Drawing.Point(90, 353);
            this.textBox_fertility_prey.Name = "textBox_fertility_prey";
            this.textBox_fertility_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_fertility_prey.TabIndex = 32;
            this.textBox_fertility_prey.Text = "0.002";
            this.textBox_fertility_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Death Rate";
            // 
            // textBox_deathrate_predator
            // 
            this.textBox_deathrate_predator.Location = new System.Drawing.Point(146, 327);
            this.textBox_deathrate_predator.Name = "textBox_deathrate_predator";
            this.textBox_deathrate_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_deathrate_predator.TabIndex = 30;
            this.textBox_deathrate_predator.Text = "0.003";
            this.textBox_deathrate_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_deathrate_prey
            // 
            this.textBox_deathrate_prey.Location = new System.Drawing.Point(90, 327);
            this.textBox_deathrate_prey.Name = "textBox_deathrate_prey";
            this.textBox_deathrate_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_deathrate_prey.TabIndex = 29;
            this.textBox_deathrate_prey.Text = "0.001";
            this.textBox_deathrate_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Location = new System.Drawing.Point(13, 304);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(38, 13);
            this.label_speed.TabIndex = 28;
            this.label_speed.Text = "Speed";
            // 
            // textBox_speed_predator
            // 
            this.textBox_speed_predator.Location = new System.Drawing.Point(146, 301);
            this.textBox_speed_predator.Name = "textBox_speed_predator";
            this.textBox_speed_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_speed_predator.TabIndex = 27;
            this.textBox_speed_predator.Text = "1";
            this.textBox_speed_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_speed_predator.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Predator";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Prey";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox_speed_prey
            // 
            this.textBox_speed_prey.Location = new System.Drawing.Point(90, 301);
            this.textBox_speed_prey.Name = "textBox_speed_prey";
            this.textBox_speed_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_speed_prey.TabIndex = 24;
            this.textBox_speed_prey.Text = "1";
            this.textBox_speed_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_speed_prey.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox_hunting_surface
            // 
            this.textBox_hunting_surface.Location = new System.Drawing.Point(137, 505);
            this.textBox_hunting_surface.Name = "textBox_hunting_surface";
            this.textBox_hunting_surface.Size = new System.Drawing.Size(37, 20);
            this.textBox_hunting_surface.TabIndex = 23;
            this.textBox_hunting_surface.Text = "0.1";
            this.textBox_hunting_surface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_hunting_surface
            // 
            this.label_hunting_surface.AutoSize = true;
            this.label_hunting_surface.Location = new System.Drawing.Point(38, 508);
            this.label_hunting_surface.Name = "label_hunting_surface";
            this.label_hunting_surface.Size = new System.Drawing.Size(82, 13);
            this.label_hunting_surface.TabIndex = 22;
            this.label_hunting_surface.Text = "Hunting surface";
            // 
            // textBox_Ly
            // 
            this.textBox_Ly.Location = new System.Drawing.Point(132, 77);
            this.textBox_Ly.Name = "textBox_Ly";
            this.textBox_Ly.Size = new System.Drawing.Size(42, 20);
            this.textBox_Ly.TabIndex = 21;
            this.textBox_Ly.Text = "100";
            this.textBox_Ly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Ly
            // 
            this.label_Ly.AutoSize = true;
            this.label_Ly.Location = new System.Drawing.Point(108, 80);
            this.label_Ly.Name = "label_Ly";
            this.label_Ly.Size = new System.Drawing.Size(18, 13);
            this.label_Ly.TabIndex = 20;
            this.label_Ly.Text = "Ly";
            // 
            // textBox_Lx
            // 
            this.textBox_Lx.Location = new System.Drawing.Point(41, 77);
            this.textBox_Lx.Name = "textBox_Lx";
            this.textBox_Lx.Size = new System.Drawing.Size(42, 20);
            this.textBox_Lx.TabIndex = 19;
            this.textBox_Lx.Text = "100";
            this.textBox_Lx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_lx
            // 
            this.label_lx.AutoSize = true;
            this.label_lx.Location = new System.Drawing.Point(20, 80);
            this.label_lx.Name = "label_lx";
            this.label_lx.Size = new System.Drawing.Size(18, 13);
            this.label_lx.TabIndex = 18;
            this.label_lx.Text = "Lx";
            // 
            // button_modify_parameters
            // 
            this.button_modify_parameters.BackColor = System.Drawing.SystemColors.Info;
            this.button_modify_parameters.Location = new System.Drawing.Point(41, 628);
            this.button_modify_parameters.Name = "button_modify_parameters";
            this.button_modify_parameters.Size = new System.Drawing.Size(118, 47);
            this.button_modify_parameters.TabIndex = 17;
            this.button_modify_parameters.Text = "Modify Parameters";
            this.button_modify_parameters.UseVisualStyleBackColor = false;
            this.button_modify_parameters.Click += new System.EventHandler(this.button_modify_parameters_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 225);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(37, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Simulation Delay";
            // 
            // textBox_time_step
            // 
            this.textBox_time_step.Location = new System.Drawing.Point(137, 199);
            this.textBox_time_step.Name = "textBox_time_step";
            this.textBox_time_step.Size = new System.Drawing.Size(37, 20);
            this.textBox_time_step.TabIndex = 14;
            this.textBox_time_step.Text = "0.1";
            this.textBox_time_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_time_step.TextChanged += new System.EventHandler(this.textBox_time_step_TextChanged);
            // 
            // label_time_step
            // 
            this.label_time_step.AutoSize = true;
            this.label_time_step.Location = new System.Drawing.Point(54, 202);
            this.label_time_step.Name = "label_time_step";
            this.label_time_step.Size = new System.Drawing.Size(53, 13);
            this.label_time_step.TabIndex = 13;
            this.label_time_step.Text = "Time step";
            // 
            // textBox_simulation_delay
            // 
            this.textBox_simulation_delay.Location = new System.Drawing.Point(137, 173);
            this.textBox_simulation_delay.Name = "textBox_simulation_delay";
            this.textBox_simulation_delay.Size = new System.Drawing.Size(37, 20);
            this.textBox_simulation_delay.TabIndex = 12;
            this.textBox_simulation_delay.Text = "0";
            this.textBox_simulation_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_simulation_delay
            // 
            this.label_simulation_delay.AutoSize = true;
            this.label_simulation_delay.Location = new System.Drawing.Point(38, 176);
            this.label_simulation_delay.Name = "label_simulation_delay";
            this.label_simulation_delay.Size = new System.Drawing.Size(85, 13);
            this.label_simulation_delay.TabIndex = 11;
            this.label_simulation_delay.Text = "Simulation Delay";
            // 
            // button_add_animals
            // 
            this.button_add_animals.Location = new System.Drawing.Point(90, 51);
            this.button_add_animals.Name = "button_add_animals";
            this.button_add_animals.Size = new System.Drawing.Size(36, 20);
            this.button_add_animals.TabIndex = 10;
            this.button_add_animals.Text = "Add";
            this.button_add_animals.UseVisualStyleBackColor = true;
            this.button_add_animals.Click += new System.EventHandler(this.button_add_animals_Click);
            // 
            // textBox_Add_pred
            // 
            this.textBox_Add_pred.Location = new System.Drawing.Point(132, 51);
            this.textBox_Add_pred.Name = "textBox_Add_pred";
            this.textBox_Add_pred.Size = new System.Drawing.Size(42, 20);
            this.textBox_Add_pred.TabIndex = 9;
            this.textBox_Add_pred.Text = "10";
            this.textBox_Add_pred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Add_prey
            // 
            this.textBox_Add_prey.Location = new System.Drawing.Point(42, 51);
            this.textBox_Add_prey.Name = "textBox_Add_prey";
            this.textBox_Add_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_Add_prey.TabIndex = 8;
            this.textBox_Add_prey.Text = "100";
            this.textBox_Add_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_initial_predator
            // 
            this.textBox_initial_predator.Location = new System.Drawing.Point(132, 25);
            this.textBox_initial_predator.Name = "textBox_initial_predator";
            this.textBox_initial_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_initial_predator.TabIndex = 7;
            this.textBox_initial_predator.Text = "10";
            this.textBox_initial_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_initial_pred
            // 
            this.label_initial_pred.AutoSize = true;
            this.label_initial_pred.Location = new System.Drawing.Point(122, 5);
            this.label_initial_pred.Name = "label_initial_pred";
            this.label_initial_pred.Size = new System.Drawing.Size(66, 17);
            this.label_initial_pred.TabIndex = 6;
            this.label_initial_pred.Text = "Init Predator";
            this.label_initial_pred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_initial_pred.UseCompatibleTextRendering = true;
            // 
            // label_initial_prey
            // 
            this.label_initial_prey.AutoSize = true;
            this.label_initial_prey.Location = new System.Drawing.Point(38, 9);
            this.label_initial_prey.Name = "label_initial_prey";
            this.label_initial_prey.Size = new System.Drawing.Size(45, 13);
            this.label_initial_prey.TabIndex = 5;
            this.label_initial_prey.Text = "Init Prey";
            // 
            // textBox_initial_prey
            // 
            this.textBox_initial_prey.Location = new System.Drawing.Point(41, 25);
            this.textBox_initial_prey.Name = "textBox_initial_prey";
            this.textBox_initial_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_initial_prey.TabIndex = 0;
            this.textBox_initial_prey.Text = "100";
            this.textBox_initial_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_niter);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label_iteration_time);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.nb_preds);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label_nb_preys);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 100);
            this.panel2.TabIndex = 11;
            // 
            // label_niter
            // 
            this.label_niter.AutoSize = true;
            this.label_niter.Location = new System.Drawing.Point(643, 47);
            this.label_niter.Name = "label_niter";
            this.label_niter.Size = new System.Drawing.Size(13, 13);
            this.label_niter.TabIndex = 12;
            this.label_niter.Text = "0";
            this.label_niter.Click += new System.EventHandler(this.label_niter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nb of iterations : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Iteration Time (ms) :";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(600, 800);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Run_button;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_nb_preys;
        private System.Windows.Forms.Label label_iteration_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nb_preds;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_initial_prey;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_initial_prey;
        private System.Windows.Forms.Label label_niter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_add_animals;
        private System.Windows.Forms.TextBox textBox_Add_pred;
        private System.Windows.Forms.TextBox textBox_Add_prey;
        private System.Windows.Forms.TextBox textBox_initial_predator;
        private System.Windows.Forms.Label label_initial_pred;
        private System.Windows.Forms.Button button_modify_parameters;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_time_step;
        private System.Windows.Forms.Label label_time_step;
        private System.Windows.Forms.TextBox textBox_simulation_delay;
        private System.Windows.Forms.Label label_simulation_delay;
        private System.Windows.Forms.Label label_lx;
        private System.Windows.Forms.TextBox textBox_Ly;
        private System.Windows.Forms.Label label_Ly;
        private System.Windows.Forms.TextBox textBox_Lx;
        private System.Windows.Forms.TextBox textBox_speed_predator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_speed_prey;
        private System.Windows.Forms.TextBox textBox_hunting_surface;
        private System.Windows.Forms.Label label_hunting_surface;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_fertility_predator;
        private System.Windows.Forms.TextBox textBox_fertility_prey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_deathrate_predator;
        private System.Windows.Forms.TextBox textBox_deathrate_prey;
    }
}