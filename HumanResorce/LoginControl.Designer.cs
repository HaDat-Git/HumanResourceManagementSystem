namespace HumanResorce
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnSignIn = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F);
            label1.Location = new Point(284, 222);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 0;
            label1.Text = "USERNAME";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F);
            label2.Location = new Point(284, 304);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 1;
            label2.Text = "PASSWORD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(510, 83);
            label3.Name = "label3";
            label3.Size = new Size(126, 38);
            label3.TabIndex = 0;
            label3.Text = "SIGN-IN";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(435, 220);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(324, 27);
            txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(435, 302);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(324, 27);
            txtPassword.TabIndex = 2;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.LightGray;
            btnSignIn.FlatStyle = FlatStyle.Popup;
            btnSignIn.ForeColor = SystemColors.ControlText;
            btnSignIn.Location = new Point(503, 603);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(228, 80);
            btnSignIn.TabIndex = 4;
            btnSignIn.Text = "SIGN-IN";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HighlightText;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(34, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(1143, 479);
            panel1.TabIndex = 5;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSignIn);
            Controls.Add(panel1);
            Name = "LoginControl";
            Size = new Size(1342, 773);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnSignIn;
        private Panel panel1;
    }
}
