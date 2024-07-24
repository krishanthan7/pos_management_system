using MobileShop4444.Admin;
using MobileShop4444.Admin.Add_Seller;
using MobileShop4444.Admin.Admin_Dash;
using MobileShop4444.Seller;
using MobileShop4444.Seller.Bill_Customer;
using MobileShop4444.Seller.Customer_Record;
//using MobileShop4444.Seller.DeleteStock;
using MobileShop4444.Seller.MinStock;
using MobileShop4444.Seller.SellDash;
using MobileShop4444.Seller.View_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop4444
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void bntLogOut_Click(object sender, EventArgs e)
        {
            LogIn fm = new LogIn();
            fm.Show();
            this.Hide();

        }

        public void hideBtnFunction()
        {
            bntAddNewPhone.Visible = false;
            bntAddNewPC.Visible = false;
            bntAddPart.Visible = false;
            //btnAddRepair.Visible = false;
            //btnViewRepair.Visible = false;
            btnViewLaptop.Visible = false;  
            btnViewPart.Visible = false;
            bntViewPhone.Visible = false;
        }

            private void btnAddStock_Click(object sender, EventArgs e)
        {
            bntAddNewPC.Visible = true;
            bntAddNewPhone.Visible = true;
            bntAddPart.Visible = true;
            //btnAddRepair.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hideBtnFunction();
        }

        private void bntAddNewPhone_Click(object sender, EventArgs e)
        {
            AddPhone ap = new AddPhone();
            ap.ShowDialog();
        }

        private void bntAddNewPC_Click(object sender, EventArgs e)
        {
            AddLaptop al = new AddLaptop();
            al.ShowDialog();
        }

        private void btnAddRepair_Click(object sender, EventArgs e)
        {
            //AddRepair ar = new AddRepair();
            //ar.ShowDialog();
        }

        private void bntAddPart_Click(object sender, EventArgs e)
        {
            AddPart ap = new AddPart();
            ap.ShowDialog();
        }

        private void bntBillCustomer_Click(object sender, EventArgs e)
        {
            hideBtnFunction();
            BillCustomer bc = new BillCustomer();
            bc.ShowDialog();
            

        }

        private void btnDashboardSeller_Click(object sender, EventArgs e)
        {
            hideBtnFunction();
            AdminDash ad = new AdminDash();
            ad.ShowDialog();
        }

        private void btnCustomerRecord_Click(object sender, EventArgs e)
        {
            hideBtnFunction(); 
            CustomerRecord cr = new CustomerRecord();
            cr.ShowDialog();

        }

        private void bntAddNewPhonebtnViewStock_Click(object sender, EventArgs e)
        {
            bntViewPhone.Visible = true;
            btnViewLaptop.Visible = true;
            btnViewPart.Visible = true;
            //btnViewRepair.Visible = true;

        }

        private void bntViewPhone_Click(object sender, EventArgs e)
        {
            ViewMobile vm = new ViewMobile();
            vm.ShowDialog();
        }

        private void btnViewLaptop_Click(object sender, EventArgs e)
        {
            ViewLaptop vl = new ViewLaptop();
            vl.ShowDialog();
        }

        private void btnViewPart_Click(object sender, EventArgs e)
        {
            ViewPart vp = new ViewPart();
            vp.ShowDialog();
        }

        private void btnViewRepair_Click(object sender, EventArgs e)
        {
            //ViewRepair vr = new ViewRepair();
            //vr.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            hideBtnFunction();
            //DeleteStock ds = new DeleteStock();
            //ds.ShowDialog();
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //Administrator admin = new Administrator();
            //admin.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MinStock ms = new MinStock();
            ms.ShowDialog();
            

        }
    }
}
