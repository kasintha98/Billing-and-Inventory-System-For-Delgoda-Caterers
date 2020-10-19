using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FinalProject.BLL;
using FinalProject.CrystalReports;
using FinalProject.DAL;

namespace FinalProject.UI
{
    public partial class frmPurchaseAndSale : Form
    {
        public frmPurchaseAndSale()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //close the form
            this.Hide();
        }

        DeaCustDAL dcDAL = new DeaCustDAL();
        productsDAL pDAL = new productsDAL();
        userDAL uDAL = new userDAL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();

        DataTable transactionDT = new DataTable();

        private void frmPurchaseAndSale_Load(object sender, EventArgs e)
        {
            //get the trnsactionType value from frmUserDashboard
            string type = frmUserDashboard.transactionType;
            //set the value on lbl top
            lblTop.Text = type;

            //specify columns for transactionDataTable
            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keyword from the textbox
            string keyword = txtSearch.Text;

            if (keyword == "")
            {
                //clear all the textboxes
                txtName.Text = "";
                txtEmail.Text = "";
                txtContact.Text = "";
                txtAddress.Text = "";
                return;
            }

            //write the code to get the details and set the value on text boxes
            DeaCustBLL dc = dcDAL.SearchDealerCustomerForTransaction(keyword);

            //now transfer or set the value from DeCustBLL to text boxes
            txtName.Text = dc.name;
            txtEmail.Text = dc.email;
            txtContact.Text = dc.contact;
            txtAddress.Text = dc.address;

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            //get the keyword from product search textbox
            string keyword = txtSearchProduct.Text;

            //check if we have text in txtSearchProducts or not
            if (keyword == "")
            {
                txtProductName.Text = "";
                txtInventory.Text = "";
                txtRate.Text = "";
                txtQty.Text = "";
                return;

            }

            //search the product and display searched item details on text boxes
            productsBLL p = pDAL.GetProductsForTransaction(keyword);

            //set the values on text boxes based on p object
            txtProductName.Text = p.name;
            txtInventory.Text = p.qty.ToString();
            txtRate.Text = p.rate.ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //get product details that user want to buy
                string productName = txtProductName.Text;
                decimal rate = decimal.Parse(txtRate.Text);
                decimal qty = decimal.Parse(txtQty.Text);

                decimal Total = rate * qty; //total price

                //display the subtotal in textbox
                //get the total value from textbox first
                decimal subTotal = decimal.Parse(txtSubTotal.Text);
                subTotal = subTotal + Total;

                //check wether the product is selected or not
                if (productName == "")
                {
                    //display error message
                    MessageBox.Show("Select a product and Try Again!");
                }
                else
                {
                    //add product to the datadrid view
                    transactionDT.Rows.Add(productName, rate, qty, Total);

                    //show in datagridview
                    dgvAddedProducts.DataSource = transactionDT;
                    //display the subtotal in textbox
                    txtSubTotal.Text = subTotal.ToString();
                }

                //clear textboxes
                txtSearchProduct.Text = "";
                txtRate.Text = "0.00";
                txtQty.Text = "0.00";
                txtInventory.Text = "0.00";
                txtProductName.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //get the value from discount textbox
            string value = txtDiscount.Text;

            if (value == "")
            {
                //display error msg
                MessageBox.Show("Please Add Discount First");
                
            }
            else
            {
                //get the discount as a decimal value
                decimal discount = decimal.Parse(txtDiscount.Text);
                //get the sub total as a decimal value
                decimal subTotal = decimal.Parse(txtSubTotal.Text);

                //calculate grandtotal based on discount
                decimal grandTotal = ((100 - discount) / 100) * subTotal;
                //display the grand total in textbox
                txtGrandTotal.Text = grandTotal.ToString();
            }
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            //check if the grandTotal has a value or not 
            //if it has not value then calculate the discount first
            string check = txtGrandTotal.Text;
            if (check == "")
            {
                //display the error msg  to calculate discount
                MessageBox.Show("Calculate the discount and set the Grand Total First(Grand Total can't be empty)!");
            }
            else
            {
                try
                {
                    //calculate VAT
                    //getting the VAT percent first
                    decimal vat = decimal.Parse(txtVat.Text);
                    decimal preGrandTotal = decimal.Parse(txtGrandTotal.Text);

                    decimal newGrandTotal = ((100 + vat) / 100) * preGrandTotal;

                    //display new grand total with vat
                    txtGrandTotal.Text = newGrandTotal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {

            try
            {
               

                //get the paid amount and grand total
                decimal grandTotal = decimal.Parse(txtGrandTotal.Text);
                decimal paidAmount = decimal.Parse(txtPaidAmount.Text);
                //calculate retun amount
                decimal returnAmount = paidAmount - grandTotal;

                //display the return amount in textbox
                txtReturnAmount.Text = returnAmount.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //get the details purchase from the for textboxes
                transactionsBLL transaction = new transactionsBLL();

                transaction.type = lblTop.Text;

                //get the id of dealer or customer
                //get the name of the dealer or customer
                string deaCustName = txtName.Text;

                DeaCustBLL dc = dcDAL.GetDeaCustIDFromName(deaCustName);

                transaction.dea_cust_id = dc.id;
                transaction.grandTotal = Math.Round(decimal.Parse(txtGrandTotal.Text), 2);
                transaction.transaction_date = DateTime.Now;
                transaction.tax = decimal.Parse(txtVat.Text);
                transaction.discount = decimal.Parse(txtDiscount.Text);

                //get the username of logged in user
                string username = frmLogin.loggedIn;

                userBLL u = uDAL.GetIDFromUsername(username);

                transaction.added_by = u.id;
                transaction.transactionDetails = transactionDT;

                //create a boolean variable and set its value to false
                bool success = false;

                //code to INSert TRansaction and Transaction details
                using (TransactionScope scope = new TransactionScope())
                {
                    int transactionID = -1;
                    //create a boolean value and insert transaction
                    bool w = tDAL.Insert_Transaction(transaction, out transactionID);

                    //use for loop to inser transaction details
                    for (int i = 0; i < transactionDT.Rows.Count; i++)
                    {
                        //get all the details of the roduct
                        transactionDetailBLL transactionDetail = new transactionDetailBLL();
                        //get the product name and convert it to ID
                        string productName = transactionDT.Rows[i][0].ToString();
                        productsBLL p = pDAL.GetProductIDFromName(productName);

                        transactionDetail.product_id = p.id;
                        transactionDetail.rate = decimal.Parse(transactionDT.Rows[i][1].ToString());
                        transactionDetail.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                        transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                        transactionDetail.dea_cust_id = dc.id;
                        transactionDetail.added_date = DateTime.Now;
                        transactionDetail.added_by = u.id;

                        //Increase or Decrease Product Qty based on purchase or sales
                        string transactionType = lblTop.Text;

                        //check whether its on purchase or sale
                        bool x = false;
                        if (transactionType == "Purchase")
                        {
                            //increse the product qty
                            x = pDAL.IncreaseProduct(transactionDetail.product_id, transactionDetail.qty);
                        }
                        else if (transactionType == "Sales")
                        {
                            //decrease the product qty
                            x = pDAL.DecreaseProduct(transactionDetail.product_id, transactionDetail.qty);
                        }

                        //Insert Transaction details inside the database
                        bool y = tdDAL.InsertTransactionDetail(transactionDetail);
                        success = w && x && y;
                    }

                    if (success == true)
                    {
                        //Transaction comlete
                        scope.Complete();
                        MessageBox.Show("Transaction Completed Successfully!");
                        //clear the data grid view and clear all he textboxes
                        dgvAddedProducts.DataSource = null;
                        dgvAddedProducts.Rows.Clear();

                        txtSearch.Text = "";
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        txtContact.Text = "";
                        txtSearchProduct.Text = "";
                        txtProductName.Text = "";
                        txtInventory.Text = "0";
                        txtRate.Text = "0";
                        txtQty.Text = "0";
                        txtSubTotal.Text = "0";
                        txtDiscount.Text = "0"; //////////0
                        txtGrandTotal.Text = "0";
                        txtVat.Text = "0"; /////////0
                        txtPaidAmount.Text = "0";
                        txtReturnAmount.Text = "0";
                    }
                    else
                    {
                        //Transaction failed
                        MessageBox.Show("Transaction Failed!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                BillReportDesign billForm = new BillReportDesign();
                CrystalReports.BillReport report = new BillReport();


                #region oldCode
                TextObject text1 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtSubTot"];
                text1.Text = txtSubTotal.Text.ToString();

                TextObject text2 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtDis"];
                text2.Text = txtDiscount.Text.ToString();

                TextObject text3 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtVAT"];
                text3.Text = txtVat.Text.ToString();

                 TextObject text4 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtGrandTot"];
                 text4.Text = txtGrandTotal.Text.ToString();

                 TextObject text5 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtPaidAmou"];
                 text5.Text = txtPaidAmount.Text.ToString();

                 TextObject text6 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtReturnAmou"];
                 text6.Text = txtReturnAmount.Text.ToString();

                 

                #endregion

                
                report.Database.Tables["BillData"].SetDataSource(transactionDT);


                billForm.crystalReportViewer1.ReportSource = report;
                billForm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
