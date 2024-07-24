using MobileShop4444.Admin.Add_Seller;
using MobileShop4444.Admin.Admin_Dash;
using MobileShop4444.Admin.Update_profile;
using MobileShop4444.Admin.View_seller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop4444.Admin
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            AddSeller ai = new AddSeller();
            ai.ShowDialog();

        }

        private void bntLogOut_Click(object sender, EventArgs e)
        {
            LogIn fm = new LogIn();
            fm.Show();
            this.Hide();
        }

        private void btnCustomerRecord_Click(object sender, EventArgs e)
        {
            UpdateProfile up = new UpdateProfile();
            up.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboardSeller_Click(object sender, EventArgs e)
        {
            AdminDash ad = new AdminDash();
            ad.ShowDialog();
        }

        private void bntBillCustomer_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            ViewSeller vs = new ViewSeller();
            vs.ShowDialog();
        }

        private void bntAddNewPhonebtnViewStock_Click(object sender, EventArgs e)
        {

        }
    }
}
