namespace HumanResorce
{
    partial class ManageAttendanceControl
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
            dtpDate = new DateTimePicker();
            textBox5 = new TextBox();
            ckYes = new CheckBox();
            ckNo = new CheckBox();
            txtLateMinute = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            dgvAttendance = new DataGridView();
            textBox9 = new TextBox();
            cbbDepartment = new ComboBox();
            txtTotalHour = new TextBox();
            textBox11 = new TextBox();
            dtpCheckInTime = new DateTimePicker();
            dtpCheckOutTime = new DateTimePicker();
            btnUpdate = new Button();
            btnDelete = new Button();
            textBox12 = new TextBox();
            btnAdd = new Button();
            txtID = new TextBox();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(325, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(42, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "Name";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Location = new Point(423, 59);
            txtName.Name = "txtName";
            txtName.Size = new Size(124, 16);
            txtName.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top;
            textBox4.BackColor = SystemColors.ActiveCaption;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(605, 59);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(42, 16);
            textBox4.TabIndex = 2;
            textBox4.Text = "Date";
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Top;
            dtpDate.Location = new Point(674, 53);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(189, 23);
            dtpDate.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.BackColor = SystemColors.ActiveCaption;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(50, 140);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(42, 16);
            textBox5.TabIndex = 4;
            textBox5.Text = "Late";
            // 
            // ckYes
            // 
            ckYes.Anchor = AnchorStyles.Top;
            ckYes.AutoSize = true;
            ckYes.Location = new Point(151, 139);
            ckYes.Name = "ckYes";
            ckYes.Size = new Size(43, 19);
            ckYes.TabIndex = 5;
            ckYes.Text = "Yes";
            ckYes.UseVisualStyleBackColor = true;
            // 
            // ckNo
            // 
            ckNo.Anchor = AnchorStyles.Top;
            ckNo.AutoSize = true;
            ckNo.Location = new Point(218, 140);
            ckNo.Name = "ckNo";
            ckNo.Size = new Size(42, 19);
            ckNo.TabIndex = 6;
            ckNo.Text = "No";
            ckNo.UseVisualStyleBackColor = true;
            // 
            // txtLateMinute
            // 
            txtLateMinute.Anchor = AnchorStyles.Top;
            txtLateMinute.BorderStyle = BorderStyle.None;
            txtLateMinute.Location = new Point(423, 137);
            txtLateMinute.Name = "txtLateMinute";
            txtLateMinute.Size = new Size(124, 16);
            txtLateMinute.TabIndex = 8;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top;
            textBox6.BackColor = SystemColors.ActiveCaption;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(325, 137);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(72, 16);
            textBox6.TabIndex = 7;
            textBox6.Text = "Late Minutes";
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top;
            textBox7.BackColor = SystemColors.ActiveCaption;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Location = new Point(50, 102);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(83, 16);
            textBox7.TabIndex = 9;
            textBox7.Text = "Check In Time";
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top;
            textBox8.BackColor = SystemColors.ActiveCaption;
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Location = new Point(325, 102);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(92, 16);
            textBox8.TabIndex = 10;
            textBox8.Text = "Check Out Time";
            // 
            // dgvAttendance
            // 
            dgvAttendance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Location = new Point(32, 233);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.Size = new Size(844, 200);
            dgvAttendance.TabIndex = 11;
            dgvAttendance.CellClick += dgvAttendance_CellClick;
            // 
            // textBox9
            // 
            textBox9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox9.BackColor = SystemColors.ActiveCaption;
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.Location = new Point(646, 207);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(71, 16);
            textBox9.TabIndex = 12;
            textBox9.Text = "Department";
            // 
            // cbbDepartment
            // 
            cbbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbbDepartment.FormattingEnabled = true;
            cbbDepartment.Location = new Point(723, 204);
            cbbDepartment.Name = "cbbDepartment";
            cbbDepartment.Size = new Size(153, 23);
            cbbDepartment.TabIndex = 13;
            cbbDepartment.SelectedIndexChanged += cbbDepartment_SelectedIndexChanged;
            // 
            // txtTotalHour
            // 
            txtTotalHour.Anchor = AnchorStyles.Top;
            txtTotalHour.BorderStyle = BorderStyle.None;
            txtTotalHour.Location = new Point(674, 137);
            txtTotalHour.Name = "txtTotalHour";
            txtTotalHour.Size = new Size(124, 16);
            txtTotalHour.TabIndex = 15;
            // 
            // textBox11
            // 
            textBox11.Anchor = AnchorStyles.Top;
            textBox11.BackColor = SystemColors.ActiveCaption;
            textBox11.BorderStyle = BorderStyle.None;
            textBox11.Location = new Point(605, 137);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(72, 16);
            textBox11.TabIndex = 14;
            textBox11.Text = "Total Hours";
            // 
            // dtpCheckInTime
            // 
            dtpCheckInTime.Anchor = AnchorStyles.Top;
            dtpCheckInTime.Location = new Point(144, 97);
            dtpCheckInTime.Name = "dtpCheckInTime";
            dtpCheckInTime.Size = new Size(128, 23);
            dtpCheckInTime.TabIndex = 16;
            // 
            // dtpCheckOutTime
            // 
            dtpCheckOutTime.Anchor = AnchorStyles.Top;
            dtpCheckOutTime.Location = new Point(423, 97);
            dtpCheckOutTime.Name = "dtpCheckOutTime";
            dtpCheckOutTime.Size = new Size(124, 23);
            dtpCheckOutTime.TabIndex = 17;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Location = new Point(801, 457);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.Location = new Point(706, 457);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // textBox12
            // 
            textBox12.Anchor = AnchorStyles.Top;
            textBox12.BackColor = SystemColors.ActiveCaption;
            textBox12.BorderStyle = BorderStyle.None;
            textBox12.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox12.Location = new Point(334, 3);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(242, 28);
            textBox12.TabIndex = 21;
            textBox12.Text = "MANAGE ATTENDANCE";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(615, 457);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.BorderStyle = BorderStyle.None;
            txtID.Location = new Point(144, 58);
            txtID.Name = "txtID";
            txtID.Size = new Size(128, 16);
            txtID.TabIndex = 26;
            txtID.Leave += txtID_Leave;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.BackColor = SystemColors.ActiveCaption;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(50, 58);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(39, 16);
            textBox3.TabIndex = 25;
            textBox3.Text = "ID";
            // 
            // ManageAttendanceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(txtID);
            Controls.Add(textBox3);
            Controls.Add(btnAdd);
            Controls.Add(textBox12);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(dtpCheckOutTime);
            Controls.Add(dtpCheckInTime);
            Controls.Add(txtTotalHour);
            Controls.Add(textBox11);
            Controls.Add(cbbDepartment);
            Controls.Add(textBox9);
            Controls.Add(dgvAttendance);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(txtLateMinute);
            Controls.Add(textBox6);
            Controls.Add(ckNo);
            Controls.Add(ckYes);
            Controls.Add(textBox5);
            Controls.Add(dtpDate);
            Controls.Add(textBox4);
            Controls.Add(txtName);
            Controls.Add(textBox1);
            Name = "ManageAttendanceControl";
            Size = new Size(904, 501);
            Load += ManageAttendanceControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox txtName;
        private TextBox textBox4;
        private DateTimePicker dtpDate;
        private TextBox textBox5;
        private CheckBox ckYes;
        private CheckBox ckNo;
        private TextBox txtLateMinute;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private DataGridView dgvAttendance;
        private TextBox textBox9;
        private ComboBox cbbDepartment;
        private TextBox txtTotalHour;
        private TextBox textBox11;
        private DateTimePicker dtpCheckInTime;
        private DateTimePicker dtpCheckOutTime;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox textBox12;
        private Button btnAdd;
        private TextBox txtID;
        private TextBox textBox3;
    }
}
