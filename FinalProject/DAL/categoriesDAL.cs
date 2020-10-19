using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.BLL;

namespace FinalProject.DAL
{
    class categoriesDAL
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

                string sql = "SELECT * FROM tbl_categories";

                SqlCommand cmd = new SqlCommand(sql, conn);

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

        #region Insert New Category

        public bool Insert(categoriesBLL c)
        {
            //creating a boolean variable variable and set its default value to false
            bool isSucces = false;

            //connection to database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //writing query to add new category
                string sql = "INSERT INTO tbl_categories (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)";
                //creating sql command to pass values
                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing values through parameter
                cmd.Parameters.AddWithValue("@title" , c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by); // -@

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

        public bool Update(categoriesBLL c)
        {
            //creating boolean variable and set its default value to false
            bool isSuccess = false;

            //creating sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //query to update the category
                string sql = "UPDATE tbl_categories SET title=@title, description=@description, added_date=@added_date,added_by=@added_by WHERE id=@id";

                //sql command to pass the value on sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //passing value using cmd
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);

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

        #region Delete category

        public bool Delete(categoriesBLL c)
        {
            //create a boolean variable and set its value to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //sql query to delete from database
                string sql = "DELETE FROM tbl_categories WHERE id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing the value using cmd
                cmd.Parameters.AddWithValue("@id", c.id);

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

        #region Getting user ID from Username
        public userBLL GetIDFromUsername(string username)
        {
            userBLL u = new userBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT id FROM tbl_users WHERE username = '" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());
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
            return u;
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
                String sql = "SELECT * FROM tbl_categories WHERE id LIKE '%"+keywords+"%' OR title LIKE '%"+keywords+"%' OR description LIKE '%"+keywords+"%' ";
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
        }
}
