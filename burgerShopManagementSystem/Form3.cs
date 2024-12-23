using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace burgerShopManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True;Pooling=False");
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            string admin, casher;
            try
            {
                admin = radioButton1.Text;
                casher = radioButton2.Text;
              

                if (radioButton1.Checked)
                {
                    string query1 = ("Select count(*) from staff where UName='" + txtUserName.Text + "'and pw ='" + txtPww.Text + "'");
                    SqlDataAdapter sad = new SqlDataAdapter(query1, con);
                    DataTable Dtb1 = new DataTable();
                    sad.Fill(Dtb1);

                    if (Dtb1.Rows[0][0].ToString() == "1")
                    {
                        
                        Form1 Form1 = new Form1();
                        Form1.Show();
                        this.Close();
                    }
                    if (txtPww.Text == "" && txtUserName.Text == "")
                    {
                        MessageBox.Show("Your Welcome ");
                    }
                    else if (txtUserName.Text == "")
                    {
                        MessageBox.Show("Please enter your valid UserName...");
                    }
                    else if (txtPww.Text == "")
                    {
                        MessageBox.Show("Please enter your valid Password...");
                    }
                    else if (Dtb1.Rows[0][0].ToString() != "1")
                    {
                        MessageBox.Show("Please enter your valid UserName & Password...");
                    }
                }

                else if (radioButton2.Checked)
                {
                    string query2 = ("Select count(*) from staff where UName='" + txtUserName.Text + "'and pw ='" + txtPww.Text + "'");
                    SqlDataAdapter sad = new SqlDataAdapter(query2, con);
                    DataTable Dtb1 = new DataTable();
                    sad.Fill(Dtb1);

                    if (Dtb1.Rows[0][0].ToString() == "1")
                    {
                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Close();
                    }
                    if (txtPww.Text == "" && txtUserName.Text == "")
                    {
                        MessageBox.Show("Your Welcome!!!");
                    }
                    else if (txtUserName.Text == "")
                    {
                        MessageBox.Show("Please enter your valid UserName...");
                    }
                    else if (txtPww.Text == "")
                    {
                        MessageBox.Show("Please enter your valid Password...");
                    }
                    else if (Dtb1.Rows[0][0].ToString() != "1")
                    {
                        MessageBox.Show("Plase input the correct employee type....");
                    }
                }
                else
                {
                    MessageBox.Show("Plase input the correct employee type.");
                }

                txtUserName.Text = "";
                txtPww.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
