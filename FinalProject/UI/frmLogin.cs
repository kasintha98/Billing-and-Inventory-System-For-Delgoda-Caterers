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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedIn;

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            //checking the login credentials
            bool success = dal.loginCheck(l);
            if (success == true)
            {
                //login successfull
                MessageBox.Show("Login successfull! ");
                loggedIn = l.username;

                //need to open respective form based on user type

                switch (l.user_type)
                {
                    case "Admin":
                        {
                            //display admin dashboard
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            //display user dashboard
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //display error message
                            MessageBox.Show("Invalid user type!");
                        }
                        break;
                }

            }
            else
            {
                //login failed
                MessageBox.Show("Login failed! Try again!");
            }
        }

        private void lblUserType_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close this form
            this.Close();
        }
    }
}
