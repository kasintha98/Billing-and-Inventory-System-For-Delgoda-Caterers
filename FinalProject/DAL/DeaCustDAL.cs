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
    class DeaCustDAL
    {
        // static string method for database connection string

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method

        public DataTable Select()
        {
            //connection to the database
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                //writing sql quary all the data from data base

                string sql = "SELECT * FROM tbl_dea_cust";

                //creating sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //creating sql data adapter to store data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //open database connection
                conn.Open();
                //adding the value from adapter to data table dt
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

        #region Insert Method details to dealers and customers

        public bool Insert(DeaCustBLL dc)
        {
            //creating a boolean variable variable and set its default value to false
            bool isSucces = false;

            //connection to database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //writing query to add new category
                string sql = "INSERT INTO tbl_dea_cust (type, name, email, contact, address, added_date, added_by) VALUES (@type, @name, @email, @contact, @address, @added_date, @added_by)";
                //creating sql command to pass values
                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing values through parameter
                cmd.Parameters.AddWithValue("@type", dc.type);
                cmd.Parameters.AddWithValue("@name", dc.name);
                cmd.Parameters.AddWithValue("@email", dc.email);
                cmd.Parameters.AddWithValue("@contact", dc.contact);
                cmd.Parameters.AddWithValue("@address", dc.address);
                cmd.Parameters.AddWithValue("@added_date", dc.added_date);
                cmd.Parameters.AddWithValue("@added_by", dc.added_by); 

                //open database connection
                conn.Open();
                //creating the int variable to execute the query
                int rows = cmd.ExecuteNonQuery();

                //if the query is executed successfully then its value will be greater than 0 else it will be less than 0

                if (rows > 0)
                {
                    //query executed successfully
                    isSucces = true;
                }
                else
                {
                    //failed to execute query
                    isSucces = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closing database connection
                conn.Close();
            }

            return isSucces;
        }

        #endregion

        #region Update Method

        public bool Update(DeaCustBLL dc)
        {
            //creating boolean variable and set its default value to false
            bool isSuccess = false;

            //creating sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //query to update the category
                string sql = "UPDATE tbl_dea_cust SET type=@type, name=@name, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by WHERE id=@id";

                //sql command to pass the value on sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //passing value using cmd
                cmd.Parameters.AddWithValue("@type", dc.type);
                cmd.Parameters.AddWithValue("@name", dc.name);
                cmd.Parameters.AddWithValue("@email", dc.email);
                cmd.Parameters.AddWithValue("@contact", dc.contact);
                cmd.Parameters.AddWithValue("@address", dc.address);
                cmd.Parameters.AddWithValue("@added_date", dc.added_date);
                cmd.Parameters.AddWithValue("@added_by", dc.added_by);
                cmd.Parameters.AddWithValue("@id", dc.id);

                //open database connection
                conn.Open();

                //create Int variable to execute query
                int rows = cmd.ExecuteNonQuery();

                //if the query is successfully executed then the value will be greater than 0

                if (rows > 0)
                {
                    //query executed succefully
                    isSuccess = true;
                }
                else
                {
                    //query execution failed
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        #endregion

        #region Delete Method

        public bool Delete(DeaCustBLL dc)
        {
            //create a boolean variable and set its value to false
            bool isSuccess = false;
            //sql connection for database connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //sql query to delete from database
                string sql = "DELETE FROM tbl_dea_cust WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing the value using cmd
                cmd.Parameters.AddWithValue("@id", dc.id);

                //open sqlconnection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query executed successfully then the vqlue of rows will be greater than 0, else less tham 0
                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //failed to xecute query
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        #endregion

        #region Search Method

        public DataTable Search(string keywords)
        {
            //Static method to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //sql query to get data from database
                String sql = "SELECT * FROM tbl_dea_cust WHERE id LIKE '%" + keywords + "%' OR type LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' ";
                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //getting data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //open database connection
                conn.Open();
                //fill data in our table
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //throw message if any errors occurs
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //closing connections
                conn.Close();
            }
            //return the value in data table
            return dt;
        }

        #endregion

        #region Search dealer or customer Method for Transactions

        public DeaCustBLL SearchDealerCustomerForTransaction(string keyword)
        {
            //create an object for DeaCustBLL class
            DeaCustBLL dc = new DeaCustBLL();
            //create a database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //create a dtatable to hold the value temporarily
            DataTable dt = new DataTable();

            try
            {
                //write a query to search deale or customer based on keywords
                string sql = "SELECT name, email, contact, address FROM tbl_dea_cust WHERE id LIKE '%"+keyword+"%' OR name LIKE '%"+keyword+"%'";

                //create sql data adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                //open the database connection
                conn.Open();

                //transfer the data from sqldata adapter to data table
                adapter.Fill(dt);

                //if we have values on dt we need to save it in deALERcUSTOMER bll
                if (dt.Rows.Count > 0)
                {
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();
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

            return dc;
        }

        #endregion

        #region Method to get ID of the Dealer or Customer according the Name

        public DeaCustBLL GetDeaCustIDFromName(string Name)
        {
            //first create an object of DeaCust BLL and return it
            DeaCustBLL dc = new DeaCustBLL();

            //sql connection creating
            SqlConnection conn = new SqlConnection(myconnstrng);
            //data table to hold the data temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL quary to get id based on Name
                string sql = "SELECT id FROM tbl_dea_cust WHERE name='"+Name+"'";
                //create the SQL data adapter to execute he query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //passing the value from adapter to datatable
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //pass the value from dt to deaCustBLL dc
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dc;
        }
        #endregion
    }
}
