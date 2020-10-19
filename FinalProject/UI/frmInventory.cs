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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }

        categoriesDAL cDAL = new categoriesDAL();
        productsDAL pDAL = new productsDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {   
            //close the window
            this.Hide();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //Display the categories in the combo box
            DataTable cDt = cDAL.Select();
            //adding categories in data table to combo box
            cmbCategories.DataSource = cDt;
            //give the value member and display member for combobox
            cmbCategories.DisplayMember = "title";
            cmbCategories.ValueMember = "title";

            //display all th products in datagrid view when form loaded
            DataTable pDt = pDAL.Select();
            //adding data in data table to data grid view
            dgvProducts.DataSource = pDt;
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display all the products based on selected category

            //holding the selected category from combo box in a string
            string category = cmbCategories.Text;
            //getting data to datatable according to category
            DataTable dt = pDAL.DisplayProductsByCategory(category);
            //filling the data grid view 
            dgvProducts.DataSource = dt;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            //display all the products

            DataTable dt = pDAL.Select();

            dgvProducts.DataSource = dt;

            cmbCategories.Text = "";
        }
    }
}
