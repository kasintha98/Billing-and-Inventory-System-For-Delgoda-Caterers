using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.BLL;
using FinalProject.DAL;

namespace FinalProject.UI
{
    public partial class frmDeaCust : Form
    {
        public frmDeaCust()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the values from form
            dc.id = int.Parse(txtDeaCustID.Text);
            dc.type = cmbDeaCust.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;
            //getting the ID to logged in user and passing its value in dealer customer module
            string loggedUsr = frmLogin.loggedIn;
            userBLL usr = uDal.GetIDFromUsername(loggedUsr);
            dc.added_by = usr.id;

            //create boolean variable to check if dealer/customer successfully updated or not
            bool success = dcDal.Update(dc); /////////////////////

            if (success == true)
            {
                //dealer or customer added successfully
                MessageBox.Show("Dealer/Customer updating successfully!");
                Clear();
                //refresh datagrid view
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //failed to insert dealer or customer
                MessageBox.Show("Dealer/Customer updating failed!");
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //close the form
            this.Hide();
        }

        DeaCustBLL dc = new DeaCustBLL();
        DeaCustDAL dcDal = new DeaCustDAL();

        userDAL uDal = new userDAL();
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                //get the values from form
                dc.type = cmbDeaCust.Text;
                dc.name = txtName.Text;
                dc.email = txtEmail.Text;
                dc.contact = txtContact.Text;
                dc.address = txtAddress.Text;
                dc.added_date = DateTime.Now;
                //getting the ID to logged in user and passing its value in dealer customer module
                string loggedUsr = frmLogin.loggedIn;
                userBLL usr = uDal.GetIDFromUsername(loggedUsr);
                dc.added_by = usr.id;

                //creating boolean variable to check whether the dealer or customer is added or not
                bool success = dcDal.Insert(dc);

                if (success == true)
                {
                    //dealer or customer added successfully
                    MessageBox.Show("Dealer/Customer added successfully!");
                    Clear();
                    //refresh datagrid view
                    DataTable dt = dcDal.Select();
                    dgvDeaCust.DataSource = dt;
                }
                else
                {
                    //failed to insert dealer or customer
                    MessageBox.Show("Dealer/Customer adding failed!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }




        }

        public void Clear()
        {
            txtDeaCustID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";

        }

        private void frmDeaCust_Load(object sender, EventArgs e)
        {
            //refresh datagrid view
            DataTable dt = dcDal.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void dgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int variable to get the identity of row click
            int rowIndex = e.RowIndex;

            txtDeaCustID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cmbDeaCust.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //get the id of the user to delete from data
                dc.id = int.Parse(txtDeaCustID.Text);

                //create boolean variable to check if the dealer/user deleted successfully or not
                bool success = dcDal.Delete(dc);

                if (success == true)
                {
                    //dealer or customer adding successfull
                    MessageBox.Show("Dealer/Customer deleting is Successfull!");
                    Clear();
                    //refresh datagrid view
                    DataTable dt = dcDal.Select();
                    dgvDeaCust.DataSource = dt;
                }
                else
                {
                    //dealer or customer adding failed
                    MessageBox.Show("Dealer/Customer deleting is Failed!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keywords from textbox
            string keywords = txtSearch.Text;

            if(keywords != null)
            {
                //search the data
                DataTable dt = dcDal.Search(keywords);
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //show all the data
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
        }

        private void dgvDeaCust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblDeCustID_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
