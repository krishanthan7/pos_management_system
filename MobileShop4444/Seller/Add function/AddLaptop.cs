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
using System.Xml.Linq;

namespace MobileShop4444.Seller
{
    public partial class AddLaptop : Form
    {
        public AddLaptop()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO laptop (company, modelname ,ram, cache_memory, display, internal_storage, front_cam, finger_print, warranty,o_s, cpu_speed, quantity, price) VALUES (@company,@modelname, @ram, @cache_memory, @display, @internal_storage, @front_cam, @finger_print, @warranty,@o_s, @cpu_speed, @quantity, @price);", LogIn.connection);
            cmd.Parameters.AddWithValue("@company", txtCompany.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@modelname", txtModelName.Text);
            cmd.Parameters.AddWithValue("@ram", txtRam.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@cache_memory", txtCache.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@display", txtDisplay.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@internal_storage", txtInStorage.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@front_cam", txtFrontCam.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@finger_print", txtFingerPrint.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@warranty", txtWarranty.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@o_s", txtOs.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@cpu_speed", txtSpeed.Text);
            cmd.Parameters.AddWithValue("@quantity", txtQuality.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);


            cmd.ExecuteNonQuery();

            MessageBox.Show("Laptop Added succesfully");
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Cancelled");
            txtCompany.Items.Clear();
            txtModelName.Clear();
            txtRam.Items.Clear();
            txtCache.Items.Clear();
            txtDisplay.Items.Clear();
            txtInStorage.Items.Clear();
            txtFrontCam.Items.Clear();
            txtFingerPrint.Items.Clear();
            txtWarranty.Items.Clear();
            txtOs.Items.Clear();
            txtSpeed.Clear();
            txtQuality.Clear();
            txtPrice.Clear();
        }
    }
}
