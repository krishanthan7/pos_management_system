using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MobileShop4444.Admin.Admin_Dash
{
    public partial class AdminDash : Form
    {
        public AdminDash()
        {
            InitializeComponent();
        }

        private void AdminDash_Load(object sender, EventArgs e)
        {



            ///

            

            //


            string query = "SELECT SUM(quantity) FROM laptop";
            int totalLapCount = 0;

            using (MySqlCommand command = new MySqlCommand(query, LogIn.connection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalLapCount = Convert.ToInt32(result);
                    label8.Text = totalLapCount.ToString();
                }
            }
            string querry = "SELECT SUM(quantity) FROM mobile";
            int totalMobileCount = 0;

            using (MySqlCommand command = new MySqlCommand(querry, LogIn.connection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalMobileCount = Convert.ToInt32(result);
                    label9.Text = totalMobileCount.ToString();
                }
            }

            string querrry = "SELECT SUM(quantity) FROM part";
            int totalPartCount = 0;

            using (MySqlCommand command = new MySqlCommand(querrry, LogIn.connection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalPartCount = Convert.ToInt32(result);
                    label10.Text = totalPartCount.ToString();
                }
            }

            string queryy = "SELECT COUNT(*) FROM customer";
            int totalcusCount = 0;

            using (MySqlCommand command = new MySqlCommand(queryy, LogIn.connection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalcusCount = Convert.ToInt32(result);
                    label11.Text = totalcusCount.ToString();
                }
            }
            Chart chart1 = new Chart();

            // Add a ChartArea to the chart control
            ChartArea chartArea1 = new ChartArea();
            chart1.ChartAreas.Add(chartArea1);

            // Set the chart type and data points
            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
            chart1.Series["Series1"].Points.AddXY("Lap-Tops", totalLapCount);
            chart1.Series["Series1"].Points.AddXY("Mobiles ", totalMobileCount);
            chart1.Series["Series1"].Points.AddXY("Computer Parts", totalPartCount);

            // Customize the appearance
            chart1.Titles.Add("Stock Quanity of Products");
            chart1.ChartAreas[0].AxisX.Title = "Products";
            chart1.ChartAreas[0].AxisY.Title = "Sales";

            this.Controls.Add(chart1);
            chart1.Dock = DockStyle.Top; // Dock the chart control to the top of the form


            chart1.Size = new Size(400, 300); // Set the size of the chart control
            chart1.Location = new Point(50, 50); // Set the position of the chart control


            MySqlCommand cmd = new MySqlCommand("SELECT user_role FROM user WHERE user_role = 'Seller'", LogIn.connection);

            int count = 0;
            string role = "";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                role = rdr[0].ToString();
                if (role == "Seller")
                {
                    count += 1;
                    //lblCount.Text += ", " + rdr[0].ToString();
                }
            }
            rdr.Close();
            lblCount.Text = count.ToString();

            MySqlCommand cmdr = new MySqlCommand("SELECT user_role FROM user WHERE user_role = 'Administrator'", LogIn.connection);

            int countt = 0;
            string rolee = "";
            MySqlDataReader rdrr = cmdr.ExecuteReader();
            while (rdrr.Read())
            {
                rolee = rdrr[0].ToString();
                if (rolee == "Administrator")
                {
                    countt += 1;
                    //lblCount.Text += ", " + rdr[0].ToString();
                }
            }
            rdrr.Close();
            lblAdminCount.Text = countt.ToString();
            

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
