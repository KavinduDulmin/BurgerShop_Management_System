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
using DGVPrinterHelper;

namespace burgerShopManagementSystem
{
    public partial class Form4 : Form
    {
        int index;

        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataAdapter dr;
        SqlDataReader read;
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_NewBurgerShop_DataSet12.SaledTbl' table. You can move, or remove it, as needed.
           // this.saledTblTableAdapter3.Fill(this._NewBurgerShop_DataSet12.SaledTbl);

       //     this.productTblTableAdapter.Fill(this._productdata_DataSet7.ProductTbl);

        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
           //
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataGridViewRow newData = dataGridView6.Rows[index];

            //newData.Cells[2].Value = txtCBName.Text;
            //newData.Cells[3].Value = txtCBPrice.Text;
            //newData.Cells[4].Value = txtCBQun.Text;




            con = ConnectionManager.GetConnection();
            con.Open();
            string query1 = "Delete from SaledTbl where billNumber='" + dataGridView5.SelectedRows[0].Cells[1].Value.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView6.Rows[index];
         
            txtCBName.Text = row.Cells[1].Value.ToString();
            txtCBPrice.Text = row.Cells[2].Value.ToString();
           
        }
        int qunt = 0;
        double price1;
        double total1 = 0;
        //int y = 0;
        //double Btotal1;
        int z = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            if ( Dtp1.Text==""||txtCBNumber.Text == "" || txtCBName.Text == "" || txtCBPrice.Text == "" || txtCBQun.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                qunt = Convert.ToInt32(txtCBQun.Text);
                price1 = Convert.ToDouble(txtCBPrice.Text);
                 total1 = qunt * price1;
                

               // try
              //  {
                    con.Open();
                    string Query = "insert into SaledTbl values ('"+Dtp1.Value.ToString("yyyy-MM-dd")+"','" + txtCBNumber.Text + "','" + txtCBName.Text + "','" + txtCBPrice.Text + "','" + txtCBQun.Text + "','"+txtTprice.Text+"')";
                    SqlCommand cmd = new SqlCommand(Query, con);



                    MessageBox.Show("product Add to cart");
                    cmd.ExecuteNonQuery();


                    con.Close();

               // }
               // catch (Exception ex)
              //  {
              //      MessageBox.Show(ex.ToString());
              //  }
            }
            dataGridView5.Rows.Add(Dtp1.Value.ToString("yyyy-MM-dd"), txtCBNumber.Text, txtCBName.Text, txtCBPrice.Text, txtCBQun.Text,total1);

        }



        private void DisplayEliment3(string TName)
        {
            con.Open();
            string Query = "insert into SaledTbl valus ('" + txtCBNumber.Text + "','" + txtCBName.Text + "','" + txtCBPrice.Text + "','" + txtCBQun.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();


            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete from SaledTbl where billNumber='" + dataGridView5.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView5.Rows.RemoveAt(dataGridView5.SelectedRows[0].Index);
                con.Close();
                MessageBox.Show("deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBillPrint_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

           //

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x;
            double totle = 0;

            for (x = 0; x <= dataGridView5.Rows.Count-1; x++)
            {
                totle = totle + Convert.ToInt32(dataGridView5.Rows[x].Cells[5].Value.ToString());
            }
             txtTprice.Text = totle.ToString();
            // MessageBox.Show(totle.ToString());
            dataGridView5.Rows.Clear();

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmLogin Form1 = new frmLogin();
            Form1.Show();
            this.Close();
        }

        private void btnTotalPrice_Click(object sender, EventArgs e)
        {
            int x;
            double totle = 0;
            //  double total1;
            int z = 0;
            for (x = 0; x <= dataGridView5.Rows.Count - 1; x++)
            {
                totle = totle - z% + Convert.ToInt32(dataGridView5.Rows[x].Cells[5].Value.ToString());
            }
            txtTotalPrice.Text = totle.ToString();
            // MessageBox.Show(totle.ToString());
            dataGridView5.Rows.Clear();
        }
    }
   
}