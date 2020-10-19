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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }


        userBLL u = new userBLL();
        userDAL dal = new userDAL();


        private void lblTop_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }


        private void Clear()
        {
            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
        }

            private void btnAdd_Click(object sender, EventArgs e)
        {

            //getting data from UI

            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;

            ///getting username of logged in user
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;

            //inserting data into database

            bool success = dal.Insert(u);

            //if the data is successfully inserted then value of success will be true or else false
            if(success == true)
            {
                //data successfully inserted
                MessageBox.Show("User account successfully created!");
                Clear();

            }

            else
            {
                //failed inserting data
                MessageBox.Show("Failed to create the account!");
            }

            //refreshing data grid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;


        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from UI
            u.id = Convert.ToInt32(txtUserID.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;

            ///getting username of logged in user
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;

            //Updating data to database

            bool success = dal.Update(u);
            //If data updated successfully  the value of success is true r else it will be false
            if(success == true)
            {
                //data successfully updated
                MessageBox.Show("Use successfully Updated!");
                Clear();
            }
            else
            {
                //failed to update user
                MessageBox.Show("Failed to update user!");
            }
            //refresh the datagrid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting user from form
            u.id = Convert.ToInt32(txtUserID.Text);

            bool success = dal.Delete(u);
            //id data is deleted successfully success is thrue or else it is false

            if(success == true)
            {
                //user deleted succssfully
                MessageBox.Show("User deleted successfully!");
                Clear();
            }
            else
            {
                //user deleting failed
                MessageBox.Show("User deleting failed!");

            }
            //refreshing data grid view

            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get keyword from textbox

            string keywords = txtSearch.Text;

            //check if the keywords has value or not
            if(keywords != null)
            {
                //show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }
    }
}
