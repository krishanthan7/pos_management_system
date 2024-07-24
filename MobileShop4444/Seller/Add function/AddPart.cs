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

namespace MobileShop4444.Seller
{
    public partial class AddPart : Form
    {
        public AddPart()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO part (device_name, company, note ,quantity,price) VALUES (@device,@company,@note,@quantity,@price);", LogIn.connection);
            
            cmd.Parameters.AddWithValue("@device", txtDeivceName.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@company", txtCompany.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@note", txtNote.Text);
            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);


            cmd.ExecuteNonQuery();

            MessageBox.Show("Device Added succesfully");
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
        }

        private void AddPart_Load(object sender, EventArgs e)
        {

        }
    }
}
