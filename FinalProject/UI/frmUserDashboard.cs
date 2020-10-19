using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.UI;

namespace FinalProject
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        //set a public static method to specify whether user forn is purchase or sales
        public static string transactionType;

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = frmLogin.loggedIn; //
        }

        private void dealersAndCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust DeaCust = new frmDeaCust();
            DeaCust.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {   //set transaction type as purchase in static string
            transactionType = "Purchase";
            frmPurchaseAndSale purchase = new frmPurchaseAndSale();
            purchase.Show();
            
        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {   //set the value of transaction type to sales
            transactionType = "Sales";
            frmPurchaseAndSale sales = new frmPurchaseAndSale();
            sales.Show();
            
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            inventory.Show();
        }
    }
}
