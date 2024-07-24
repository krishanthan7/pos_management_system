using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop4444.Admin.View_seller
{
    public partial class ViewSeller : Form
    {
        public ViewSeller()
        {
            InitializeComponent();
        }

        private void ViewSeller_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from user";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, LogIn.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            guna2DataGridView1.DataSource = bSource;

            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Replace with your desired font and size
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT * from user WHERE name LIKE '" + textBox1.Text + "%'";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, LogIn.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            guna2DataGridView1.DataSource = bSource;
        }
    }
}
