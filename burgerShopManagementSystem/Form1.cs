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
    public partial class Form1 : Form
    {
        int index;
        public Form1()
        {
            InitializeComponent();
            DisplayEliment("productNameTb");
        }

        SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter dr;
        SqlDataReader read;
        ConnectionManager objcon = new ConnectionManager();

       // dashboard button click(line 31-56 )
        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabproduct);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabStaff);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCat);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabBill);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabDash);
            //Form4 form = new Form4();

            //this.Hide();
            //form.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
       // category management
        private void btnEdit_Click(object sender, EventArgs e)
        {



            if (TxtCatgy.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into CatTb values ('" + TxtCatgy.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);



                    MessageBox.Show("Category Add");
                    cmd.ExecuteNonQuery();
                   

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        //product management edit button.
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newData = dataGridView4.Rows[index];
            newData.Cells[0].Value = txtid.Text;
            newData.Cells[1].Value = txtname.Text;
            newData.Cells[2].Value = txtprice.Text;
            newData.Cells[3].Value = cmbcat.Text;
            newData.Cells[4].Value = txtqt.Text;

            string name = "";
            double price = 0;
            int qnt = 0;
            int number = 0;


            number = Convert.ToInt32(txtid.Text);
            name = txtname.Text;
            price = Convert.ToDouble(txtprice.Text);
            qnt = Convert.ToInt32(txtqt.Text);

            con = ConnectionManager.GetConnection();
            con.Open();
            string query1 = "update productTbl set productName='" + txtname.Text + "', productPrice='" + txtprice.Text + "',productQty='" + txtqt.Text + "',productCat='" + cmbcat.Text + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.ExecuteNonQuery();
            con.Close();


        }
        //product display
        private void DisplayEliment(string TName)
        {
         //   con.Open();
            string Query = "insert into ProductTbl valus('" + txtname.Text + "','" + txtprice.Text + "','" + txtqt.Text + "','" + cmbcat.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            //sda.Fill(ds);
            //dataGridView4.DataSource = ds.Tables[0];


         //   con.Close();

        }
        //product management add button.
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtqt.Text == "" || txtprice.Text == "" || cmbcat.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into ProductTbl values ('" + txtid.Text + "','" + txtname.Text + "','" + txtprice.Text + "','" + txtqt.Text + "','" + cmbcat.SelectedIndex.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, con);



                    MessageBox.Show("product Add");
                    cmd.ExecuteNonQuery();


                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            this.productTblTableAdapter1.Fill(this._NewBurgerShop_DataSet1.ProductTbl);


        }
        int key = 0;
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataStaff.Staff' table. You can move, or remove it, as needed.
         //   this.staffTableAdapter3.Fill(this.dataStaff.Staff);
            // TODO: This line of code loads data into the '_NewBurgerShop_DataSet6.Staff' table. You can move, or remove it, as needed.
            //this.staffTableAdapter2.Fill(this._NewBurgerShop_DataSet6.Staff);
            //// TODO: This line of code loads data into the '_NewBurgerShop_DataSet5.Staff' table. You can move, or remove it, as needed.
            //  this.staffTableAdapter1.Fill(this._NewBurgerShop_DataSet5.Staff);
            // TODO: This line of code loads data into the '_NewBurgerShop_DataSet4.CatTb' table. You can move, or remove it, as needed.
            //  this.catTbTableAdapter.Fill(this._NewBurgerShop_DataSet4.CatTb);


        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True;Pooling=False");
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete from ProductTbl where productId='" + dataGridView4.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                con.Close();
                MessageBox.Show("deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //staff registration add members
        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            if (txtUId.Text == "" || txtFName.Text == "" || txtLName.Text == "" || txtCNumber.Text == "" || txtDoB.Text == "" || cmbJobTitle.SelectedIndex == -1 || txtAddress.Text == "" || txtSUName.Text == "" || txtSpw.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "insert into Staff values ('" + txtUId.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + txtCNumber.Text + "','" + txtDoB.Text + "','" + cmbJobTitle.Text + "','" + txtAddress.Text + "','" + txtSUName.Text + "','" + txtSpw.Text + "')";

                    SqlCommand cmd = new SqlCommand(Query, con);

                    MessageBox.Show("Add member");
                    cmd.ExecuteNonQuery();
                    DisplayEliment1("Staff");

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //    this.staffTableAdapter.Fill(this._NewBurgerShop_DataSet3.Staff);

        }
        private void DisplayEliment1(string TName)
        {
            con.Open();
            string Query = "insert into Staff valus ('" + txtUId.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + txtCNumber.Text + "','" + txtDoB.Text + "','" + cmbJobTitle.Text + "','" + txtAddress.Text + "''" + txtSUName.Text + "','" + txtSpw.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();



            //sda.Fill(ds);
            //dataGridView4.DataSource = ds.Tables[0];


            con.Close();
        }
        //staff registration delete members
        private void btnDeleteMembers_Click(object sender, EventArgs e)

        {
            try
            {


                SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True;Pooling=False");
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete from Staff where FirstName ='" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                con.Close();

                MessageBox.Show("deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //staff edit members
        private void btnEditMembers_Click(object sender, EventArgs e)
        {
            DataGridViewRow newData = dataGridView2.Rows[index];
            newData.Cells[0].Value = txtUId.Text;
            newData.Cells[1].Value = txtFName.Text;
            newData.Cells[2].Value = txtLName.Text;
            newData.Cells[3].Value = txtCNumber.Text;
            newData.Cells[4].Value = txtDoB.Text;
            newData.Cells[5].Value = cmbJobTitle.Text;
            newData.Cells[6].Value = txtAddress.Text;
            newData.Cells[7].Value = txtSUName.Text;
            newData.Cells[8].Value = txtSpw.Text;



            con = ConnectionManager.GetConnection();
            con.Open();
            string query1 = "update Staff set FirstName='" + txtFName.Text + "',LastName='" + txtLName.Text + "',CNumber='" + txtCNumber.Text + "',dateOfBirth='" + txtDoB.Text + "',job='" + cmbJobTitle.Text + "',Address='" + txtAddress.Text + "',UName='" + txtSUName.Text + "',pw='" + txtSpw.Text + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=NewBurgerShop.;Integrated Security=True;Pooling=False");
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete from CatTb where CatName ='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                con.Close();

                MessageBox.Show("deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void DisplayEliment2(string TName)
        {
            con.Open();
            string Query = "insert into CatTb valus ('" + TxtCatgy.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();


            con.Close();


        }
        //catrgory edit button 
        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow newData = dataGridView1.Rows[index];
            newData.Cells[0].Value = txtid.Text;




            con = ConnectionManager.GetConnection();
            con.Open();
            string query1 = "update CatTb set CatName= '" + TxtCatgy.Text + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);

            cmd1.ExecuteNonQuery();
            con.Close();




        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
        //Refresh Buttons....
        private void button10_Click(object sender, EventArgs e)
        {
            string sqlstm = "select* from ProductTbl";
            SqlDataAdapter SAD = new SqlDataAdapter(sqlstm, con);
            DataSet ds = new System.Data.DataSet();
            SAD.Fill(ds, "ProductTbl");
            dataGridView4.DataSource = ds.Tables[0];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sqlstm = "select* from Staff";
            SqlDataAdapter SAD = new SqlDataAdapter(sqlstm, con);
            DataSet ds = new System.Data.DataSet();
            SAD.Fill(ds, "Staff");
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sqlstm = "select* from CatTb";
            SqlDataAdapter SAD = new SqlDataAdapter(sqlstm, con);
            DataSet ds = new System.Data.DataSet();
            SAD.Fill(ds, "CatTb");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnBillRefresh_Click(object sender, EventArgs e)
        {
            string sqlstm = "select* from ProductTbl";

            SqlDataAdapter SAD = new SqlDataAdapter(sqlstm, con);

            DataSet ds = new System.Data.DataSet();
            SAD.Fill(ds, "ProductTbl");

            dataGridView6.DataSource = ds.Tables[0];

        }
        //logout
        private void button7_Click(object sender, EventArgs e)
        {
            frmLogin Form1 = new frmLogin();
            Form1.Show();
            this.Close();

        }

        private void tabBill_Click(object sender, EventArgs e)
        {

        }
        //bill part
        private void txtBPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
        }

        private void txtBPName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //product
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView4.Rows[index];
            txtid.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            txtprice.Text = row.Cells[2].Value.ToString();
            cmbcat.Text = row.Cells[3].Value.ToString();
            txtqt.Text = row.Cells[4].Value.ToString();
        }
        //staff registration
        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[index];
            txtUId.Text = row.Cells[0].Value.ToString();
            txtFName.Text = row.Cells[1].Value.ToString();
            txtLName.Text = row.Cells[2].Value.ToString();
            txtCNumber.Text = row.Cells[3].Value.ToString();
            txtDoB.Text = row.Cells[4].Value.ToString();
            cmbJobTitle.Text = row.Cells[4].Value.ToString();
            txtAddress.Text = row.Cells[4].Value.ToString();
            txtSUName.Text = row.Cells[4].Value.ToString();
            txtSpw.Text = row.Cells[4].Value.ToString();
        }
        //Category
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            TxtCatgy.Text = row.Cells[0].Value.ToString();
        }
        //calculate
        private void button5_Click_1(object sender, EventArgs e)
        {
            int x;
            double totle = 0;

            for (x = 0; x <= dataGridView5.Rows.Count - 1; x++)
            {
                totle = totle + Convert.ToInt32(dataGridView5.Rows[x].Cells[5].Value.ToString());
            }
            txtTprice.Text = totle.ToString();
            // MessageBox.Show(totle.ToString());
            dataGridView5.Rows.Clear();
        }
        //remove bill
        private void button14_Click_1(object sender, EventArgs e)
        {
            //
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //
        }
        int qunt = 0;
        double price1;
        double total1 = 0;
        int y = 0;
        private void button8_Click_2(object sender, EventArgs e)
        {
            if (Dtp1.Text == "" || txtCBNumber.Text == "" || txtCBName.Text == "" || txtCBPrice.Text == "" || txtCBQun.Text == "")
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
                string Query = "insert into SaledTbl values ('" + Dtp1.Value.ToString("yyyy-MM-dd") + "','" + txtCBNumber.Text + "','" + txtCBName.Text + "','" + txtCBPrice.Text + "','" + txtCBQun.Text + "','" + txtTprice.Text + "')";
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
        }
        //remove bill
        private void button14_Click_2(object sender, EventArgs e)
        {
            //DataGridViewRow newData = dataGridView6.Rows[index];

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

        private void tabDash_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
