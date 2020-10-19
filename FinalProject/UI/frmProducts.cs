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
    public partial class frmProducts : Form
    {
        productsBLL p = new productsBLL();
        productsDAL pdal = new productsDAL();
        userDAL udal = new userDAL();
        categoriesDAL cdal = new categoriesDAL();

        public frmProducts()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //get all the values from product form
                p.name = txtName.Text;
                p.category = cmbCategory.Text;
                p.description = txtDescription.Text;
                p.rate = decimal.Parse(txtRate.Text);
                p.qty = 0;
                p.added_date = DateTime.Now;
                //getting user name of logged in user
                string loggedUser = frmLogin.loggedIn;
                userBLL usr = udal.GetIDFromUsername(loggedUser);
                p.added_by = usr.id;

                //create variable to check if product added successfully or not
                bool success = pdal.Insert(p);
                //if the product is succssesfully added then the value of success is true else false
                if (success == true)
                {
                    //product inserted successfully
                    MessageBox.Show("Product Added Successfully!");
                    //calling clear method to clear all fields
                    Clear();
                    //refresh the datagrid view
                    DataTable dt = pdal.Select();
                    dgvProducts.DataSource = dt;
                }
                else
                {
                    //product inserting failed
                    MessageBox.Show("Product Adding Failed!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            //creating data table tohold the categories from database
            DataTable categoriesDT = cdal.Select();
            //specify datasourse for category combobox
            cmbCategory.DataSource = categoriesDT;
            //specify display member and value memer for ombobox
            cmbCategory.DisplayMember = "title";
            cmbCategory.ValueMember = "title";

            //load the datagrid view with all the products
            DataTable dt = pdal.Select();
            dgvProducts.DataSource = dt;
        }


        public void Clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtRate.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";

        }

        private void dgvProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //create int variable to know which product is clicked
            int rowIndex = e.RowIndex;
            //display the value on respective textboxes
            txtID.Text = dgvProducts.Rows[rowIndex].Cells[0].Value.ToString();
            txtName.Text = dgvProducts.Rows[rowIndex].Cells[1].Value.ToString();
            cmbCategory.Text = dgvProducts.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dgvProducts.Rows[rowIndex].Cells[3].Value.ToString();
            txtRate.Text = dgvProducts.Rows[rowIndex].Cells[4].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the values from ui of product form
            p.id = int.Parse(txtID.Text);
            p.name = txtName.Text;
            p.category = cmbCategory.Text;
            p.description = txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.added_date = DateTime.Now;
            //getting user name of logged in user
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            p.added_by = usr.id;

            //create boolean variable check if the product is updated
            bool success = pdal.Update(p);
            //if the product updated successfully then value of success will true else false
            if (success == true)
            {
                //product updated successfully
                MessageBox.Show("Product Successfully Updated!");
                //clear allthe fields
                Clear();
                //refresh the data grid view
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                //failed to update product
                MessageBox.Show("Failed to update the product!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //get the id of the product to delete
            p.id = int.Parse(txtID.Text);

            //create bool variable to check if the product is deleted or not
            bool success = pdal.Delete(p);

            //if product is deleted successfully bool is true else its false
            if (success == true)
            {
                //Successfully Deleted The Product
                MessageBox.Show("Successfully Deleted The Product!");
                Clear();
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;

            }
            else
            {
                //Failed To Delete The Product
                MessageBox.Show("Failed To Delete The Product!");
            }

        }

        

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            //Get keyword from textbox

            string keywords = txtSearch.Text;

            //check if the keywords has value or not
            if (keywords != null)
            {
                //show user based on keywords
                DataTable dt = pdal.Search(keywords);
                dgvProducts.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;

            }
        }
    }




}
