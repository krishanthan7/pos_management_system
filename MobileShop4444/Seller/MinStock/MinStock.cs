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
using System.Windows.Forms.DataVisualization.Charting;

namespace MobileShop4444.Seller.MinStock
{
    public partial class MinStock : Form
    {
        public MinStock()
        {
            InitializeComponent();
        }

        private void MinStock_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "SELECT company, modelname, price,quantity from laptop WHERE  quantity < 10";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, LogIn.connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            guna2DataGridView1.DataSource = bSource;


            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular); // Replace with your desired font and size
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            /*

           // using System.Windows.Forms.DataVisualization.Charting;

            // Create a new instance of the chart control
            Chart chart1 = new Chart();

            // Set the chart area
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.Enabled = false; // Disable major grid lines on the X-axis
            chartArea.AxisY.MajorGrid.Enabled = false; // Disable major grid lines on the Y-axis
            chart1.ChartAreas.Add(chartArea);

            // Create a series and add data points
            Series series = new Series("Wave");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2; // Increase the line width for a slightly bold appearance
            series.Points.AddXY(0, 0);
            series.Points.AddXY(1, 1);
            series.Points.AddXY(2, 0);
            series.Points.AddXY(3, -1);
            series.Points.AddXY(4, 0);

            // Add the series to the chart
            chart1.Series.Add(series);

            // Set the chart control size and position
            chart1.Size = new Size(400, 300);
            chart1.Location = new Point(100, 100);

            // Add the chart control to your form or user control
            this.Controls.Add(chart1);*/

            MySqlDataAdapter MyDAa = new MySqlDataAdapter();
            string sqlSelectAlll = "SELECT company, modelname, price,quantity from mobile WHERE  quantity < 10";
            MyDAa.SelectCommand = new MySqlCommand(sqlSelectAlll, LogIn.connection);

            DataTable tablee = new DataTable();
            MyDAa.Fill(tablee);

            BindingSource cSource = new BindingSource();
            cSource.DataSource = tablee;


            guna2DataGridView2.DataSource = cSource;


            guna2DataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular); // Replace with your desired font and size
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;



            MySqlDataAdapter MyDAaa = new MySqlDataAdapter();
            string sqlSelectAllll = "SELECT device_name,price,quantity from part WHERE  quantity < 10";
            MyDAaa.SelectCommand = new MySqlCommand(sqlSelectAllll, LogIn.connection);

            DataTable tableee = new DataTable();
            MyDAaa.Fill(tableee);

            BindingSource dSource = new BindingSource();
            dSource.DataSource = tableee;


            guna2DataGridView3.DataSource = dSource;


            guna2DataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Regular); // Replace with your desired font and size
            guna2DataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            guna2DataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
