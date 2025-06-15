namespace HumanResorce
{
    partial class SignIn
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
            btnSignIn = new Button();
            label3 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            panelMenu = new Panel();
            label1 = new Label();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            btnMaximize = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // btnSignIn
            // 
            btnSignIn.Anchor = AnchorStyles.None;
            btnSignIn.BackColor = Color.LightGray;
            btnSignIn.FlatStyle = FlatStyle.Popup;
            btnSignIn.ForeColor = SystemColors.ControlText;
            btnSignIn.Location = new Point(182, 445);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(228, 80);
            btnSignIn.TabIndex = 10;
            btnSignIn.Text = "SIGN-IN";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = SystemColors.HighlightText;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(217, 86);
            label3.Name = "label3";
            label3.Size = new Size(126, 38);
            label3.TabIndex = 6;
            label3.Text = "SIGN-IN";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.None;
            txtUserName.Location = new Point(169, 261);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(324, 27);
            txtUserName.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Location = new Point(169, 343);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(324, 27);
            txtPassword.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.HighlightText;
            label2.Font = new Font("Segoe UI", 10.8F);
            label2.Location = new Point(18, 345);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 7;
            label2.Text = "PASSWORD";
            // 
            // panelMenu
            // 
            panelMenu.Anchor = AnchorStyles.None;
            panelMenu.BackColor = SystemColors.ButtonHighlight;
            panelMenu.Controls.Add(label3);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(label2);
            panelMenu.Controls.Add(txtPassword);
            panelMenu.Controls.Add(txtUserName);
            panelMenu.Controls.Add(btnSignIn);
            panelMenu.Location = new Point(172, 32);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(551, 646);
            panelMenu.TabIndex = 11;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.HighlightText;
            label1.Font = new Font("Segoe UI", 10.8F);
            label1.Location = new Point(18, 263);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 5;
            label1.Text = "USERNAME";
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
            btnMinimize.Location = new Point(796, 0);
            btnMinimize.Margin = new Padding(3, 4, 3, 4);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(46, 27);
            btnMinimize.TabIndex = 14;
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
            btnMaximize.Location = new Point(842, 0);
            btnMaximize.Margin = new Padding(3, 4, 3, 4);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(46, 27);
            btnMaximize.TabIndex = 13;
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
            btnClose.Location = new Point(886, 0);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 27);
            btnClose.TabIndex = 12;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(934, 713);
            Controls.Add(btnMinimize);
            Controls.Add(btnMaximize);
            Controls.Add(btnClose);
            Controls.Add(panelMenu);
            Name = "SignIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSignIn;
        private Label label3;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Label label2;
        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnClose;
        private Label label1;
    }
}