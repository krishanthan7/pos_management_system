using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MobileShop4444.Admin.Add_Seller
{
    public partial class AddSeller : Form
    {
        public AddSeller()
        {
            InitializeComponent();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddSeller_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboardSeller_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO user (user_role, name, mobile, email,username,password) VALUES (@user_role, @name, @mobile, @email,@username,@password);", LogIn.connection);
            cmd.Parameters.AddWithValue("@user_role", txtUserRole.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
            cmd.Parameters.AddWithValue("@email", txtMail.Text);
            cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);


            cmd.ExecuteNonQuery();

            MessageBox.Show("User Added succesfully");
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtMobile.Clear();
            txtMail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
