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

namespace inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\inventory\\inventory\\invent.mdf\";Integrated Security=True");
           conn.Open();
           SqlCommand cmd = new SqlCommand("insert into products values (@pid,@pname,@price,@quantity,@category)", conn);
           cmd.Parameters.AddWithValue("@pid",int.Parse(pidtxtx.Text));
           cmd.Parameters.AddWithValue("@pname",pnametxt.Text);
           cmd.Parameters.AddWithValue("@price", double.Parse(pricetxt.Text));
           cmd.Parameters.AddWithValue("@quantity", qtytxt.Text);
           cmd.Parameters.AddWithValue("@category",catgrytxt.Text);
           cmd.ExecuteNonQuery();
           conn.Close();
           MessageBox.Show("new product added");
           
           
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\inventory\\inventory\\invent.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update products set pname=@pname ,price=@price,quantity=@quantity,category=@category where pid=@pid", conn);
            cmd.Parameters.AddWithValue("@pid", int.Parse(pidtxtx.Text));
            cmd.Parameters.AddWithValue("@pname", pnametxt.Text);
            cmd.Parameters.AddWithValue("@price", double.Parse(pricetxt.Text));
            cmd.Parameters.AddWithValue("@quantity", qtytxt.Text);
            cmd.Parameters.AddWithValue("@category", catgrytxt.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated Product");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\inventory\\inventory\\invent.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete products where pid=@pid ", conn);
            cmd.Parameters.AddWithValue("@pid", int.Parse(pidtxtx.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("product deleted");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Sandalu\\Desktop\\c#\\New folder\\inventory\\inventory\\invent.mdf\";Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from products ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            MessageBox.Show("view all products");


        }
    }
}
