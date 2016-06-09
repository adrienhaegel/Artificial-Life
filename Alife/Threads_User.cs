using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alife
{
    public partial class Threads_User : Form
    {
        public Threads_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Simulation_Planner simform = new Simulation_Planner((int)numericUpDown_threads.Value);
            simform.FormClosed += (s, args) => this.Close();
            simform.Show();

        }
    }
}
