using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.BLL;

namespace FinalProject.DAL
{
    class transactionDAL
    {
        //create a connection variable
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Transaction Method

        public bool Insert_Transaction(transactionsBLL t , out int transactionID)
        {
            //create a boolean value and set its defau;t value to false
            bool isSuccess = false;
            //set the out transactionID to -1
            transactionID = -1;
            //create a sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //sql query to insert the transaction
                string sql = "INSERT INTO tbl_transactions (type, dea_cust_id, grandTotal, transaction_date, tax, discount, added_by) VALUES (@type, @dea_cust_id, @grandTotal, @transaction_date, @tax, @discount, @added_by); SELECT @@IDENTITY;";

                //sql command to pass the value in sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //passing the value to sql query using cmd
                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@dea_cust_id", t.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                cmd.Parameters.AddWithValue("@tax", t.tax);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);

                //open database connection
                conn.Open();

                //execute the query
                object o = cmd.ExecuteScalar();

                //if the query executed successfully then the value will not be null else it is null
                if(o != null)
                {
                    //query executed successfully
                    transactionID = int.Parse(o.ToString());
                    isSuccess = true;
                }
                else
                {
                    //failed to execute query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close the connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Method to display all the transactions

        public DataTable DisplayAllTransactions()
        {
            //creating sql connection first
            SqlConnection conn = new SqlConnection(myconnstrng);

            //creating a datatable to hold the data from database temporery
            DataTable dt = new DataTable();

            try
            {
                //writing sql query to display transactions
                string sql = "SELECT * FROM tbl_transactions";

                //sqlcommand to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter to hold the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open database connection
                conn.Open();

                //fill the data in data table
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        #endregion

        #region Method to display transactions based on transaction type

        public DataTable DisplayTransactionsByType(string type)
        {
            //create sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //creating datatable 
            DataTable dt = new DataTable();

            try
            {
                //writing sql query
                string sql = "SELECT * FROM tbl_transactions WHERE type='"+type+"'";
                //sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //creating sql data adapter to hold the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //open satabse connection
                conn.Open();
                //filling the datatable with data
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        #endregion
    }
}
