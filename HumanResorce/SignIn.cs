using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResorce
{
    public partial class SignIn : Form
    {
        private int borderSize = 2;
        public SignIn()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_NCHITTEST = 0x0084; // Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form
            const int resizeAreaSize = 10;

            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1;           // Represents the client area of the window
            const int HTLEFT = 10;            // Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11;           // Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;             // Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;         // Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;        // Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15;          // Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;      // Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;     // Lower-right corner of a window border, allows resize diagonally to the right

            if (m.Msg == WM_NCHITTEST)
            {
                // If the windows m is WM_NCHITTEST
                base.WndProc(ref m);

                if (this.WindowState == FormWindowState.Normal) // Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT) // If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point((int)m.LParam); // Gets screen point coordinates (X and Y coordinate of the pointer)
                        Point clientPoint = this.PointToClient(screenPoint); // Computes the location of the screen point into client coordinates

                        if (clientPoint.Y <= resizeAreaSize) // If the pointer is at the top of the form (within the resize area - X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) // Top-left corner
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (clientPoint.X >= this.Size.Width - resizeAreaSize) // Top-right corner
                                m.Result = (IntPtr)HTTOPRIGHT;
                            else // Top border
                                m.Result = (IntPtr)HTTOP;
                        }
                        else if (clientPoint.Y >= this.Size.Height - resizeAreaSize) // Bottom area
                        {
                            if (clientPoint.X <= resizeAreaSize) // Bottom-left corner
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X >= this.Size.Width - resizeAreaSize) // Bottom-right corner
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                            else // Bottom border
                                m.Result = (IntPtr)HTBOTTOM;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize) // Left border
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X >= this.Size.Width - resizeAreaSize) // Right border
                                m.Result = (IntPtr)HTRIGHT;
                        }
                    }
                }

                return;
            }

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                                    directorForm.Show(); 
                                    MessageBox.Show($"Sign-in success! Welcome {username}.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
