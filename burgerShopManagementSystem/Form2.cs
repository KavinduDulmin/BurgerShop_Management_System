using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burgerShopManagementSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int startpoint = 2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint  += 2;
            myprocess.Value = startpoint;
            if (myprocess.Value == 100) 
            {
                myprocess.Value = 2;
                timer1.Enabled=false;
                frmLogin login = new frmLogin();
                this.Hide();
                login.Show();

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
    }
}
