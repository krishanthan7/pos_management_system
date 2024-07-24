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
    public partial class ViewLaptop : Form
    {
        public ViewLaptop()
        {
            InitializeComponent();
        }

        private void ViewLaptop_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT id ,company, modelname, cpu_speed ,internal_storage ,front_cam ,quantity ,price  from laptop";
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
                myLabel1.Text = selectedRow.Cells[0].Value.ToString(); 
                myLabel2.Text = selectedRow.Cells[1].Value.ToString();
                myLabel3.Text = selectedRow.Cells[2].Value.ToString();
                myLabel4.Text = selectedRow.Cells[3].Value.ToString();
                myLabel5.Text = selectedRow.Cells[4].Value.ToString();
                myLabel6.Text = selectedRow.Cells[5].Value.ToString();
                myLabel7.Text = selectedRow.Cells[6].Value.ToString();
                myLabel8.Text = selectedRow.Cells[7].Value.ToString();
                
                
                 }
            MySqlCommand cmd = new MySqlCommand("SELECT ram,cache_memory,display,finger_print,warranty,o_s FROM laptop where id = @id", LogIn.connection);
            cmd.Parameters.AddWithValue("@id", myLabel1.Text);
            
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                myLabel9.Text = rdr[0].ToString();
                myLabel10.Text = rdr[1].ToString();
                myLabel11.Text = rdr[2].ToString();
                myLabel12.Text = rdr[3].ToString();
                myLabel13.Text = rdr[4].ToString();
                myLabel14.Text = rdr[5].ToString();
                
            }
            rdr.Close();



        }
    }
}
