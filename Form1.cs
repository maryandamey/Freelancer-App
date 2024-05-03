using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelancerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 15;
            timer1.Start();

            if (panel2.Width >=  453) { 
            timer1.Stop();
                Login frm2 = new Login();
                frm2.Show();
                this.Hide();
                            
            }
        }
    }
}
