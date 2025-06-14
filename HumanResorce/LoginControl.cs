using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResorce
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your Username and Password.!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Server=KHANHAYHO\SQLEXPRESS01;Database=humanresource;Trusted_Connection=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT UserID, Role FROM [User] WHERE UserName = @username AND PassWord = @password";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);


                    using (SqlDataReader result = cmd.ExecuteReader())
                    {
                        if (result.Read())
                        {
                            string role = result["Role"].ToString();
                            if (role == "HR")
                            {
                               


                                Form mainForm = this.FindForm();
                                if (mainForm != null)
                                {
                                    mainForm.Hide();
                                    HR_MainForm HRmainForm = new HR_MainForm();
                                    HRmainForm.Show();
                                    MessageBox.Show($"Sign-in success! Welcome {username}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            else if (role == "Director")
                            {

                               
                                Form mainForm = this.FindForm();
                                if (mainForm != null)
                                {
                                    mainForm.Hide(); // Ẩn MainForm
                                    Director_MainForm directorForm = new Director_MainForm();
                                    directorForm.Show(); MessageBox.Show($"Sign-in success! Welcome {username}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("INVALID ROLE!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username or Password is incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
