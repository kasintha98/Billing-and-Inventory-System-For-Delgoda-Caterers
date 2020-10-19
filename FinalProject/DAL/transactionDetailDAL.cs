using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.BLL;

namespace FinalProject.DAL
{
    class transactionDetailDAL
    {
        //create connection string 
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Method for Transaction details

        public bool InsertTransactionDetail(transactionDetailBLL td)
        {
            //create a boolean value and set its default value to false
            bool isSuccess = false;

            //create database connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //sql query to insert transaction details
                string sql = "INSERT INTO tbl_transaction_detail (product_id, rate, qty, total, dea_cust_id, added_by) VALUES (@product_id, @rate, @qty, @total, @dea_cust_id, @added_by)";

                //passing the value to sql query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing the values using cmd
                cmd.Parameters.AddWithValue("@product_id", td.product_id);
                cmd.Parameters.AddWithValue("@rate", td.rate);
                cmd.Parameters.AddWithValue("@qty", td.qty);
                cmd.Parameters.AddWithValue("@total", td.total);
                cmd.Parameters.AddWithValue("@dea_cust_id", td.dea_cust_id);
                cmd.Parameters.AddWithValue("@added_date", td.added_date);
                cmd.Parameters.AddWithValue("@added_by", td.added_by);

                //open database connection
                conn.Open();

                //declare the int variable and execute the query
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {

                    //fILED to execute the query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
    }
}
