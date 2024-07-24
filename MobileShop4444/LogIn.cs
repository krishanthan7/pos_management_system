using MobileShop4444.Admin;
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


namespace MobileShop4444
{
    public partial class LogIn : Form
    {
        public static MySqlConnection connection; //
        public LogIn()
        {
            InitializeComponent();
            try
            {
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                sb.Server = "127.0.0.1";
                sb.Port = 3306;
                sb.UserID = "root";
                sb.Password = "";
                sb.Database = "computer_shop";

                connection = new MySqlConnection(sb.ToString());
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT user_role, name FROM user where username = @name AND password = @pass", LogIn.connection);
            cmd.Parameters.AddWithValue("@name", txtUserName.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

            String role = "";
            String name = "";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                role = rdr[0].ToString();
                name = rdr[1].ToString();
            }
            rdr.Close();

            if (role == "Administrator")
            {

                Administrator admin = new Administrator();
                admin.ShowDialog();
                this.Hide();
                

               
                //rdr.Close();

                
            }

            else if (role == "Seller")
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
                
                
                //rdr.Close();
               
            }

            else
            {
                MessageBox.Show("Wrong User name or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //rdr.Close();
            }





            /*
            if (txtUserName.Text == "Savitar" && txtPassword.Text == "2")
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            
           else
            if (txtUserName.Text == "Krish" && txtPassword.Text == "2")
            {
                Administrator admin = new Administrator();
                admin.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User name or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
