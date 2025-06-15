namespace HumanResorce
{
    partial class HR_MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HR_MainForm));
            panelMenu = new Panel();
            btnManageReport = new FontAwesome.Sharp.IconButton();
            btnSalary = new FontAwesome.Sharp.IconButton();
            btnSignOut = new FontAwesome.Sharp.IconButton();
            btnLeaveRequest = new FontAwesome.Sharp.IconButton();
            btnAttendence = new FontAwesome.Sharp.IconButton();
            btnManageEmployee = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnMenu = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            btnDashBoard = new FontAwesome.Sharp.IconButton();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            btnMaximize = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelDesktop = new Panel();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.MenuHighlight;
            panelMenu.Controls.Add(btnManageReport);
            panelMenu.Controls.Add(btnSalary);
            panelMenu.Controls.Add(btnSignOut);
            panelMenu.Controls.Add(btnLeaveRequest);
            panelMenu.Controls.Add(btnAttendence);
            panelMenu.Controls.Add(btnManageEmployee);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(230, 561);
            panelMenu.TabIndex = 0;
            // 
            // btnManageReport
            // 
            btnManageReport.Dock = DockStyle.Top;
            btnManageReport.FlatAppearance.BorderSize = 0;
            btnManageReport.FlatStyle = FlatStyle.Flat;
            btnManageReport.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageReport.ForeColor = Color.White;
            btnManageReport.IconChar = FontAwesome.Sharp.IconChar.SheetPlastic;
            btnManageReport.IconColor = Color.White;
            btnManageReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageReport.IconSize = 30;
            btnManageReport.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageReport.Location = new Point(0, 340);
            btnManageReport.Name = "btnManageReport";
            btnManageReport.Padding = new Padding(10, 0, 0, 0);
            btnManageReport.Size = new Size(230, 60);
            btnManageReport.TabIndex = 7;
            btnManageReport.Tag = "HR Report";
            btnManageReport.Text = "HR Report";
            btnManageReport.TextAlign = ContentAlignment.MiddleLeft;
            btnManageReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageReport.UseVisualStyleBackColor = true;
            btnManageReport.Click += btnManageReport_Click;
            // 
            // btnSalary
            // 
            btnSalary.Dock = DockStyle.Top;
            btnSalary.FlatAppearance.BorderSize = 0;
            btnSalary.FlatStyle = FlatStyle.Flat;
            btnSalary.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalary.ForeColor = Color.White;
            btnSalary.IconChar = FontAwesome.Sharp.IconChar.Poll;
            btnSalary.IconColor = Color.White;
            btnSalary.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalary.IconSize = 30;
            btnSalary.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalary.Location = new Point(0, 280);
            btnSalary.Name = "btnSalary";
            btnSalary.Padding = new Padding(10, 0, 0, 0);
            btnSalary.Size = new Size(230, 60);
            btnSalary.TabIndex = 6;
            btnSalary.Tag = "Salary Payment";
            btnSalary.Text = "Salary Payment";
            btnSalary.TextAlign = ContentAlignment.MiddleLeft;
            btnSalary.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalary.UseVisualStyleBackColor = true;
            btnSalary.Click += btnSalary_Click;
            // 
            // btnSignOut
            // 
            btnSignOut.Dock = DockStyle.Bottom;
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignOut.ForeColor = Color.White;
            btnSignOut.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnSignOut.IconColor = Color.White;
            btnSignOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSignOut.IconSize = 30;
            btnSignOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnSignOut.Location = new Point(0, 501);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Padding = new Padding(10, 0, 0, 0);
            btnSignOut.Size = new Size(230, 60);
            btnSignOut.TabIndex = 5;
            btnSignOut.Tag = "Sign Out";
            btnSignOut.Text = "   Sign Out";
            btnSignOut.TextAlign = ContentAlignment.MiddleLeft;
            btnSignOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSignOut.UseVisualStyleBackColor = true;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // btnLeaveRequest
            // 
            btnLeaveRequest.Dock = DockStyle.Top;
            btnLeaveRequest.FlatAppearance.BorderSize = 0;
            btnLeaveRequest.FlatStyle = FlatStyle.Flat;
            btnLeaveRequest.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLeaveRequest.ForeColor = Color.White;
            btnLeaveRequest.IconChar = FontAwesome.Sharp.IconChar.BuildingUser;
            btnLeaveRequest.IconColor = Color.White;
            btnLeaveRequest.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLeaveRequest.IconSize = 30;
            btnLeaveRequest.ImageAlign = ContentAlignment.MiddleLeft;
            btnLeaveRequest.Location = new Point(0, 220);
            btnLeaveRequest.Name = "btnLeaveRequest";
            btnLeaveRequest.Padding = new Padding(10, 0, 0, 0);
            btnLeaveRequest.Size = new Size(230, 60);
            btnLeaveRequest.TabIndex = 4;
            btnLeaveRequest.Tag = "Leave Request";
            btnLeaveRequest.Text = "Leave Request";
            btnLeaveRequest.TextAlign = ContentAlignment.MiddleLeft;
            btnLeaveRequest.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLeaveRequest.UseVisualStyleBackColor = true;
            btnLeaveRequest.Click += btnLeaveRequest_Click;
            // 
            // btnAttendence
            // 
            btnAttendence.Dock = DockStyle.Top;
            btnAttendence.FlatAppearance.BorderSize = 0;
            btnAttendence.FlatStyle = FlatStyle.Flat;
            btnAttendence.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAttendence.ForeColor = Color.White;
            btnAttendence.IconChar = FontAwesome.Sharp.IconChar.UserClock;
            btnAttendence.IconColor = Color.White;
            btnAttendence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAttendence.IconSize = 30;
            btnAttendence.ImageAlign = ContentAlignment.MiddleLeft;
            btnAttendence.Location = new Point(0, 160);
            btnAttendence.Name = "btnAttendence";
            btnAttendence.Padding = new Padding(10, 0, 0, 0);
            btnAttendence.Size = new Size(230, 60);
            btnAttendence.TabIndex = 3;
            btnAttendence.Tag = "Daily Attendence";
            btnAttendence.Text = "Daily Attendence";
            btnAttendence.TextAlign = ContentAlignment.MiddleLeft;
            btnAttendence.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAttendence.UseVisualStyleBackColor = true;
            btnAttendence.Click += btnAttendence_Click;
            // 
            // btnManageEmployee
            // 
            btnManageEmployee.Dock = DockStyle.Top;
            btnManageEmployee.FlatAppearance.BorderSize = 0;
            btnManageEmployee.FlatStyle = FlatStyle.Flat;
            btnManageEmployee.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageEmployee.ForeColor = Color.White;
            btnManageEmployee.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            btnManageEmployee.IconColor = Color.White;
            btnManageEmployee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageEmployee.IconSize = 30;
            btnManageEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageEmployee.Location = new Point(0, 100);
            btnManageEmployee.Name = "btnManageEmployee";
            btnManageEmployee.Padding = new Padding(10, 0, 0, 0);
            btnManageEmployee.Size = new Size(230, 60);
            btnManageEmployee.TabIndex = 2;
            btnManageEmployee.Tag = "Manage Employee";
            btnManageEmployee.Text = "Manage Employee";
            btnManageEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnManageEmployee.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageEmployee.UseVisualStyleBackColor = true;
            btnManageEmployee.Click += btnManageEmployee_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 100);
            panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            btnMenu.IconColor = Color.White;
            btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenu.IconSize = 30;
            btnMenu.Location = new Point(159, 21);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(68, 64);
            btnMenu.TabIndex = 1;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.White;
            panelTitleBar.Controls.Add(btnDashBoard);
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Controls.Add(btnMaximize);
            panelTitleBar.Controls.Add(btnClose);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(230, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(904, 60);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // btnDashBoard
            // 
            btnDashBoard.BackColor = Color.White;
            btnDashBoard.Dock = DockStyle.Left;
            btnDashBoard.FlatAppearance.BorderSize = 0;
            btnDashBoard.FlatStyle = FlatStyle.Flat;
            btnDashBoard.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashBoard.ForeColor = Color.Black;
            btnDashBoard.IconChar = FontAwesome.Sharp.IconChar.House;
            btnDashBoard.IconColor = Color.Black;
            btnDashBoard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashBoard.IconSize = 30;
            btnDashBoard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashBoard.Location = new Point(0, 0);
            btnDashBoard.Name = "btnDashBoard";
            btnDashBoard.Padding = new Padding(10, 0, 0, 0);
            btnDashBoard.Size = new Size(166, 60);
            btnDashBoard.TabIndex = 7;
            btnDashBoard.Tag = "";
            btnDashBoard.Text = "   DASHBOARD";
            btnDashBoard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashBoard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashBoard.UseVisualStyleBackColor = false;
            btnDashBoard.Click += btnDashBoard_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.Turquoise;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimize.IconColor = Color.White;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimize.IconSize = 20;
            btnMinimize.Location = new Point(785, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 20);
            btnMinimize.TabIndex = 6;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.BackColor = Color.DodgerBlue;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkAlt;
            btnMaximize.IconColor = Color.White;
            btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximize.IconSize = 20;
            btnMaximize.Location = new Point(825, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(40, 20);
            btnMaximize.TabIndex = 5;
            btnMaximize.UseVisualStyleBackColor = false;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.HotPink;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 20;
            btnClose.Location = new Point(864, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 20);
            btnClose.TabIndex = 3;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(230, 60);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(904, 501);
            panelDesktop.TabIndex = 2;
            // 
            // HR_MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 561);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Name = "HR_MainForm";
            Text = "HR_MainForm";
            Load += HRMainForm_Load;
            Resize += HR_MainForm_Resize;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnLeaveRequest;
        private FontAwesome.Sharp.IconButton btnAttendence;
        private FontAwesome.Sharp.IconButton btnManageEmployee;
        private FontAwesome.Sharp.IconButton btnSignOut;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnDashBoard;
        private FontAwesome.Sharp.IconButton btnSalary;
        private FontAwesome.Sharp.IconButton btnManageReport;
    }
}