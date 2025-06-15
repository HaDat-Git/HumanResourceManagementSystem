namespace HumanResorce
{
    partial class PaymentControl
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
            txtAllowance = new TextBox();
            textBox10 = new TextBox();
            txtBaseSalary = new TextBox();
            textBox12 = new TextBox();
            txtTotal = new TextBox();
            textBox14 = new TextBox();
            textBox5 = new TextBox();
            dgvSalary = new DataGridView();
            btnUpdate = new Button();
            btnReset = new Button();
            cbbYear = new ComboBox();
            cbbMonth = new ComboBox();
            txtTotalHour = new TextBox();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSalary).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(38, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(23, 16);
            textBox1.TabIndex = 0;
            textBox1.Text = "ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.BorderStyle = BorderStyle.None;
            txtID.Location = new Point(81, 59);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 16);
            txtID.TabIndex = 1;
            txtID.Leave += txtID_Leave;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Location = new Point(81, 100);
            txtName.Name = "txtName";
            txtName.Size = new Size(129, 16);
            txtName.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top;
            textBox4.BackColor = SystemColors.ActiveCaption;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(38, 100);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(37, 16);
            textBox4.TabIndex = 2;
            textBox4.Text = "Name";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top;
            textBox6.BackColor = SystemColors.ActiveCaption;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(250, 100);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(37, 16);
            textBox6.TabIndex = 6;
            textBox6.Text = "Year";
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top;
            textBox8.BackColor = SystemColors.ActiveCaption;
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Location = new Point(250, 59);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(37, 16);
            textBox8.TabIndex = 4;
            textBox8.Text = "Month";
            // 
            // txtAllowance
            // 
            txtAllowance.Anchor = AnchorStyles.Top;
            txtAllowance.BorderStyle = BorderStyle.None;
            txtAllowance.Location = new Point(578, 100);
            txtAllowance.Name = "txtAllowance";
            txtAllowance.Size = new Size(100, 16);
            txtAllowance.TabIndex = 11;
            txtAllowance.Leave += PaymentControl_Leave;
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Top;
            textBox10.BackColor = SystemColors.ActiveCaption;
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Location = new Point(491, 100);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(65, 16);
            textBox10.TabIndex = 10;
            textBox10.Text = "Allowance";
            // 
            // txtBaseSalary
            // 
            txtBaseSalary.Anchor = AnchorStyles.Top;
            txtBaseSalary.BorderStyle = BorderStyle.None;
            txtBaseSalary.Location = new Point(578, 59);
            txtBaseSalary.Name = "txtBaseSalary";
            txtBaseSalary.Size = new Size(100, 16);
            txtBaseSalary.TabIndex = 9;
            txtBaseSalary.Leave += txtBaseSalary_Leave;
            // 
            // textBox12
            // 
            textBox12.Anchor = AnchorStyles.Top;
            textBox12.BackColor = SystemColors.ActiveCaption;
            textBox12.BorderStyle = BorderStyle.None;
            textBox12.Location = new Point(491, 59);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(65, 16);
            textBox12.TabIndex = 8;
            textBox12.Text = "Base Salary";
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top;
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Location = new Point(792, 100);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(81, 16);
            txtTotal.TabIndex = 13;
            // 
            // textBox14
            // 
            textBox14.Anchor = AnchorStyles.Top;
            textBox14.BackColor = SystemColors.ActiveCaption;
            textBox14.BorderStyle = BorderStyle.None;
            textBox14.Location = new Point(720, 100);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(38, 16);
            textBox14.TabIndex = 12;
            textBox14.Text = "Total";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top;
            textBox5.BackColor = SystemColors.ActiveCaption;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(351, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(250, 28);
            textBox5.TabIndex = 16;
            textBox5.Text = "MANAGE SALARY TABLE";
            // 
            // dgvSalary
            // 
            dgvSalary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSalary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalary.Location = new Point(38, 166);
            dgvSalary.Name = "dgvSalary";
            dgvSalary.Size = new Size(835, 273);
            dgvSalary.TabIndex = 17;
            dgvSalary.CellClick += dgvSalary_CellClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Location = new Point(808, 454);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(65, 24);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.Location = new Point(729, 454);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(65, 24);
            btnReset.TabIndex = 21;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // cbbYear
            // 
            cbbYear.Anchor = AnchorStyles.Top;
            cbbYear.FormattingEnabled = true;
            cbbYear.Location = new Point(309, 97);
            cbbYear.Name = "cbbYear";
            cbbYear.Size = new Size(144, 23);
            cbbYear.TabIndex = 22;
            cbbYear.SelectedIndexChanged += cbbYear_SelectedIndexChanged;
            // 
            // cbbMonth
            // 
            cbbMonth.Anchor = AnchorStyles.Top;
            cbbMonth.FormattingEnabled = true;
            cbbMonth.Location = new Point(309, 56);
            cbbMonth.Name = "cbbMonth";
            cbbMonth.Size = new Size(144, 23);
            cbbMonth.TabIndex = 23;
            // 
            // txtTotalHour
            // 
            txtTotalHour.Anchor = AnchorStyles.Top;
            txtTotalHour.BorderStyle = BorderStyle.None;
            txtTotalHour.Location = new Point(792, 56);
            txtTotalHour.Name = "txtTotalHour";
            txtTotalHour.Size = new Size(81, 16);
            txtTotalHour.TabIndex = 25;
            txtTotalHour.Leave += txtTotalHour_Leave;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.BackColor = SystemColors.ActiveCaption;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(720, 56);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 16);
            textBox3.TabIndex = 24;
            textBox3.Text = "Total Hour";
            // 
            // PaymentControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(txtTotalHour);
            Controls.Add(textBox3);
            Controls.Add(cbbMonth);
            Controls.Add(cbbYear);
            Controls.Add(btnReset);
            Controls.Add(btnUpdate);
            Controls.Add(dgvSalary);
            Controls.Add(textBox5);
            Controls.Add(txtTotal);
            Controls.Add(textBox14);
            Controls.Add(txtAllowance);
            Controls.Add(textBox10);
            Controls.Add(txtBaseSalary);
            Controls.Add(textBox12);
            Controls.Add(textBox6);
            Controls.Add(textBox8);
            Controls.Add(txtName);
            Controls.Add(textBox4);
            Controls.Add(txtID);
            Controls.Add(textBox1);
            Name = "PaymentControl";
            Size = new Size(904, 501);
            Load += PaymentControl_Load;
            Leave += PaymentControl_Leave;
            ((System.ComponentModel.ISupportInitialize)dgvSalary).EndInit();
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
        private TextBox txtAllowance;
        private TextBox textBox10;
        private TextBox txtBaseSalary;
        private TextBox textBox12;
        private TextBox txtTotal;
        private TextBox textBox14;
        private TextBox textBox5;
        private DataGridView dgvSalary;
        private Button btnUpdate;
        private Button btnReset;
        private ComboBox cbbYear;
        private ComboBox cbbMonth;
        private TextBox txtTotalHour;
        private TextBox textBox3;
    }
}
