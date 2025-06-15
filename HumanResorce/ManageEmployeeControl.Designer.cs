namespace HumanResorce
{
    partial class ManageEmployeeControl
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
            textBox1 = new TextBox();
            txtName = new TextBox();
            textBox4 = new TextBox();
            textBox6 = new TextBox();
            txtEmail = new TextBox();
            textBox8 = new TextBox();
            textBox10 = new TextBox();
            txtPhone = new TextBox();
            textBox12 = new TextBox();
            textBox14 = new TextBox();
            dtpStartDate = new DateTimePicker();
            cbbGender = new ComboBox();
            cbbDepartment = new ComboBox();
            dgvEmployee = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            DOB = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            Position = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            textBox5 = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            txtPosition = new TextBox();
            textBox13 = new TextBox();
            dtpDOB = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(51, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(45, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "Name";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Location = new Point(136, 80);
            txtName.Name = "txtName";
            txtName.Size = new Size(142, 16);
            txtName.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top;
            textBox4.BackColor = SystemColors.ActiveCaption;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(579, 79);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(45, 16);
            textBox4.TabIndex = 2;
            textBox4.Text = "DOB";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top;
            textBox6.BackColor = SystemColors.ActiveCaption;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(314, 80);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(45, 16);
            textBox6.TabIndex = 4;
            textBox6.Text = "Gender";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Location = new Point(378, 117);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(157, 16);
            txtEmail.TabIndex = 7;
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top;
            textBox8.BackColor = SystemColors.ActiveCaption;
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Location = new Point(314, 117);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(45, 16);
            textBox8.TabIndex = 6;
            textBox8.Text = "Email";
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Top;
            textBox10.BackColor = SystemColors.ActiveCaption;
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Location = new Point(579, 117);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(61, 16);
            textBox10.TabIndex = 8;
            textBox10.Text = "Start Date";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Top;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Location = new Point(136, 118);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(142, 16);
            txtPhone.TabIndex = 11;
            // 
            // textBox12
            // 
            textBox12.Anchor = AnchorStyles.Top;
            textBox12.BackColor = SystemColors.ActiveCaption;
            textBox12.BorderStyle = BorderStyle.None;
            textBox12.Location = new Point(51, 118);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(45, 16);
            textBox12.TabIndex = 10;
            textBox12.Text = "Phone";
            // 
            // textBox14
            // 
            textBox14.Anchor = AnchorStyles.Top;
            textBox14.BackColor = SystemColors.ActiveCaption;
            textBox14.BorderStyle = BorderStyle.None;
            textBox14.Location = new Point(604, 189);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(68, 16);
            textBox14.TabIndex = 12;
            textBox14.Text = "Department";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Top;
            dtpStartDate.Location = new Point(667, 111);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 14;
            // 
            // cbbGender
            // 
            cbbGender.Anchor = AnchorStyles.Top;
            cbbGender.FormattingEnabled = true;
            cbbGender.Location = new Point(378, 77);
            cbbGender.Name = "cbbGender";
            cbbGender.Size = new Size(157, 23);
            cbbGender.TabIndex = 15;
            // 
            // cbbDepartment
            // 
            cbbDepartment.Anchor = AnchorStyles.Top;
            cbbDepartment.FormattingEnabled = true;
            cbbDepartment.Location = new Point(678, 186);
            cbbDepartment.Name = "cbbDepartment";
            cbbDepartment.Size = new Size(189, 23);
            cbbDepartment.TabIndex = 16;
            // 
            // dgvEmployee
            // 
            dgvEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Columns.AddRange(new DataGridViewColumn[] { Name, DOB, Gender, Position, Email, Phone, StartDate, Department });
            dgvEmployee.Location = new Point(32, 233);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.Size = new Size(835, 182);
            dgvEmployee.TabIndex = 17;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.Name = "Name";
            // 
            // DOB
            // 
            DOB.HeaderText = "DOB";
            DOB.Name = "DOB";
            // 
            // Gender
            // 
            Gender.HeaderText = "Gender";
            Gender.Name = "Gender";
            // 
            // Position
            // 
            Position.HeaderText = "Position";
            Position.Name = "Position";
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.Name = "Email";
            // 
            // Phone
            // 
            Phone.HeaderText = "Phone";
            Phone.Name = "Phone";
            // 
            // StartDate
            // 
            StartDate.HeaderText = "Start Date";
            StartDate.Name = "StartDate";
            // 
            // Department
            // 
            Department.HeaderText = "Department";
            Department.Name = "Department";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.BackColor = SystemColors.ActiveCaption;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(371, 12);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(213, 28);
            textBox5.TabIndex = 18;
            textBox5.Text = "MANAGE EMPLOYEE";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Location = new Point(699, 447);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.Location = new Point(604, 447);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(792, 447);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClear.Location = new Point(509, 447);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 22;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtPosition
            // 
            txtPosition.Anchor = AnchorStyles.Top;
            txtPosition.BorderStyle = BorderStyle.None;
            txtPosition.Location = new Point(136, 159);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(142, 16);
            txtPosition.TabIndex = 24;
            // 
            // textBox13
            // 
            textBox13.Anchor = AnchorStyles.Top;
            textBox13.BackColor = SystemColors.ActiveCaption;
            textBox13.BorderStyle = BorderStyle.None;
            textBox13.Location = new Point(51, 159);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(45, 16);
            textBox13.TabIndex = 23;
            textBox13.Text = "Position";
            // 
            // dtpDOB
            // 
            dtpDOB.Anchor = AnchorStyles.Top;
            dtpDOB.Location = new Point(667, 73);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(200, 23);
            dtpDOB.TabIndex = 25;
            // 
            // ManageEmployeeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(dtpDOB);
            Controls.Add(txtPosition);
            Controls.Add(textBox13);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(textBox5);
            Controls.Add(dgvEmployee);
            Controls.Add(cbbDepartment);
            Controls.Add(cbbGender);
            Controls.Add(dtpStartDate);
            Controls.Add(textBox14);
            Controls.Add(txtPhone);
            Controls.Add(textBox12);
            Controls.Add(textBox10);
            Controls.Add(txtEmail);
            Controls.Add(textBox8);
            Controls.Add(textBox6);
            Controls.Add(textBox4);
            Controls.Add(txtName);
            Controls.Add(textBox1);
            //Name = "ManageEmployeeControl";
            Size = new Size(904, 501);
            Load += ManageEmployeeControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox txtName;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox txtEmail;
        private TextBox textBox8;
        private TextBox textBox10;
        private TextBox txtPhone;
        private TextBox textBox12;
        private TextBox textBox14;
        private DateTimePicker dtpStartDate;
        private ComboBox cbbGender;
        private ComboBox cbbDepartment;
        private DataGridView dgvEmployee;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn DOB;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn Position;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn Department;
        private TextBox textBox5;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnClear;
        private TextBox txtPosition;
        private TextBox textBox13;
        private DateTimePicker dtpDOB;
    }
}
