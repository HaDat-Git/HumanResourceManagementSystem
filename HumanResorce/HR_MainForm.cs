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
    public partial class HR_MainForm : Form
    {
        private int borderSize = 2;
        public HR_MainForm()
        {
            InitializeComponent();
            CollapseMenu();
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

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void HR_MainForm_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;

                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200)
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag;
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void HRMainForm_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            panelDesktop.Controls.Clear(); // Xóa control hiện tại trong panel nếu có

            DashBoardControl dashboard = new DashBoardControl();
            dashboard.Dock = DockStyle.Fill; // Fill toàn bộ panel
            panelDesktop.Controls.Add(dashboard);
        }
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel chứa giao diện đăng nhập/đăng ký
            panelDesktop.Visible = true;

            // Xóa các Control cũ trong Panel (nếu có)
            panelDesktop.Controls.Clear();

            // Khởi tạo Form đăng nhập
            DashBoardControl login = new DashBoardControl();
            login.Dock = DockStyle.Fill; // Để căn chỉnh toàn Panel

            // Thêm vào Panel
            panelDesktop.Controls.Add(login);
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel chứa giao diện đăng nhập/đăng ký
            panelDesktop.Visible = true;

            // Xóa các Control cũ trong Panel (nếu có)
            panelDesktop.Controls.Clear();

            // Khởi tạo Form đăng nhập
            ManageEmployeeControl login = new ManageEmployeeControl();
            login.Dock = DockStyle.Fill; // Để căn chỉnh toàn Panel

            // Thêm vào Panel
            panelDesktop.Controls.Add(login);
        }

        private void btnAttendence_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel chứa giao diện đăng nhập/đăng ký
            panelDesktop.Visible = true;

            // Xóa các Control cũ trong Panel (nếu có)
            panelDesktop.Controls.Clear();

            // Khởi tạo Form đăng nhập
            ManageAttendanceControl login = new ManageAttendanceControl();
            login.Dock = DockStyle.Fill; // Để căn chỉnh toàn Panel

            // Thêm vào Panel
            panelDesktop.Controls.Add(login);
        }

        private void btnLeaveRequest_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel chứa giao diện đăng nhập/đăng ký
            panelDesktop.Visible = true;

            // Xóa các Control cũ trong Panel (nếu có)
            panelDesktop.Controls.Clear();

            // Khởi tạo Form đăng nhập
            LeaveRequestControl login = new LeaveRequestControl();
            login.Dock = DockStyle.Fill; // Để căn chỉnh toàn Panel

            // Thêm vào Panel
            panelDesktop.Controls.Add(login);
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();

            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel chứa giao diện đăng nhập/đăng ký
            panelDesktop.Visible = true;

            // Xóa các Control cũ trong Panel (nếu có)
            panelDesktop.Controls.Clear();

            // Khởi tạo Form đăng nhập
            PaymentControl login = new PaymentControl();
            login.Dock = DockStyle.Fill; // Để căn chỉnh toàn Panel

            // Thêm vào Panel
            panelDesktop.Controls.Add(login);
        }

        private void btnManageReport_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel chứa giao diện đăng nhập/đăng ký
            panelDesktop.Visible = true;

            // Xóa các Control cũ trong Panel (nếu có)
            panelDesktop.Controls.Clear();

            // Khởi tạo Form đăng nhập
            ReportControl login = new ReportControl();
            login.Dock = DockStyle.Fill; // Để căn chỉnh toàn Panel

            // Thêm vào Panel
            panelDesktop.Controls.Add(login);
        }
    }
}
