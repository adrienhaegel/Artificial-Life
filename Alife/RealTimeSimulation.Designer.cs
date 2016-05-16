namespace Alife
{
    partial class RealTimeSimulation
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
            this.Run_button = new System.Windows.Forms.Button();
            this.Pause_button = new System.Windows.Forms.Button();
            this.timer_graph_update = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_nb_preys = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nb_preds = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_ratio = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label_predator_eq = new System.Windows.Forms.Label();
            this.label_prey_eq = new System.Windows.Forms.Label();
            this.label_f = new System.Windows.Forms.Label();
            this.label_e = new System.Windows.Forms.Label();
            this.label_d = new System.Windows.Forms.Label();
            this.label_c = new System.Windows.Forms.Label();
            this.label_b = new System.Windows.Forms.Label();
            this.label_a = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_initial_prey = new System.Windows.Forms.Label();
            this.textBox_initial_prey = new System.Windows.Forms.TextBox();
            this.textBox_Add_prey = new System.Windows.Forms.TextBox();
            this.label_lx = new System.Windows.Forms.Label();
            this.textBox_Lx = new System.Windows.Forms.TextBox();
            this.button_add_animals = new System.Windows.Forms.Button();
            this.label_initial_pred = new System.Windows.Forms.Label();
            this.textBox_initial_predator = new System.Windows.Forms.TextBox();
            this.textBox_Add_pred = new System.Windows.Forms.TextBox();
            this.label_Ly = new System.Windows.Forms.Label();
            this.textBox_Ly = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_prey_competiton_strength = new System.Windows.Forms.Label();
            this.textBox_Prey_competition_strength = new System.Windows.Forms.TextBox();
            this.textBox_hunting_fertility = new System.Windows.Forms.TextBox();
            this.checkBox_Predator_Competition = new System.Windows.Forms.CheckBox();
            this.textBox_prey_competition_area = new System.Windows.Forms.TextBox();
            this.checkBox_Prey_Competition = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_predator_competition_area = new System.Windows.Forms.TextBox();
            this.label_predator_competition_strength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_fertility_predator = new System.Windows.Forms.TextBox();
            this.textBox_hunting_surface = new System.Windows.Forms.TextBox();
            this.textBox_fertility_prey = new System.Windows.Forms.TextBox();
            this.textBox_deathrate_prey = new System.Windows.Forms.TextBox();
            this.label_prey_competition_area = new System.Windows.Forms.Label();
            this.textBox_deathrate_predator = new System.Windows.Forms.TextBox();
            this.label_hunting_surface = new System.Windows.Forms.Label();
            this.textBox_predator_competition_strength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_predator_competition_area = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_Prey_chemotaxis_area = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Prey_chemotaxis_area = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox_Predator_chemotaxis = new System.Windows.Forms.CheckBox();
            this.label_speed = new System.Windows.Forms.Label();
            this.textBox_Prey_chemotaxis_speed = new System.Windows.Forms.TextBox();
            this.textBox_speed_predator = new System.Windows.Forms.TextBox();
            this.checkBox_Prey_chemotaxis = new System.Windows.Forms.CheckBox();
            this.textBox_Predator_chemotaxis_speed = new System.Windows.Forms.TextBox();
            this.textBox_speed_prey = new System.Windows.Forms.TextBox();
            this.label_Predator_chemotaxis_area = new System.Windows.Forms.Label();
            this.label_Predator_chemotaxis_speed = new System.Windows.Forms.Label();
            this.label_Prey_chemotaxis_speed = new System.Windows.Forms.Label();
            this.textBox_Predator_chemotaxis_area = new System.Windows.Forms.TextBox();
            this.Stop_button = new System.Windows.Forms.Button();
            this.button_modify_parameters = new System.Windows.Forms.Button();
            this.textBox_time_step = new System.Windows.Forms.TextBox();
            this.label_time_step = new System.Windows.Forms.Label();
            this.textBox_simulation_delay = new System.Windows.Forms.TextBox();
            this.label_simulation_delay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_spatial_graph = new System.Windows.Forms.Button();
            this.Button_Graph_Biomass = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Simulation_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_spatial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_biomass_graph = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_change_directory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Run_button
            // 
            this.Run_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Run_button.FlatAppearance.BorderSize = 3;
            this.Run_button.Location = new System.Drawing.Point(56, 703);
            this.Run_button.Name = "Run_button";
            this.Run_button.Size = new System.Drawing.Size(151, 51);
            this.Run_button.TabIndex = 3;
            this.Run_button.Text = "Run";
            this.Run_button.UseVisualStyleBackColor = false;
            this.Run_button.Click += new System.EventHandler(this.Run_button_Click);
            // 
            // Pause_button
            // 
            this.Pause_button.BackColor = System.Drawing.Color.Yellow;
            this.Pause_button.FlatAppearance.BorderSize = 3;
            this.Pause_button.Location = new System.Drawing.Point(56, 703);
            this.Pause_button.Name = "Pause_button";
            this.Pause_button.Size = new System.Drawing.Size(151, 51);
            this.Pause_button.TabIndex = 4;
            this.Pause_button.Text = "Pause";
            this.Pause_button.UseVisualStyleBackColor = false;
            this.Pause_button.Visible = false;
            this.Pause_button.Click += new System.EventHandler(this.Pause_button_Click);
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
            this.panel1.Controls.Add(this.label_ratio);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label_predator_eq);
            this.panel1.Controls.Add(this.label_prey_eq);
            this.panel1.Controls.Add(this.label_f);
            this.panel1.Controls.Add(this.label_e);
            this.panel1.Controls.Add(this.label_d);
            this.panel1.Controls.Add(this.label_c);
            this.panel1.Controls.Add(this.label_b);
            this.panel1.Controls.Add(this.label_a);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.Stop_button);
            this.panel1.Controls.Add(this.button_modify_parameters);
            this.panel1.Controls.Add(this.Pause_button);
            this.panel1.Controls.Add(this.Run_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(992, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 761);
            this.panel1.TabIndex = 10;
            // 
            // label_ratio
            // 
            this.label_ratio.AutoSize = true;
            this.label_ratio.Location = new System.Drawing.Point(111, 548);
            this.label_ratio.Name = "label_ratio";
            this.label_ratio.Size = new System.Drawing.Size(13, 13);
            this.label_ratio.TabIndex = 64;
            this.label_ratio.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 548);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(27, 13);
            this.label20.TabIndex = 63;
            this.label20.Text = "ratio";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 574);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 13);
            this.label19.TabIndex = 62;
            this.label19.Text = "Predator equilibrium";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 561);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 13);
            this.label18.TabIndex = 61;
            this.label18.Text = "Prey equilibrium";
            // 
            // label_predator_eq
            // 
            this.label_predator_eq.AutoSize = true;
            this.label_predator_eq.Location = new System.Drawing.Point(111, 574);
            this.label_predator_eq.Name = "label_predator_eq";
            this.label_predator_eq.Size = new System.Drawing.Size(13, 13);
            this.label_predator_eq.TabIndex = 60;
            this.label_predator_eq.Text = "0";
            // 
            // label_prey_eq
            // 
            this.label_prey_eq.AutoSize = true;
            this.label_prey_eq.Location = new System.Drawing.Point(111, 561);
            this.label_prey_eq.Name = "label_prey_eq";
            this.label_prey_eq.Size = new System.Drawing.Size(13, 13);
            this.label_prey_eq.TabIndex = 59;
            this.label_prey_eq.Text = "0";
            // 
            // label_f
            // 
            this.label_f.AutoSize = true;
            this.label_f.Location = new System.Drawing.Point(45, 535);
            this.label_f.Name = "label_f";
            this.label_f.Size = new System.Drawing.Size(13, 13);
            this.label_f.TabIndex = 58;
            this.label_f.Text = "0";
            // 
            // label_e
            // 
            this.label_e.AutoSize = true;
            this.label_e.Location = new System.Drawing.Point(45, 522);
            this.label_e.Name = "label_e";
            this.label_e.Size = new System.Drawing.Size(13, 13);
            this.label_e.TabIndex = 57;
            this.label_e.Text = "0";
            // 
            // label_d
            // 
            this.label_d.AutoSize = true;
            this.label_d.Location = new System.Drawing.Point(45, 509);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(13, 13);
            this.label_d.TabIndex = 56;
            this.label_d.Text = "0";
            // 
            // label_c
            // 
            this.label_c.AutoSize = true;
            this.label_c.Location = new System.Drawing.Point(45, 496);
            this.label_c.Name = "label_c";
            this.label_c.Size = new System.Drawing.Size(13, 13);
            this.label_c.TabIndex = 55;
            this.label_c.Text = "0";
            // 
            // label_b
            // 
            this.label_b.AutoSize = true;
            this.label_b.Location = new System.Drawing.Point(45, 483);
            this.label_b.Name = "label_b";
            this.label_b.Size = new System.Drawing.Size(13, 13);
            this.label_b.TabIndex = 54;
            this.label_b.Text = "0";
            // 
            // label_a
            // 
            this.label_a.AutoSize = true;
            this.label_a.Location = new System.Drawing.Point(45, 470);
            this.label_a.Name = "label_a";
            this.label_a.Size = new System.Drawing.Size(13, 13);
            this.label_a.TabIndex = 53;
            this.label_a.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 535);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "f";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 522);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "e";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 509);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 50;
            this.label15.Text = "d";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 496);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "c";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 483);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "b";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "a";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 464);
            this.tabControl1.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_initial_prey);
            this.tabPage1.Controls.Add(this.textBox_initial_prey);
            this.tabPage1.Controls.Add(this.textBox_Add_prey);
            this.tabPage1.Controls.Add(this.label_lx);
            this.tabPage1.Controls.Add(this.textBox_Lx);
            this.tabPage1.Controls.Add(this.button_add_animals);
            this.tabPage1.Controls.Add(this.label_initial_pred);
            this.tabPage1.Controls.Add(this.textBox_initial_predator);
            this.tabPage1.Controls.Add(this.textBox_Add_pred);
            this.tabPage1.Controls.Add(this.label_Ly);
            this.tabPage1.Controls.Add(this.textBox_Ly);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(235, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Init";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_initial_prey
            // 
            this.label_initial_prey.AutoSize = true;
            this.label_initial_prey.Location = new System.Drawing.Point(51, 15);
            this.label_initial_prey.Name = "label_initial_prey";
            this.label_initial_prey.Size = new System.Drawing.Size(45, 13);
            this.label_initial_prey.TabIndex = 5;
            this.label_initial_prey.Text = "Init Prey";
            // 
            // textBox_initial_prey
            // 
            this.textBox_initial_prey.Location = new System.Drawing.Point(54, 31);
            this.textBox_initial_prey.Name = "textBox_initial_prey";
            this.textBox_initial_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_initial_prey.TabIndex = 0;
            this.textBox_initial_prey.Text = "1000";
            this.textBox_initial_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_initial_prey.TextChanged += new System.EventHandler(this.textBox_initial_prey_TextChanged);
            // 
            // textBox_Add_prey
            // 
            this.textBox_Add_prey.Location = new System.Drawing.Point(55, 57);
            this.textBox_Add_prey.Name = "textBox_Add_prey";
            this.textBox_Add_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_Add_prey.TabIndex = 8;
            this.textBox_Add_prey.Text = "1000";
            this.textBox_Add_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_lx
            // 
            this.label_lx.AutoSize = true;
            this.label_lx.Location = new System.Drawing.Point(33, 86);
            this.label_lx.Name = "label_lx";
            this.label_lx.Size = new System.Drawing.Size(18, 13);
            this.label_lx.TabIndex = 18;
            this.label_lx.Text = "Lx";
            // 
            // textBox_Lx
            // 
            this.textBox_Lx.Location = new System.Drawing.Point(54, 83);
            this.textBox_Lx.Name = "textBox_Lx";
            this.textBox_Lx.Size = new System.Drawing.Size(42, 20);
            this.textBox_Lx.TabIndex = 19;
            this.textBox_Lx.Text = "100";
            this.textBox_Lx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_add_animals
            // 
            this.button_add_animals.Location = new System.Drawing.Point(103, 56);
            this.button_add_animals.Name = "button_add_animals";
            this.button_add_animals.Size = new System.Drawing.Size(36, 20);
            this.button_add_animals.TabIndex = 10;
            this.button_add_animals.Text = "Add";
            this.button_add_animals.UseVisualStyleBackColor = true;
            this.button_add_animals.Click += new System.EventHandler(this.button_add_animals_Click);
            // 
            // label_initial_pred
            // 
            this.label_initial_pred.AutoSize = true;
            this.label_initial_pred.Location = new System.Drawing.Point(135, 10);
            this.label_initial_pred.Name = "label_initial_pred";
            this.label_initial_pred.Size = new System.Drawing.Size(66, 17);
            this.label_initial_pred.TabIndex = 6;
            this.label_initial_pred.Text = "Init Predator";
            this.label_initial_pred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_initial_pred.UseCompatibleTextRendering = true;
            // 
            // textBox_initial_predator
            // 
            this.textBox_initial_predator.Location = new System.Drawing.Point(145, 30);
            this.textBox_initial_predator.Name = "textBox_initial_predator";
            this.textBox_initial_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_initial_predator.TabIndex = 7;
            this.textBox_initial_predator.Text = "100";
            this.textBox_initial_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Add_pred
            // 
            this.textBox_Add_pred.Location = new System.Drawing.Point(145, 56);
            this.textBox_Add_pred.Name = "textBox_Add_pred";
            this.textBox_Add_pred.Size = new System.Drawing.Size(42, 20);
            this.textBox_Add_pred.TabIndex = 9;
            this.textBox_Add_pred.Text = "100";
            this.textBox_Add_pred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Ly
            // 
            this.label_Ly.AutoSize = true;
            this.label_Ly.Location = new System.Drawing.Point(121, 85);
            this.label_Ly.Name = "label_Ly";
            this.label_Ly.Size = new System.Drawing.Size(18, 13);
            this.label_Ly.TabIndex = 20;
            this.label_Ly.Text = "Ly";
            // 
            // textBox_Ly
            // 
            this.textBox_Ly.Location = new System.Drawing.Point(145, 82);
            this.textBox_Ly.Name = "textBox_Ly";
            this.textBox_Ly.Size = new System.Drawing.Size(42, 20);
            this.textBox_Ly.TabIndex = 21;
            this.textBox_Ly.Text = "100";
            this.textBox_Ly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_prey_competiton_strength);
            this.tabPage2.Controls.Add(this.textBox_Prey_competition_strength);
            this.tabPage2.Controls.Add(this.textBox_hunting_fertility);
            this.tabPage2.Controls.Add(this.checkBox_Predator_Competition);
            this.tabPage2.Controls.Add(this.textBox_prey_competition_area);
            this.tabPage2.Controls.Add(this.checkBox_Prey_Competition);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textBox_predator_competition_area);
            this.tabPage2.Controls.Add(this.label_predator_competition_strength);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_fertility_predator);
            this.tabPage2.Controls.Add(this.textBox_hunting_surface);
            this.tabPage2.Controls.Add(this.textBox_fertility_prey);
            this.tabPage2.Controls.Add(this.textBox_deathrate_prey);
            this.tabPage2.Controls.Add(this.label_prey_competition_area);
            this.tabPage2.Controls.Add(this.textBox_deathrate_predator);
            this.tabPage2.Controls.Add(this.label_hunting_surface);
            this.tabPage2.Controls.Add(this.textBox_predator_competition_strength);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label_predator_competition_area);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(235, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LV param";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_prey_competiton_strength
            // 
            this.label_prey_competiton_strength.AutoSize = true;
            this.label_prey_competiton_strength.Location = new System.Drawing.Point(87, 189);
            this.label_prey_competiton_strength.Name = "label_prey_competiton_strength";
            this.label_prey_competiton_strength.Size = new System.Drawing.Size(145, 13);
            this.label_prey_competiton_strength.TabIndex = 47;
            this.label_prey_competiton_strength.Text = "Predator competition strength";
            this.label_prey_competiton_strength.Visible = false;
            // 
            // textBox_Prey_competition_strength
            // 
            this.textBox_Prey_competition_strength.Location = new System.Drawing.Point(159, 166);
            this.textBox_Prey_competition_strength.Name = "textBox_Prey_competition_strength";
            this.textBox_Prey_competition_strength.Size = new System.Drawing.Size(53, 20);
            this.textBox_Prey_competition_strength.TabIndex = 46;
            this.textBox_Prey_competition_strength.Text = "0.1";
            this.textBox_Prey_competition_strength.Visible = false;
            // 
            // textBox_hunting_fertility
            // 
            this.textBox_hunting_fertility.Location = new System.Drawing.Point(147, 325);
            this.textBox_hunting_fertility.Name = "textBox_hunting_fertility";
            this.textBox_hunting_fertility.Size = new System.Drawing.Size(37, 20);
            this.textBox_hunting_fertility.TabIndex = 45;
            this.textBox_hunting_fertility.Text = "0.1";
            this.textBox_hunting_fertility.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_Predator_Competition
            // 
            this.checkBox_Predator_Competition.AutoSize = true;
            this.checkBox_Predator_Competition.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox_Predator_Competition.Location = new System.Drawing.Point(11, 207);
            this.checkBox_Predator_Competition.Name = "checkBox_Predator_Competition";
            this.checkBox_Predator_Competition.Size = new System.Drawing.Size(91, 31);
            this.checkBox_Predator_Competition.TabIndex = 37;
            this.checkBox_Predator_Competition.Text = "Pred Competition";
            this.checkBox_Predator_Competition.UseVisualStyleBackColor = true;
            this.checkBox_Predator_Competition.CheckedChanged += new System.EventHandler(this.checkBox_Predator_Competition_CheckedChanged);
            // 
            // textBox_prey_competition_area
            // 
            this.textBox_prey_competition_area.Location = new System.Drawing.Point(159, 122);
            this.textBox_prey_competition_area.Name = "textBox_prey_competition_area";
            this.textBox_prey_competition_area.Size = new System.Drawing.Size(53, 20);
            this.textBox_prey_competition_area.TabIndex = 38;
            this.textBox_prey_competition_area.Text = "0.01";
            this.textBox_prey_competition_area.Visible = false;
            // 
            // checkBox_Prey_Competition
            // 
            this.checkBox_Prey_Competition.AutoSize = true;
            this.checkBox_Prey_Competition.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox_Prey_Competition.Location = new System.Drawing.Point(11, 128);
            this.checkBox_Prey_Competition.Name = "checkBox_Prey_Competition";
            this.checkBox_Prey_Competition.Size = new System.Drawing.Size(90, 31);
            this.checkBox_Prey_Competition.TabIndex = 36;
            this.checkBox_Prey_Competition.Text = "Prey Competition";
            this.checkBox_Prey_Competition.UseVisualStyleBackColor = true;
            this.checkBox_Prey_Competition.CheckedChanged += new System.EventHandler(this.checkBox_Prey_Competition_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Hunting fertility";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Predator";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "fertility";
            // 
            // textBox_predator_competition_area
            // 
            this.textBox_predator_competition_area.Location = new System.Drawing.Point(158, 205);
            this.textBox_predator_competition_area.Name = "textBox_predator_competition_area";
            this.textBox_predator_competition_area.Size = new System.Drawing.Size(53, 20);
            this.textBox_predator_competition_area.TabIndex = 40;
            this.textBox_predator_competition_area.Text = "0.1";
            this.textBox_predator_competition_area.Visible = false;
            // 
            // label_predator_competition_strength
            // 
            this.label_predator_competition_strength.AutoSize = true;
            this.label_predator_competition_strength.Location = new System.Drawing.Point(87, 264);
            this.label_predator_competition_strength.Name = "label_predator_competition_strength";
            this.label_predator_competition_strength.Size = new System.Drawing.Size(145, 13);
            this.label_predator_competition_strength.TabIndex = 43;
            this.label_predator_competition_strength.Text = "Predator competition strength";
            this.label_predator_competition_strength.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Prey";
            // 
            // textBox_fertility_predator
            // 
            this.textBox_fertility_predator.Location = new System.Drawing.Point(164, 89);
            this.textBox_fertility_predator.Name = "textBox_fertility_predator";
            this.textBox_fertility_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_fertility_predator.TabIndex = 33;
            this.textBox_fertility_predator.Text = "0";
            this.textBox_fertility_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_hunting_surface
            // 
            this.textBox_hunting_surface.Location = new System.Drawing.Point(147, 298);
            this.textBox_hunting_surface.Name = "textBox_hunting_surface";
            this.textBox_hunting_surface.Size = new System.Drawing.Size(37, 20);
            this.textBox_hunting_surface.TabIndex = 23;
            this.textBox_hunting_surface.Text = "0.1";
            this.textBox_hunting_surface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_fertility_prey
            // 
            this.textBox_fertility_prey.Location = new System.Drawing.Point(108, 89);
            this.textBox_fertility_prey.Name = "textBox_fertility_prey";
            this.textBox_fertility_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_fertility_prey.TabIndex = 32;
            this.textBox_fertility_prey.Text = "0.003";
            this.textBox_fertility_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_deathrate_prey
            // 
            this.textBox_deathrate_prey.Location = new System.Drawing.Point(108, 63);
            this.textBox_deathrate_prey.Name = "textBox_deathrate_prey";
            this.textBox_deathrate_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_deathrate_prey.TabIndex = 29;
            this.textBox_deathrate_prey.Text = "0.001";
            this.textBox_deathrate_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_prey_competition_area
            // 
            this.label_prey_competition_area.AutoSize = true;
            this.label_prey_competition_area.Location = new System.Drawing.Point(117, 145);
            this.label_prey_competition_area.Name = "label_prey_competition_area";
            this.label_prey_competition_area.Size = new System.Drawing.Size(109, 13);
            this.label_prey_competition_area.TabIndex = 39;
            this.label_prey_competition_area.Text = "Prey competition area";
            this.label_prey_competition_area.Visible = false;
            // 
            // textBox_deathrate_predator
            // 
            this.textBox_deathrate_predator.Location = new System.Drawing.Point(164, 63);
            this.textBox_deathrate_predator.Name = "textBox_deathrate_predator";
            this.textBox_deathrate_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_deathrate_predator.TabIndex = 30;
            this.textBox_deathrate_predator.Text = "0.003";
            this.textBox_deathrate_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_hunting_surface
            // 
            this.label_hunting_surface.AutoSize = true;
            this.label_hunting_surface.Location = new System.Drawing.Point(48, 301);
            this.label_hunting_surface.Name = "label_hunting_surface";
            this.label_hunting_surface.Size = new System.Drawing.Size(82, 13);
            this.label_hunting_surface.TabIndex = 22;
            this.label_hunting_surface.Text = "Hunting surface";
            // 
            // textBox_predator_competition_strength
            // 
            this.textBox_predator_competition_strength.Location = new System.Drawing.Point(159, 241);
            this.textBox_predator_competition_strength.Name = "textBox_predator_competition_strength";
            this.textBox_predator_competition_strength.Size = new System.Drawing.Size(53, 20);
            this.textBox_predator_competition_strength.TabIndex = 42;
            this.textBox_predator_competition_strength.Text = "0.2";
            this.textBox_predator_competition_strength.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Death Rate";
            // 
            // label_predator_competition_area
            // 
            this.label_predator_competition_area.AutoSize = true;
            this.label_predator_competition_area.Location = new System.Drawing.Point(107, 225);
            this.label_predator_competition_area.Name = "label_predator_competition_area";
            this.label_predator_competition_area.Size = new System.Drawing.Size(128, 13);
            this.label_predator_competition_area.TabIndex = 41;
            this.label_predator_competition_area.Text = "Predator competition area";
            this.label_predator_competition_area.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label_Prey_chemotaxis_area);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.textBox_Prey_chemotaxis_area);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.checkBox_Predator_chemotaxis);
            this.tabPage3.Controls.Add(this.label_speed);
            this.tabPage3.Controls.Add(this.textBox_Prey_chemotaxis_speed);
            this.tabPage3.Controls.Add(this.textBox_speed_predator);
            this.tabPage3.Controls.Add(this.checkBox_Prey_chemotaxis);
            this.tabPage3.Controls.Add(this.textBox_Predator_chemotaxis_speed);
            this.tabPage3.Controls.Add(this.textBox_speed_prey);
            this.tabPage3.Controls.Add(this.label_Predator_chemotaxis_area);
            this.tabPage3.Controls.Add(this.label_Predator_chemotaxis_speed);
            this.tabPage3.Controls.Add(this.label_Prey_chemotaxis_speed);
            this.tabPage3.Controls.Add(this.textBox_Predator_chemotaxis_area);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(235, 438);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chemotaxis";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label_Prey_chemotaxis_area
            // 
            this.label_Prey_chemotaxis_area.AutoSize = true;
            this.label_Prey_chemotaxis_area.Location = new System.Drawing.Point(116, 144);
            this.label_Prey_chemotaxis_area.Name = "label_Prey_chemotaxis_area";
            this.label_Prey_chemotaxis_area.Size = new System.Drawing.Size(108, 13);
            this.label_Prey_chemotaxis_area.TabIndex = 57;
            this.label_Prey_chemotaxis_area.Text = "Prey chemotaxis area";
            this.label_Prey_chemotaxis_area.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(164, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "Predator";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // textBox_Prey_chemotaxis_area
            // 
            this.textBox_Prey_chemotaxis_area.Location = new System.Drawing.Point(163, 121);
            this.textBox_Prey_chemotaxis_area.Name = "textBox_Prey_chemotaxis_area";
            this.textBox_Prey_chemotaxis_area.Size = new System.Drawing.Size(53, 20);
            this.textBox_Prey_chemotaxis_area.TabIndex = 56;
            this.textBox_Prey_chemotaxis_area.Text = "2";
            this.textBox_Prey_chemotaxis_area.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(122, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Prey";
            // 
            // checkBox_Predator_chemotaxis
            // 
            this.checkBox_Predator_chemotaxis.AutoSize = true;
            this.checkBox_Predator_chemotaxis.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox_Predator_chemotaxis.Location = new System.Drawing.Point(8, 178);
            this.checkBox_Predator_chemotaxis.Name = "checkBox_Predator_chemotaxis";
            this.checkBox_Predator_chemotaxis.Size = new System.Drawing.Size(90, 31);
            this.checkBox_Predator_chemotaxis.TabIndex = 49;
            this.checkBox_Predator_chemotaxis.Text = "Pred Chemotaxis";
            this.checkBox_Predator_chemotaxis.UseVisualStyleBackColor = true;
            this.checkBox_Predator_chemotaxis.CheckedChanged += new System.EventHandler(this.checkBox_Predator_chemotaxis_CheckedChanged);
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Location = new System.Drawing.Point(37, 39);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(38, 13);
            this.label_speed.TabIndex = 28;
            this.label_speed.Text = "Speed";
            // 
            // textBox_Prey_chemotaxis_speed
            // 
            this.textBox_Prey_chemotaxis_speed.Location = new System.Drawing.Point(163, 77);
            this.textBox_Prey_chemotaxis_speed.Name = "textBox_Prey_chemotaxis_speed";
            this.textBox_Prey_chemotaxis_speed.Size = new System.Drawing.Size(53, 20);
            this.textBox_Prey_chemotaxis_speed.TabIndex = 50;
            this.textBox_Prey_chemotaxis_speed.Text = "1";
            this.textBox_Prey_chemotaxis_speed.Visible = false;
            // 
            // textBox_speed_predator
            // 
            this.textBox_speed_predator.Location = new System.Drawing.Point(170, 36);
            this.textBox_speed_predator.Name = "textBox_speed_predator";
            this.textBox_speed_predator.Size = new System.Drawing.Size(42, 20);
            this.textBox_speed_predator.TabIndex = 27;
            this.textBox_speed_predator.Text = "1";
            this.textBox_speed_predator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_Prey_chemotaxis
            // 
            this.checkBox_Prey_chemotaxis.AutoSize = true;
            this.checkBox_Prey_chemotaxis.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox_Prey_chemotaxis.Location = new System.Drawing.Point(9, 83);
            this.checkBox_Prey_chemotaxis.Name = "checkBox_Prey_chemotaxis";
            this.checkBox_Prey_chemotaxis.Size = new System.Drawing.Size(89, 31);
            this.checkBox_Prey_chemotaxis.TabIndex = 48;
            this.checkBox_Prey_chemotaxis.Text = "Prey Chemotaxis";
            this.checkBox_Prey_chemotaxis.UseVisualStyleBackColor = true;
            this.checkBox_Prey_chemotaxis.CheckedChanged += new System.EventHandler(this.checkBox_Prey_chemotaxis_CheckedChanged);
            // 
            // textBox_Predator_chemotaxis_speed
            // 
            this.textBox_Predator_chemotaxis_speed.Location = new System.Drawing.Point(162, 176);
            this.textBox_Predator_chemotaxis_speed.Name = "textBox_Predator_chemotaxis_speed";
            this.textBox_Predator_chemotaxis_speed.Size = new System.Drawing.Size(53, 20);
            this.textBox_Predator_chemotaxis_speed.TabIndex = 52;
            this.textBox_Predator_chemotaxis_speed.Text = "1";
            this.textBox_Predator_chemotaxis_speed.Visible = false;
            // 
            // textBox_speed_prey
            // 
            this.textBox_speed_prey.Location = new System.Drawing.Point(114, 36);
            this.textBox_speed_prey.Name = "textBox_speed_prey";
            this.textBox_speed_prey.Size = new System.Drawing.Size(42, 20);
            this.textBox_speed_prey.TabIndex = 24;
            this.textBox_speed_prey.Text = "1";
            this.textBox_speed_prey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Predator_chemotaxis_area
            // 
            this.label_Predator_chemotaxis_area.AutoSize = true;
            this.label_Predator_chemotaxis_area.Location = new System.Drawing.Point(103, 235);
            this.label_Predator_chemotaxis_area.Name = "label_Predator_chemotaxis_area";
            this.label_Predator_chemotaxis_area.Size = new System.Drawing.Size(127, 13);
            this.label_Predator_chemotaxis_area.TabIndex = 55;
            this.label_Predator_chemotaxis_area.Text = "Predator chemotaxis area";
            this.label_Predator_chemotaxis_area.Visible = false;
            // 
            // label_Predator_chemotaxis_speed
            // 
            this.label_Predator_chemotaxis_speed.AutoSize = true;
            this.label_Predator_chemotaxis_speed.Location = new System.Drawing.Point(100, 196);
            this.label_Predator_chemotaxis_speed.Name = "label_Predator_chemotaxis_speed";
            this.label_Predator_chemotaxis_speed.Size = new System.Drawing.Size(135, 13);
            this.label_Predator_chemotaxis_speed.TabIndex = 53;
            this.label_Predator_chemotaxis_speed.Text = "Predator chemotaxis speed";
            this.label_Predator_chemotaxis_speed.Visible = false;
            // 
            // label_Prey_chemotaxis_speed
            // 
            this.label_Prey_chemotaxis_speed.AutoSize = true;
            this.label_Prey_chemotaxis_speed.Location = new System.Drawing.Point(111, 100);
            this.label_Prey_chemotaxis_speed.Name = "label_Prey_chemotaxis_speed";
            this.label_Prey_chemotaxis_speed.Size = new System.Drawing.Size(116, 13);
            this.label_Prey_chemotaxis_speed.TabIndex = 51;
            this.label_Prey_chemotaxis_speed.Text = "Prey chemotaxis speed";
            this.label_Prey_chemotaxis_speed.Visible = false;
            // 
            // textBox_Predator_chemotaxis_area
            // 
            this.textBox_Predator_chemotaxis_area.Location = new System.Drawing.Point(163, 212);
            this.textBox_Predator_chemotaxis_area.Name = "textBox_Predator_chemotaxis_area";
            this.textBox_Predator_chemotaxis_area.Size = new System.Drawing.Size(53, 20);
            this.textBox_Predator_chemotaxis_area.TabIndex = 54;
            this.textBox_Predator_chemotaxis_area.Text = "2";
            this.textBox_Predator_chemotaxis_area.Visible = false;
            // 
            // Stop_button
            // 
            this.Stop_button.BackColor = System.Drawing.Color.Red;
            this.Stop_button.FlatAppearance.BorderSize = 3;
            this.Stop_button.Location = new System.Drawing.Point(56, 646);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(151, 51);
            this.Stop_button.TabIndex = 35;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = false;
            this.Stop_button.Visible = false;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // button_modify_parameters
            // 
            this.button_modify_parameters.BackColor = System.Drawing.SystemColors.Info;
            this.button_modify_parameters.Location = new System.Drawing.Point(80, 593);
            this.button_modify_parameters.Name = "button_modify_parameters";
            this.button_modify_parameters.Size = new System.Drawing.Size(118, 47);
            this.button_modify_parameters.TabIndex = 17;
            this.button_modify_parameters.Text = "Modify Parameters";
            this.button_modify_parameters.UseVisualStyleBackColor = false;
            this.button_modify_parameters.Click += new System.EventHandler(this.button_modify_parameters_Click);
            // 
            // textBox_time_step
            // 
            this.textBox_time_step.Location = new System.Drawing.Point(437, 67);
            this.textBox_time_step.Name = "textBox_time_step";
            this.textBox_time_step.Size = new System.Drawing.Size(37, 20);
            this.textBox_time_step.TabIndex = 14;
            this.textBox_time_step.Text = "0.1";
            this.textBox_time_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_time_step
            // 
            this.label_time_step.AutoSize = true;
            this.label_time_step.Location = new System.Drawing.Point(354, 70);
            this.label_time_step.Name = "label_time_step";
            this.label_time_step.Size = new System.Drawing.Size(53, 13);
            this.label_time_step.TabIndex = 13;
            this.label_time_step.Text = "Time step";
            // 
            // textBox_simulation_delay
            // 
            this.textBox_simulation_delay.Location = new System.Drawing.Point(623, 67);
            this.textBox_simulation_delay.Name = "textBox_simulation_delay";
            this.textBox_simulation_delay.Size = new System.Drawing.Size(37, 20);
            this.textBox_simulation_delay.TabIndex = 12;
            this.textBox_simulation_delay.Text = "0";
            this.textBox_simulation_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_simulation_delay
            // 
            this.label_simulation_delay.AutoSize = true;
            this.label_simulation_delay.Location = new System.Drawing.Point(524, 70);
            this.label_simulation_delay.Name = "label_simulation_delay";
            this.label_simulation_delay.Size = new System.Drawing.Size(85, 13);
            this.label_simulation_delay.TabIndex = 11;
            this.label_simulation_delay.Text = "Simulation Delay";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_spatial_graph);
            this.panel2.Controls.Add(this.Button_Graph_Biomass);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.nb_preds);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label_nb_preys);
            this.panel2.Controls.Add(this.label_simulation_delay);
            this.panel2.Controls.Add(this.textBox_simulation_delay);
            this.panel2.Controls.Add(this.label_time_step);
            this.panel2.Controls.Add(this.textBox_time_step);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 103);
            this.panel2.TabIndex = 11;
            // 
            // button_spatial_graph
            // 
            this.button_spatial_graph.Location = new System.Drawing.Point(199, 47);
            this.button_spatial_graph.Name = "button_spatial_graph";
            this.button_spatial_graph.Size = new System.Drawing.Size(150, 23);
            this.button_spatial_graph.TabIndex = 15;
            this.button_spatial_graph.Text = "Spatial_Graph";
            this.button_spatial_graph.UseVisualStyleBackColor = true;
            this.button_spatial_graph.Click += new System.EventHandler(this.button_spatial_graph_Click);
            // 
            // Button_Graph_Biomass
            // 
            this.Button_Graph_Biomass.Location = new System.Drawing.Point(199, 11);
            this.Button_Graph_Biomass.Name = "Button_Graph_Biomass";
            this.Button_Graph_Biomass.Size = new System.Drawing.Size(150, 23);
            this.Button_Graph_Biomass.TabIndex = 13;
            this.Button_Graph_Biomass.Text = "Biomass Graph";
            this.Button_Graph_Biomass.UseVisualStyleBackColor = true;
            this.Button_Graph_Biomass.Click += new System.EventHandler(this.Button_Graph_Biomass_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Simulation_number,
            this.progress,
            this.button_spatial,
            this.button_biomass_graph});
            this.dataGridView1.Location = new System.Drawing.Point(274, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 150);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Simulation_number
            // 
            this.Simulation_number.HeaderText = "Simulation number";
            this.Simulation_number.Name = "Simulation_number";
            // 
            // progress
            // 
            this.progress.HeaderText = "Progress";
            this.progress.Name = "progress";
            // 
            // button_spatial
            // 
            this.button_spatial.HeaderText = "Spatial Graph";
            this.button_spatial.Name = "button_spatial";
            // 
            // button_biomass_graph
            // 
            this.button_biomass_graph.HeaderText = "Biomass Graph";
            this.button_biomass_graph.Name = "button_biomass_graph";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(333, 729);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(539, 20);
            this.textBox_path.TabIndex = 13;
            this.textBox_path.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_change_directory
            // 
            this.button_change_directory.Location = new System.Drawing.Point(873, 727);
            this.button_change_directory.Name = "button_change_directory";
            this.button_change_directory.Size = new System.Drawing.Size(113, 23);
            this.button_change_directory.TabIndex = 14;
            this.button_change_directory.Text = "Change directory";
            this.button_change_directory.UseVisualStyleBackColor = true;
            this.button_change_directory.Click += new System.EventHandler(this.button_change_directory_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1244, 761);
            this.Controls.Add(this.button_change_directory);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(600, 800);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Run_button;
        private System.Windows.Forms.Button Pause_button;
        private System.Windows.Forms.Timer timer_graph_update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_nb_preys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nb_preds;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_initial_prey;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_initial_prey;
        private System.Windows.Forms.Button button_add_animals;
        private System.Windows.Forms.TextBox textBox_Add_pred;
        private System.Windows.Forms.TextBox textBox_Add_prey;
        private System.Windows.Forms.TextBox textBox_initial_predator;
        private System.Windows.Forms.Label label_initial_pred;
        private System.Windows.Forms.Button button_modify_parameters;
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
        private System.Windows.Forms.Button Button_Graph_Biomass;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.CheckBox checkBox_Predator_Competition;
        private System.Windows.Forms.CheckBox checkBox_Prey_Competition;
        private System.Windows.Forms.Label label_predator_competition_area;
        private System.Windows.Forms.TextBox textBox_predator_competition_area;
        private System.Windows.Forms.Label label_prey_competition_area;
        private System.Windows.Forms.TextBox textBox_prey_competition_area;
        private System.Windows.Forms.Label label_predator_competition_strength;
        private System.Windows.Forms.TextBox textBox_predator_competition_strength;
        private System.Windows.Forms.TextBox textBox_hunting_fertility;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox_Prey_competition_strength;
        private System.Windows.Forms.Label label_prey_competiton_strength;
        private System.Windows.Forms.Label label_Prey_chemotaxis_area;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Prey_chemotaxis_area;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox_Predator_chemotaxis;
        private System.Windows.Forms.TextBox textBox_Prey_chemotaxis_speed;
        private System.Windows.Forms.CheckBox checkBox_Prey_chemotaxis;
        private System.Windows.Forms.TextBox textBox_Predator_chemotaxis_speed;
        private System.Windows.Forms.Label label_Predator_chemotaxis_area;
        private System.Windows.Forms.Label label_Predator_chemotaxis_speed;
        private System.Windows.Forms.Label label_Prey_chemotaxis_speed;
        private System.Windows.Forms.TextBox textBox_Predator_chemotaxis_area;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label_predator_eq;
        private System.Windows.Forms.Label label_prey_eq;
        private System.Windows.Forms.Label label_f;
        private System.Windows.Forms.Label label_e;
        private System.Windows.Forms.Label label_d;
        private System.Windows.Forms.Label label_c;
        private System.Windows.Forms.Label label_b;
        private System.Windows.Forms.Label label_a;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_ratio;
        private System.Windows.Forms.Label label20;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button_spatial_graph;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simulation_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn progress;
        private System.Windows.Forms.DataGridViewButtonColumn button_spatial;
        private System.Windows.Forms.DataGridViewButtonColumn button_biomass_graph;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_change_directory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}