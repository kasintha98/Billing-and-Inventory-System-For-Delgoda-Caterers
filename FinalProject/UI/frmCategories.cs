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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        categoriesBLL u = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            //getting data from UI

            u.title = txtTitle.Text;
            u.description = txtDescription.Text;
            u.added_date = DateTime.Now;


            ///getting username of logged in user
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;

            //inserting data into database

            bool success = dal.Insert(u);

            //if the data is successfully inserted then value of success will be true or else false
            if (success == true)
            {
                //data successfully inserted
                MessageBox.Show("Category successfully added!");
                Clear();

            }

            else
            {
                //failed inserting data
                MessageBox.Show("Failed to create the category!");
            }

            //refreshing data grid view
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;


        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[rowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[rowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from UI
            u.id = Convert.ToInt32(txtCategoryID.Text);
            u.title = txtTitle.Text;
            u.description = txtDescription.Text;
            u.added_date = DateTime.Now;

            ///getting username of logged in user
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;

            //Updating data to database

            bool success = dal.Update(u);
            //If data updated successfully  the value of success is true r else it will be false
            if (success == true)
            {
                //data successfully updated
                MessageBox.Show("Category successfully Updated!");
                Clear();
            }
            else
            {
                //failed to update user
                MessageBox.Show("Failed to update category!");
            }
            //refresh the datagrid view
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting user from form
            u.id = Convert.ToInt32(txtCategoryID.Text);

            bool success = dal.Delete(u);
            //id data is deleted successfully success is thrue or else it is false

            if (success == true)
            {
                //user deleted succssfully
                MessageBox.Show("Category deleted successfully!");
                Clear();
            }
            else
            {
                //user deleting failed
                MessageBox.Show("Category deleting failed!");

            }
            //refreshing data grid view

            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

   

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            //Get keyword from textbox

            string keywords = txtSearch.Text;

            //check if the keywords has value or not
            if (keywords != null)
            {
                //show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;

            }
        }
    }
}
