using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop4444.Seller.View_Stock
{
    public partial class ViewPart : Form
    {
        public ViewPart()
        {
            InitializeComponent();
        }

        private void ViewPart_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT id,device_name,quantity,price from part";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, LogIn.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            guna2DataGridView1.DataSource = bSource;

            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular); // Replace with your desired font and size
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row index is clicked
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                lblid.Text = selectedRow.Cells[0].Value.ToString();
                lbldevice.Text = selectedRow.Cells[1].Value.ToString();
                lblqty.Text = selectedRow.Cells[2].Value.ToString();
                lblprice.Text = selectedRow.Cells[3].Value.ToString();


            }
            MySqlCommand cmd = new MySqlCommand("SELECT company,note FROM part where id = @id", LogIn.connection);
            cmd.Parameters.AddWithValue("@id", lblid.Text);

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblcompany.Text = rdr[0].ToString();
                lblNote.Text = rdr[1].ToString();
            }
            rdr.Close();
        }
    }
}
