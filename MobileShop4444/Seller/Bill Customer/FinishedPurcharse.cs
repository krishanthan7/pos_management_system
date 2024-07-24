using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop4444.Seller.Bill_Customer
{
    public partial class FinishedPurcharse : Form
    {
        //
        private PrintDocument printDocument;
        //



        public FinishedPurcharse()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FinishedPurcharse_Load(object sender, EventArgs e)
        {

        }
        //
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Capture the current form as an image
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

            // Print the captured image
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        //
        private void guna2Button5_Click(object sender, EventArgs e)
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
