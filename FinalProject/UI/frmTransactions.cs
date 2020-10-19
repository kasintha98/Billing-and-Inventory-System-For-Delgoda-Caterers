using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.DAL;

namespace FinalProject.UI
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }

        transactionDAL tDal = new transactionDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            //display all the transactions
            DataTable dt = tDal.DisplayAllTransactions();
            dgvTransactions.DataSource = dt;

        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the value from combo box
            string type = cmbTransactionType.Text;

            DataTable dt = tDal.DisplayTransactionsByType(type);

            dgvTransactions.DataSource = dt;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //display all the transactions
            DataTable dt = tDal.DisplayAllTransactions();
            dgvTransactions.DataSource = dt;
            cmbTransactionType.Text = "";
        }
    }
}
