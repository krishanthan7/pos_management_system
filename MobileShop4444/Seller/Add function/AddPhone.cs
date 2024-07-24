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
    public partial class AddPhone : Form
    {
        public AddPhone()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO mobile (company, modelname ,ram, internalstorage, display, quantity,rearcamera,frontcamera, fingerprint, simtype,networktype, price) VALUES (@company, @modelname ,@ram, @internalstorage, @display, @quantiity, @rearcamera, @frontcamera, @fingerprint, @simtype, @networktype, @price);", LogIn.connection);
            cmd.Parameters.AddWithValue("@company", txtCompany.Text);
            cmd.Parameters.AddWithValue("@modelname", txtModel.Text);
            cmd.Parameters.AddWithValue("@ram", txtRam.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@internalstorage", txtInStorage.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@display", txtDisplay.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@quantiity", txtquantity.Text);
            cmd.Parameters.AddWithValue("@rearcamera", txtRearCamera.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@frontcamera", txtFrontCamera.SelectedItem.ToString());            
            cmd.Parameters.AddWithValue("@fingerprint", txtFingerPrint.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@simtype", txtSim.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@networktype", txtNetwork.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);


            cmd.ExecuteNonQuery();

            MessageBox.Show("Mobile Added succesfully");
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
        }
    }
}
