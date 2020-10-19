using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FinalProject.CrystalReports;

namespace FinalProject.UI
{
    public partial class frmIncomeExpense : Form
    {
        public frmIncomeExpense()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=DelgodaCater;Integrated Security=True");

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void btnAll_Click(object sender, EventArgs e)
        {
            //showing expense, income and profit

            //getting user input from and t0 dates
            string fromDate = fromDatePick.Value.ToString();
            string toDate = toDatePick.Value.ToString();

            //sql query to get data
            string totalIncomeSql = "SELECT SUM(grandTotal) AS Total_Income FROM tbl_transactions WHERE type='Sales' AND transaction_date between '"+fromDate+"' AND '"+toDate+"';";
            string totalExpenseSql = "SELECT SUM(grandTotal) AS Total_Expense FROM tbl_transactions WHERE type='Purchase' AND transaction_date between '"+fromDate+"' AND '"+toDate+"'";

            //sql data adapter to hold data from database
            SqlDataAdapter adapterIncome = new SqlDataAdapter(totalIncomeSql, conn);
            SqlDataAdapter adapterExpense = new SqlDataAdapter(totalExpenseSql, conn);

            //data table to hold data temporery
            DataTable dt1 = new DataTable();
            adapterIncome.Fill(dt1);

            DataTable dt2 = new DataTable();
            adapterExpense.Fill(dt2);

            try
            {   //getting data table cell value and displaying in text boxes
                decimal income = (decimal)dt1.Rows[0]["Total_Income"];
                txtIncome.Text = income.ToString();

                decimal expense = (decimal)dt2.Rows[0]["Total_Expense"];
                txtExpense.Text = expense.ToString();

                //calculating profitt and showing
                decimal profit = income - expense;
                txtProfit.Text = profit.ToString();
            }
            catch (Exception)
            {
                //error message when there are no reords
                MessageBox.Show("There are no transaction records between selected dates!");
            }


            //showing income and expense transactions

            try
            {
                //sql query to get data
                string incomeDetailsSql = "SELECT dea_cust_id AS customer_ID,grandTotal,transaction_date FROM tbl_transactions WHERE type='Sales' AND transaction_date between '" + fromDate + "' AND '" + toDate + "';";
                string expenseDetailsSql = "SELECT dea_cust_id AS dealer_ID,grandTotal,transaction_date FROM tbl_transactions WHERE type='Purchase' AND transaction_date between '" + fromDate + "' AND '" + toDate + "'";

                //sql data adapter to hold data from database
                SqlDataAdapter adapterIncomeDetails = new SqlDataAdapter(incomeDetailsSql, conn);
                SqlDataAdapter adapterExpenseDetails = new SqlDataAdapter(expenseDetailsSql, conn);

                //data table to hold data temporery
                DataTable dt3 = new DataTable();
                adapterIncomeDetails.Fill(dt3);

                DataTable dt4 = new DataTable();
                adapterExpenseDetails.Fill(dt4);

                //adding data to datasource
                dgvIncome.DataSource = dt3;
                dgvExpense.DataSource = dt4;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            FinancialReportDesign form = new FinancialReportDesign();
            CrystalReports.FinanceReport report = new FinanceReport();

            TextObject text1 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtIncomeBox"];
            text1.Text = txtIncome.Text.ToString();

            TextObject text2 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtExpenseBox"];
            text2.Text = txtExpense.Text.ToString();

            TextObject text3 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["txtProfitBox"];
            text3.Text = txtProfit.Text.ToString();

            TextObject text4 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["Text9"];
            text4.Text = "Delgoda Caterers And Family Restaurent";

            TextObject text5 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["Text10"];
            text5.Text = "364, New Kandy Road, Delgoda";

            form.crystalReportViewerFinance.ReportSource = report;
            form.Show();


        }
    }
}
