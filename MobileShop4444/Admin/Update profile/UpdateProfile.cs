using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop4444.Admin.Update_profile
{
    public partial class UpdateProfile : Form
    {
        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void btnDashboardSeller_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" || txtMobile.Text == "" || txtMail.Text == "")
            {
                MessageBox.Show("You can not update with empty fields");
            }
            else
            {

                try
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE user SET user_role=@user_role , name=@name, Mobile=@Mobile_No, email=@email,password=@password WHERE username= '" + txtUserName.Text + "'", LogIn.connection);
                    cmd.Parameters.AddWithValue("@user_role", txtUserRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@name", txtName.Text);

                    cmd.Parameters.AddWithValue("@Mobile_No", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@email", txtMail.Text);
                    //cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Updated succesfully");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Please type the User name properly");
                }

            }
        }

        private void txtUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (txtUserRole.SelectedItem.ToString() == "Administrator")
                {
                    guna2CirclePictureBox2.Visible = true;
                    guna2CirclePictureBox1.Visible = false;
            }
                else
                {
                    guna2CirclePictureBox1.Visible = true;
                    guna2CirclePictureBox2.Visible = false;
            }
            
        }

        private void UpdateProfile_Load(object sender, EventArgs e)
        {
            guna2CirclePictureBox2.Visible = false;
            guna2CirclePictureBox1.Visible = false;
        }
    }
}
