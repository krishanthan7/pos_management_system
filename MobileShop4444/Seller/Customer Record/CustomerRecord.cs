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

namespace MobileShop4444.Seller.Customer_Record
{
    public partial class CustomerRecord : Form
    {
        public CustomerRecord()
        {
            InitializeComponent();
        }

        private void CustomerRecord_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT c.name, cp.bought,cp.date, cp.qty FROM customer AS c INNER JOIN customer_purchase AS cp ON c.id = cp.cus_id";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, LogIn.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            guna2DataGridView1.DataSource = bSource;


            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular); // Replace with your desired font and size
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // Replace with your desired color

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Assuming you have a DataGridView named "dataGridView"

            guna2DataGridView1.CellClick += (cellsender, eventArgs) =>
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                    lblName.Text = selectedRow.Cells["name"].Value.ToString();
                    lblbought.Text = selectedRow.Cells["bought"].Value.ToString();
                    lblqty.Text = selectedRow.Cells["qty"].Value.ToString();

                    // Display the details or perform actions with the retrieved data
                    
                    // ... perform other actions
                }
            };

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT c.name, cp.bought,cp.date, cp.qty FROM customer AS c INNER JOIN customer_purchase AS cp ON c.id = cp.cus_id WHERE c.name LIKE '" + txtCustomer.Text + "%'";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, LogIn.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            guna2DataGridView1.DataSource = bSource;
        }
    }
}
