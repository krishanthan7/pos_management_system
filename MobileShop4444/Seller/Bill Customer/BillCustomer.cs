using MobileShop4444.Admin;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Xml;

namespace MobileShop4444.Seller.Bill_Customer
{
    public partial class BillCustomer : Form
    {
        public static MySqlConnection connection;
        private PrintDocument printDocument;
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

            // Calculate the scaling factor to fit the form on the printed page
            float scaleFactor = Math.Min((float)e.PageBounds.Width / bitmap.Width, (float)e.PageBounds.Height / bitmap.Height);

            // Calculate the new dimensions for printing
            int printWidth = (int)(bitmap.Width * scaleFactor);
            int printHeight = (int)(bitmap.Height * scaleFactor);

            // Print the captured image
            e.Graphics.DrawImage(bitmap, new Rectangle(e.PageBounds.Left, e.PageBounds.Top, printWidth, printHeight));
        }
        //public  cartDataGridView dgvSource;
        public BillCustomer()
        {
            InitializeComponent();
            try
            {
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                sb.Server = "127.0.0.1";
                sb.Port = 3306;
                sb.UserID = "root";
                sb.Password = "";
                sb.Database = "sales";

                connection = new MySqlConnection(sb.ToString());
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        


        ////
        private void BillCustomer_Enter(object sender, EventArgs e)
        {
            //txtCompany.Items.Clear();
            //txtModel.Items.Clear();
            
            /*
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
            */
        }

        private void BillCustomer_Load(object sender, EventArgs e)
        {
            

        }
        

        private void txtCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCompany.Items.Clear();
            String name = txtProduct.Text;      
            if (name =="Laptop")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT company FROM laptop WHERE quantity > '0';", LogIn.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtCompany.Items.Add(rdr[0].ToString());

                }
                rdr.Close();
                
            }
            else if (name == "Mobile")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT company FROM mobile WHERE quantity > '0';", LogIn.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtCompany.Items.Add(rdr[0].ToString());

                }
                rdr.Close();

            }


            else if (name == "Part")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT company FROM part WHERE quantity > '0';", LogIn.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtCompany.Items.Add(rdr[0].ToString());

                }
                rdr.Close();

            }
            else
            {
                MessageBox.Show("Error");
            }

            // Assuming you have a dropdown menu control called "myDropdown" of type DropDownList

            // Create a HashSet to store unique items
            HashSet<string> uniqueItems = new HashSet<string>();

            // Iterate over the items in the dropdown menu
            for (int i = 0; i < txtCompany.Items.Count; i++)
            {
                string itemText = txtCompany.Items[i].ToString();
                if (!uniqueItems.Contains(itemText))
                {
                    uniqueItems.Add(itemText);
                }
                else
                {
                    // Remove duplicate item from the dropdown menu
                    txtCompany.Items.RemoveAt(i);
                    i--; // Decrement the index after removing an item
                }
            }




        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                double total;

            double unitprice = 0;
            string table = txtProduct.Text;

            /////////

            ///

            
            /*if (txtQuantity.Text == "")
            {
                MessageBox.Show("Whoops!!! you forgot to add Quantiy");
            }*/

            if (table == "Mobile" | table == "Laptop")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT price FROM " + table + " WHERE quantity > '0' AND modelname = @name;", LogIn.connection);
                cmd.Parameters.AddWithValue("@name", lblProduct.Text);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    unitprice += (Convert.ToDouble(rdr[0]));

                }

                total = Convert.ToDouble(txtQuantity.Text) * unitprice;
                //lblPrice.Text = total.ToString();
                lblPrice.Text = total.ToString();
                rdr.Close();

                double x = Convert.ToDouble(labelTotalPrice.Text);
                labelTotalPrice.Text = (total + x).ToString();
            }
            else //if (table == "Part")
            {
                 table = "Part";
                MySqlCommand cmd = new MySqlCommand("SELECT price FROM " + table + " WHERE quantity > '0' AND device_name = @name;", LogIn.connection);
                cmd.Parameters.AddWithValue("@name", lblProduct.Text);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    unitprice += (Convert.ToDouble(rdr[0]));

                }
                rdr.Close();
                total = Convert.ToDouble(txtQuantity.Text) * unitprice;
                lblPrice.Text = total.ToString();

                double x = Convert.ToDouble(labelTotalPrice.Text);
                labelTotalPrice.Text = (total + x).ToString();
            }
            /*
            else
            {
                MessageBox.Show("select table");
            }*/

            // Define columns if they are not already defined
            if (cartDataGridView.Columns.Count == 0)
            {
                cartDataGridView.Columns.Add("ItemName", "Item Name");
                cartDataGridView.Columns.Add("ItemPrice", "Item Price");
                cartDataGridView.Columns.Add("ItemQuantity", "Item Quantity");
            }

            // Create a new row to add the item
            DataGridViewRow newRow = new DataGridViewRow();

            // Create cells for each column in the DataGridView
            DataGridViewTextBoxCell itemNameCell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell itemPriceCell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxCell itemQuantityCell = new DataGridViewTextBoxCell();

            // Set the values for the cells
            itemNameCell.Value = lblProduct.Text;     // Replace with the actual item name
            itemPriceCell.Value = txtUnitPrice.Text;          // Replace with the actual item price
            itemQuantityCell.Value = txtQuantity.Text;            // Replace with the actual item quantity

            // Add the cells to the row
            newRow.Cells.Add(itemNameCell);
            newRow.Cells.Add(itemPriceCell);
            newRow.Cells.Add(itemQuantityCell);

            // Add the row to the DataGridView
            cartDataGridView.Rows.Add(newRow);
            cartDataGridView.ColumnHeadersVisible = true;
            cartDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Replace with your desired font and size
            cartDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Replace with your desired color
            cartDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // Replace with your desired color
            /////////////////////

            string itemName = lblProduct.Text; // Replace with the actual item name
            int quantity = Convert.ToInt32(txtQuantity.Text);

            if (table == "Mobile" | table == "Laptop" )
            {

                string updateQuery = "UPDATE " + table + " SET `quantity` = `quantity` - @quantity WHERE modelname = @ItemName";

                using (MySqlCommand command = new MySqlCommand(updateQuery, LogIn.connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@ItemName", lblProduct.Text);

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Quantity updated successfully
                        MessageBox.Show("Quantity updated.");
                    }
                    else
                    {
                        // Item not found or insufficient quantity
                        MessageBox.Show("Item not found or insufficient quantity.");
                    }

                }
            }
            
            else if (table =="Part")
            {
                string updateQuery = "UPDATE " + table + " SET `quantity` = `quantity` - @Quantity WHERE device_name = @ItemName";

                using (MySqlCommand command = new MySqlCommand(updateQuery, LogIn.connection))
                {
                    // Set the parameter values
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@ItemName", lblProduct.Text);

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Quantity updated successfully
                        MessageBox.Show("Quantity updated.");
                    }
                    else
                    {
                        // Item not found or insufficient quantity
                        MessageBox.Show("Item not found or insufficient quantity.");
                    }

                }
                
            }
            txtProduct.Text="";
            /////////////////////
            ///
            }
            catch
            {
                MessageBox.Show("Empty fields are not allowed");
            }

        }





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Clear();
            String name = txtListBox.GetItemText(txtListBox.SelectedItem);
            lblProduct.Text = name;

            
            
           
            double unitprice = 0;
            string table = txtProduct.Text;
            
            
            if (table == "Mobile" | table == "Laptop")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT price,quantity FROM " + table + " WHERE quantity > '0' AND modelname = @name;", LogIn.connection);
                cmd.Parameters.AddWithValue("@name", lblProduct.Text);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtUnitPrice.Text = (Convert.ToDouble(rdr[0]).ToString());
                    txtStock.Text = (Convert.ToDouble(rdr[1]).ToString());


                }
                rdr.Close();

            }


            //////////////


            else if(table=="Part")
            {
                MySqlCommand dmd = new MySqlCommand("SELECT price,quantity FROM " + table + " WHERE quantity > '0' AND device_name = @name;", LogIn.connection);
                dmd.Parameters.AddWithValue("@name", lblProduct.Text);
                MySqlDataReader rdr = dmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtUnitPrice.Text = (Convert.ToDouble(rdr[0]).ToString());
                    txtStock.Text = (Convert.ToDouble(rdr[1]).ToString());

                }
                rdr.Close();
                
            }
            else
            {
                MessageBox.Show("Something wrong");
            }
            

            


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(lblPrice.Text); //
            double y = Convert.ToDouble(labelTotalPrice.Text);
            labelTotalPrice.Text = (y - x).ToString();
            lblPrice.Text = "00.00";
            
            if (cartDataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = cartDataGridView.SelectedRows[0];

                // Remove the row from the DataGridView
                cartDataGridView.Rows.Remove(selectedRow);
            }
            int restore_stock = Convert.ToInt32(txtStock.Text);
            //int add_quantity = Convert.ToInt32(txtQuantity.Text);

            //int real_qty = restore_stock + add_quantity;
            
                string table = txtProduct.Text;
                if(table == "Mobile" | table == "Laptop")
                    {
                    MySqlCommand cmd = new MySqlCommand("UPDATE " + table + " SET quantity=@quantity WHERE modelname = @name", LogIn.connection);
                    cmd.Parameters.AddWithValue("@quantity", restore_stock);
                    cmd.Parameters.AddWithValue("@name", lblProduct.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(table + " Updated succesfully");
                    //Close();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE part SET quantity=@quantity WHERE device_name = @name", LogIn.connection);
                    cmd.Parameters.AddWithValue("@quantity", restore_stock);
                    cmd.Parameters.AddWithValue("@name", lblProduct.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(table + " Updated succesfully");
                }
            }
            catch
            {
                MessageBox.Show("something wrong ");
            }


        }

        private void txtModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            String table,company;
            table = txtProduct.Text;
            company = txtCompany.Text;
            txtListBox.Items.Clear();
            if (table == "Mobile" | table == "Laptop")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT modelname FROM " + table + " WHERE quantity > '0' AND company = '" + company + "';", LogIn.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtListBox.Items.Add(rdr[0].ToString());

                }
                rdr.Close();
            }
            else if(table =="Part")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT device_name FROM " + table + " WHERE quantity > '0' AND company = '" + company + "';", LogIn.connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //lbl1.Text += ", " + rdr[0].ToString();
                    txtListBox.Items.Add(rdr[0].ToString());

                }
                rdr.Close();


            }
            


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            MySqlCommand cmd = new MySqlCommand("INSERT INTO customer (name, mobile, email,address) VALUES (@name, @mobile, @email,@address);", LogIn.connection);
            
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Customer table Added succesfully");
            Close();
            ////////
            
            /*
            string query = "SELECT id FROM customer WHERE name = @name AND email = @email";
            using (MySqlCommand command = new MySqlCommand(query, LogIn.connection))
            {
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string message = reader[0].ToString();
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("No results found.");
                    }
                }
            }


            */
            ////

            // Assuming you have a DataGridView control named "dataGridView1"



            // Assuming you have a DataGridView control named "dataGridView1" and a Label control named "label1"



            //FinishedPurcharse finishedPurcharse = new FinishedPurcharse();
            //finishedPurcharse.ShowDialog();
            // Assuming you have a DataGridView control named dataGridView1 and a label named lblText.

            // Retrieve the index of the desired column.
            int columnIndex = 0; // Adjust this index based on the column you want to assign to lblText.

            // Create a StringBuilder to concatenate the values.
            StringBuilder sb = new StringBuilder();

            // Iterate through each row in the column and append the values to the StringBuilder.
            foreach (DataGridViewRow row in cartDataGridView.Rows)
            {
                // Make sure the row is not a new row or a header row.
                if (!row.IsNewRow && row.Cells[columnIndex].Value != null)
                {
                    sb.AppendLine(row.Cells[columnIndex].Value.ToString());
                    sb.Append(", ");
                }
            }

            // Assign the concatenated values to the label.
            lbltext.Text = sb.ToString();


            int columnIndexx = 2; // Adjust this index based on the column you want to assign to lblText.

            // Create a StringBuilder to concatenate the values.
            StringBuilder sba = new StringBuilder();

            // Iterate through each row in the column and append the values to the StringBuilder.
            foreach (DataGridViewRow row in cartDataGridView.Rows)
            {
                // Make sure the row is not a new row or a header row.
                if (!row.IsNewRow && row.Cells[columnIndexx].Value != null)
                {
                    sba.AppendLine(row.Cells[columnIndexx].Value.ToString());
                    sba.Append(", ");
                }
            }

            // Assign the concatenated values to the label.
            lblqt.Text = sba.ToString();







            string query = "SELECT id FROM customer WHERE name = @name AND email = @email";
            string id = string.Empty; // Declare the variable outside the using block

            using (MySqlCommand command = new MySqlCommand(query, LogIn.connection))
            {
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader[0].ToString();
                        //MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("No results found.");
                    }
                }
            }

            // Now you can access the message variable outside the using block
            // and perform any necessary actions with it.
            // For example:
            //message;
            string insertQuery = "INSERT INTO customer_purchase (cus_id, bought,date, qty) VALUES (@cusId, @bought, @date,@qty)";
            using (MySqlCommand command = new MySqlCommand(insertQuery, LogIn.connection))
            {
                command.Parameters.AddWithValue("@cusId", id);
                command.Parameters.AddWithValue("@bought", lbltext.Text);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@qty", lblqt.Text);

                // Execute the query
                command.ExecuteNonQuery();

                // Perform actions after the data is inserted successfully
                MessageBox.Show("Data inserted into customer_purchase table.");
            }




        }

        private void cartDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //
            
            //
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int total_price = Convert.ToInt32(labelTotalPrice.Text);
                int discount_price = Convert.ToInt32(txtDiscount.Text);
                labelTotalPrice.Text = (total_price - discount_price).ToString();

                int cash = Convert.ToInt32(txtCashRecieve.Text);
                txtReturn.Text = (cash - (total_price - discount_price)).ToString();
            }
            catch {
                MessageBox.Show("Empty fields are not allowed");
            
            }


        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
    }
}
