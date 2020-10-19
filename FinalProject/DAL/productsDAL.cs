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
    class productsDAL
    {
        //creating static string method for database connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method for products

        public DataTable Select()
        {
            //create sql connection to connect database
            SqlConnection conn = new SqlConnection(myconnstrng);

            //datatable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //writing the query to select all the products from database
                String sql = "SELECT * From tbl_products";

                //creating sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql dataadapter to hold the value from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open database connection
                conn.Open();

                //fill data into datatable
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

        #region Insert Method for Products

        public bool Insert(productsBLL p)
        {
            //creating boolean variable and set its default value to false
            bool isSuccess = false;

            //sql connection to database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //sql query to insert products in to database
                String sql = "INSERT INTO tbl_products (name, category, description, rate, qty, added_date, added_by) VALUES (@name, @category, @description, @rate, @qty, @added_date, @added_by)";

                //create sql command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //passing the value through parameters
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);

                //open the databse connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query is executed success then the value of rows is greater than 0 else less tham 0
                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //query executing failed
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

        #region Update Method for products
        public bool Update(productsBLL p)
        {
            //create a boolean variable and set the inisiatial value to false
            bool isSuccess = false;

            //create sql connection for database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //sql query to update databse
                string sql = "UPDATE tbl_products SET name=@name, category=@category, description=@description, rate=@rate, added_date=@added_date, added_by=@added_by WHERE id=@id";

                //create sql command to pass the value to query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing the value using parameters and cmd
                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@qty", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);
                cmd.Parameters.AddWithValue("@id", p.id);

                //open the database connection
                conn.Open();

                //create int variable to check is query is executed successfully or not
                int rows = cmd.ExecuteNonQuery();
                //if query executed successfully then rows are greater than 0 else less than 0
                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //query execution fails
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

        #region Delete Method for products

        public bool Delete(productsBLL p)
        {
            //create boolean variable and set its defaut value to false
            bool isSuccess = false;

            //sql connection for db connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //write query to  delete product from database
                String sql = "DELETE FROM tbl_products WHERE id=@id";

                //executing the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //passing the values using cmd
                cmd.Parameters.AddWithValue("@id", p.id);

                //open database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query is executed successfully then the value of rows will be greater than 0 else less than 0
                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
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

        #region Search Method for Products

        public DataTable Search(string keywords)
        {
            //SQL connection for db connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //creating datatable to hold data from dtabase
            DataTable dt = new DataTable();

            try
            {
                //sql query to search the product
                String sql = "SELECT * FROM tbl_products WHERE id LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' OR category LIKE '%" + keywords + "%' ";
                //for executing sql command
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
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        #endregion

        #region Search and data fill Method to search product in Transaction

        public productsBLL GetProductsForTransaction(string keyword)
        {
            //create an object of productsBLL 
            productsBLL p = new productsBLL();
            //sql connection creating
            SqlConnection conn = new SqlConnection(myconnstrng);
            //datatable to store data temporery
            DataTable dt = new DataTable();

            try
            {
                //write the query to get the details
                string sql = "SELECT name, rate, qty FROM tbl_products WHERE id LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";
                //create sql data adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //open database connection
                conn.Open();

                //pass the value from adapter to dt
                adapter.Fill(dt);

                //if we have any values on dt then set the values to productsBLL
                if (dt.Rows.Count > 0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close the database connection
                conn.Close();
            }

            return p;
        }

        #endregion

        #region Method to get Product ID based on product name

        public productsBLL GetProductIDFromName(string productName)
        {
            //first create an object of DeaCust BLL and return it
            productsBLL p = new productsBLL();

            //sql connection creating
            SqlConnection conn = new SqlConnection(myconnstrng);
            //data table to hold the data temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL quary to get id based on Name
                string sql = "SELECT id FROM tbl_products WHERE name='" + productName + "'";
                //create the SQL data adapter to execute he query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //passing the value from adapter to datatable
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //pass the value from dt to deaCustBLL dc
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
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


            return p;
        }
        #endregion

        #region Method to get current quantity from database

        public decimal GetProductQty(int ProductID)
        {
            //sql connecion creating
            SqlConnection conn = new SqlConnection(myconnstrng);
            //create a decimal  variable to hold qty 
            decimal qty = 0;
            //create dta table to save the data from database temporeryly
            DataTable dt = new DataTable();

            try
            {
                //write sql query to get quantity from  database
                string sql = "SELECT qty FROM tbl_products WHERE id = "+ProductID;
                //create a Sql commad
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create sql data adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //open database connection
                conn.Open();
                //pass the value from data adapter to data table
                adapter.Fill(dt);

                //check if the data table has a value or not
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                }
            }
            catch (Exception ex)
            {
                //show exeception error
                MessageBox.Show(ex.Message);
            }
            finally
            {   //close database connection
                conn.Close();
            }

            return qty;
        }

        #endregion

        #region Method to update quantity

        public bool UpdateQuantity(int ProductID, decimal qty)
        {
            //create a boolean varaiable and set value to false
            bool success = false;

            //sql connection toconnect database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //writing sql query to update qty
                string sql = "UPDATE tbl_products SET qty=@qty WHERE id=@id";

                //create sql command to pass the value into query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //passing the value through parameters
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@id", ProductID);

                //open dtabase connection
                conn.Open();

                //create int variable and check whether query executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //query executed successfully
                    success = true;
                }
                else
                {
                    //failed to execute query
                    success = false;
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close the database connection
                conn.Close();
            }

            return success;
        }

        #endregion

        #region Method to increase products when bought from suppliers

        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {
            //create a boolean variable
            bool success = false;

            //create sql connection to the database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //get the current quantity from database based on id
                decimal currentQty = GetProductQty(ProductID);

                //Increase the current qty by the qty purchased from the suppliers
                decimal newQty = currentQty + IncreaseQty;

                //updating the product qty
                success = UpdateQuantity(ProductID, newQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        #endregion

        #region Method to decrease product

        public bool DecreaseProduct(int ProductID, decimal Qty)
        {
            //create boolean variable and set its value to false
            bool success = false;
            //creating sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //get the current product quantity
                decimal currentQty = GetProductQty(ProductID);
                //decrese the product qty based on product sales
                decimal NewQty = currentQty - Qty;

                //update product in databse
                success = UpdateQuantity(ProductID, NewQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return success;
        }

        #endregion

        #region Method to Display products based on category

        public DataTable DisplayProductsByCategory(string category)
        {
            //create sql connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //creating a datatable
            DataTable dt = new DataTable();

            try
            {
                //sql query display products product based on category
                string sql = "SELECT * FROM tbl_products WHERE category='"+category+"'";
                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //sql data adapter to  hold the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open database connection
                conn.Open();
                //fill the data in data grid view
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
