namespace HumanResorce
{
    partial class LeaveRequestControl
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
            txtID = new TextBox();
            txtName = new TextBox();
            textBox4 = new TextBox();
            textBox6 = new TextBox();
            textBox8 = new TextBox();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            textBox5 = new TextBox();
            ckYes = new CheckBox();
            ckNo = new CheckBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            rtbNote = new RichTextBox();
            textBox2 = new TextBox();
            dgvLeaveRequest = new DataGridView();
            cbbStatus = new ComboBox();
            textBox3 = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            txtReason = new TextBox();
            textBox11 = new TextBox();
            txtIDSearch = new TextBox();
            textBox12 = new TextBox();
            dtpStartDateSearch = new DateTimePicker();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveRequest).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(46, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(72, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "Employee ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.BorderStyle = BorderStyle.None;
            txtID.Location = new Point(144, 61);
            txtID.Name = "txtID";
            txtID.Size = new Size(122, 16);
            txtID.TabIndex = 1;
            txtID.Leave += txtID_Leave;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Location = new Point(144, 112);
            txtName.Name = "txtName";
            txtName.Size = new Size(168, 16);
            txtName.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top;
            textBox4.BackColor = SystemColors.ActiveCaption;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(46, 112);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(92, 16);
            textBox4.TabIndex = 2;
            textBox4.Text = "Employee Name";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top;
            textBox6.BackColor = SystemColors.ActiveCaption;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(341, 109);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(58, 16);
            textBox6.TabIndex = 4;
            textBox6.Text = "End Date";
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top;
            textBox8.BackColor = SystemColors.ActiveCaption;
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Location = new Point(341, 56);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(63, 16);
            textBox8.TabIndex = 6;
            textBox8.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Top;
            dtpEndDate.Location = new Point(405, 105);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 7;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Top;
            dtpStartDate.Location = new Point(405, 53);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.BackColor = SystemColors.ActiveCaption;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(640, 60);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(50, 16);
            textBox5.TabIndex = 9;
            textBox5.Text = "Approve";
            // 
            // ckYes
            // 
            ckYes.Anchor = AnchorStyles.Top;
            ckYes.AutoSize = true;
            ckYes.Location = new Point(724, 59);
            ckYes.Name = "ckYes";
            ckYes.Size = new Size(43, 19);
            ckYes.TabIndex = 10;
            ckYes.Text = "Yes";
            ckYes.UseVisualStyleBackColor = true;
            ckYes.CheckedChanged += ckYes_CheckedChanged;
            // 
            // ckNo
            // 
            ckNo.Anchor = AnchorStyles.Top;
            ckNo.AutoSize = true;
            ckNo.Location = new Point(793, 59);
            ckNo.Name = "ckNo";
            ckNo.Size = new Size(42, 19);
            ckNo.TabIndex = 11;
            ckNo.Text = "No";
            ckNo.UseVisualStyleBackColor = true;
            ckNo.CheckedChanged += ckNo_CheckedChanged;
            // 
            // textBox9
            // 
            textBox9.Anchor = AnchorStyles.Top;
            textBox9.BackColor = SystemColors.ActiveCaption;
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.Location = new Point(640, 162);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(50, 16);
            textBox9.TabIndex = 12;
            textBox9.Text = "Status";
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Top;
            textBox10.BackColor = SystemColors.ActiveCaption;
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Location = new Point(46, 159);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(42, 16);
            textBox10.TabIndex = 14;
            textBox10.Text = "Note";
            // 
            // rtbNote
            // 
            rtbNote.Anchor = AnchorStyles.Top;
            rtbNote.BorderStyle = BorderStyle.None;
            rtbNote.Location = new Point(144, 159);
            rtbNote.Name = "rtbNote";
            rtbNote.Size = new Size(461, 57);
            rtbNote.TabIndex = 15;
            rtbNote.Text = "";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top;
            textBox2.BackColor = SystemColors.ActiveCaption;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(318, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(263, 28);
            textBox2.TabIndex = 16;
            textBox2.Text = "MANAGE LEAVE REQUEST";
            // 
            // dgvLeaveRequest
            // 
            dgvLeaveRequest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLeaveRequest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaveRequest.Location = new Point(32, 275);
            dgvLeaveRequest.Name = "dgvLeaveRequest";
            dgvLeaveRequest.Size = new Size(839, 171);
            dgvLeaveRequest.TabIndex = 17;
            dgvLeaveRequest.CellClick += dgvLeaveRequest_CellClick;
            // 
            // cbbStatus
            // 
            cbbStatus.Anchor = AnchorStyles.Top;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(696, 159);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(175, 23);
            cbbStatus.TabIndex = 18;
            cbbStatus.SelectedIndexChanged += cbbStatus_SelectedIndexChanged;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox3.BackColor = SystemColors.ActiveCaption;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(522, 251);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(59, 16);
            textBox3.TabIndex = 19;
            textBox3.Text = "Start Date";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(793, 463);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(78, 24);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.Location = new Point(619, 463);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 24);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Location = new Point(705, 463);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(71, 24);
            btnUpdate.TabIndex = 23;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtReason
            // 
            txtReason.Anchor = AnchorStyles.Top;
            txtReason.BorderStyle = BorderStyle.None;
            txtReason.Location = new Point(696, 109);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(175, 16);
            txtReason.TabIndex = 25;
            // 
            // textBox11
            // 
            textBox11.Anchor = AnchorStyles.Top;
            textBox11.BackColor = SystemColors.ActiveCaption;
            textBox11.BorderStyle = BorderStyle.None;
            textBox11.Location = new Point(637, 108);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(41, 16);
            textBox11.TabIndex = 24;
            textBox11.Text = "Reason";
            // 
            // txtIDSearch
            // 
            txtIDSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtIDSearch.BorderStyle = BorderStyle.None;
            txtIDSearch.Location = new Point(470, 251);
            txtIDSearch.Name = "txtIDSearch";
            txtIDSearch.Size = new Size(46, 16);
            txtIDSearch.TabIndex = 27;
            txtIDSearch.TextChanged += txtIDSearch_TextChanged;
            // 
            // textBox12
            // 
            textBox12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox12.BackColor = SystemColors.ActiveCaption;
            textBox12.BorderStyle = BorderStyle.None;
            textBox12.Location = new Point(392, 251);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(72, 16);
            textBox12.TabIndex = 26;
            textBox12.Text = "Employee ID";
            // 
            // dtpStartDateSearch
            // 
            dtpStartDateSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpStartDateSearch.Location = new Point(587, 246);
            dtpStartDateSearch.Name = "dtpStartDateSearch";
            dtpStartDateSearch.Size = new Size(200, 23);
            dtpStartDateSearch.TabIndex = 28;
            dtpStartDateSearch.ValueChanged += dtpStartDateSearch_ValueChanged;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReset.Location = new Point(801, 247);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(70, 24);
            btnReset.TabIndex = 29;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // LeaveRequestControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnReset);
            Controls.Add(dtpStartDateSearch);
            Controls.Add(txtIDSearch);
            Controls.Add(textBox12);
            Controls.Add(txtReason);
            Controls.Add(textBox11);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(textBox3);
            Controls.Add(cbbStatus);
            Controls.Add(dgvLeaveRequest);
            Controls.Add(textBox2);
            Controls.Add(rtbNote);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(ckNo);
            Controls.Add(ckYes);
            Controls.Add(textBox5);
            Controls.Add(dtpStartDate);
            Controls.Add(dtpEndDate);
            Controls.Add(textBox8);
            Controls.Add(textBox6);
            Controls.Add(txtName);
            Controls.Add(textBox4);
            Controls.Add(txtID);
            Controls.Add(textBox1);
            Name = "LeaveRequestControl";
            Size = new Size(904, 501);
            Load += LeaveRequestControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLeaveRequest).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox8;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private TextBox textBox5;
        private CheckBox ckYes;
        private CheckBox ckNo;
        private TextBox textBox9;
        private TextBox textBox10;
        private RichTextBox rtbNote;
        private TextBox textBox2;
        private DataGridView dgvLeaveRequest;
        private ComboBox cbbStatus;
        private TextBox textBox3;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private TextBox txtReason;
        private TextBox textBox11;
        private TextBox txtIDSearch;
        private TextBox textBox12;
        private DateTimePicker dtpStartDateSearch;
        private Button btnReset;
    }
}
