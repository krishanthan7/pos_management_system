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

namespace MobileShop4444.Seller.View_Stock
{
    public partial class ViewMobile : Form
    {
        public ViewMobile()
        {
            InitializeComponent();
        }

        private void ViewMobile_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT id ,company, modelname, internalstorage ,frontcamera ,quantity ,price  from mobile";
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row index is clicked
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                lblid.Text = selectedRow.Cells[0].Value.ToString();
                lblcompany.Text = selectedRow.Cells[1].Value.ToString();
                lblmodel.Text = selectedRow.Cells[2].Value.ToString();
                lblInternalstorage.Text = selectedRow.Cells[3].Value.ToString();
                lblfront.Text = selectedRow.Cells[4].Value.ToString();
                
                lblqty.Text = selectedRow.Cells[5].Value.ToString();
                lblprice.Text = selectedRow.Cells[6].Value.ToString();


            }
            MySqlCommand cmd = new MySqlCommand("SELECT ram,rearcamera,display,simtype,networktype,fingerprint FROM mobile where id = @id", LogIn.connection);
            cmd.Parameters.AddWithValue("@id", lblid.Text);

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblRam.Text = rdr[0].ToString();
                lblrear.Text = rdr[1].ToString();
                lbldisplay.Text = rdr[2].ToString();
                lblsim.Text = rdr[3].ToString();
                lblnetwork.Text = rdr[4].ToString();                
                
                
                lblfinger.Text = rdr[5].ToString();

            }
            rdr.Close();
        }
    }
}
