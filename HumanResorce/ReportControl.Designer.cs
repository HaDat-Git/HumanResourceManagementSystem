namespace HumanResorce
{
    partial class ReportControl
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
            dgvReport = new DataGridView();
            textBox1 = new TextBox();
            cbbDepartment = new ComboBox();
            cbbMonth = new ComboBox();
            textBox2 = new TextBox();
            cbbYear = new ComboBox();
            textBox3 = new TextBox();
            textBox10 = new TextBox();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // dgvReport
            // 
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(38, 157);
            dgvReport.Name = "dgvReport";
            dgvReport.Size = new Size(831, 266);
            dgvReport.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(68, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(70, 16);
            textBox1.TabIndex = 1;
            textBox1.Text = "Department";
            // 
            // cbbDepartment
            // 
            cbbDepartment.Anchor = AnchorStyles.Top;
            cbbDepartment.FormattingEnabled = true;
            cbbDepartment.Location = new Point(144, 83);
            cbbDepartment.Name = "cbbDepartment";
            cbbDepartment.Size = new Size(121, 23);
            cbbDepartment.TabIndex = 2;
            cbbDepartment.SelectedIndexChanged += cbbDepartment_SelectedIndexChanged;
            // 
            // cbbMonth
            // 
            cbbMonth.Anchor = AnchorStyles.Top;
            cbbMonth.FormattingEnabled = true;
            cbbMonth.Location = new Point(437, 83);
            cbbMonth.Name = "cbbMonth";
            cbbMonth.Size = new Size(121, 23);
            cbbMonth.TabIndex = 4;
            cbbMonth.SelectedIndexChanged += cbbMonth_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top;
            textBox2.BackColor = SystemColors.ActiveCaption;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(382, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(42, 16);
            textBox2.TabIndex = 3;
            textBox2.Text = "Month";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // cbbYear
            // 
            cbbYear.Anchor = AnchorStyles.Top;
            cbbYear.FormattingEnabled = true;
            cbbYear.Location = new Point(714, 86);
            cbbYear.Name = "cbbYear";
            cbbYear.Size = new Size(121, 23);
            cbbYear.TabIndex = 6;
            cbbYear.SelectedIndexChanged += cbbYear_SelectedIndexChanged;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.BackColor = SystemColors.ActiveCaption;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(675, 86);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(33, 16);
            textBox3.TabIndex = 5;
            textBox3.Text = "Year";
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Top;
            textBox10.BackColor = SystemColors.ActiveCaption;
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox10.Location = new Point(411, 3);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(84, 28);
            textBox10.TabIndex = 13;
            textBox10.Text = "REPORT";
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.Location = new Point(776, 450);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(93, 23);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // ReportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnReset);
            Controls.Add(textBox10);
            Controls.Add(cbbYear);
            Controls.Add(textBox3);
            Controls.Add(cbbMonth);
            Controls.Add(textBox2);
            Controls.Add(cbbDepartment);
            Controls.Add(textBox1);
            Controls.Add(dgvReport);
            Name = "ReportControl";
            Size = new Size(904, 501);
            Load += ReportControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReport;
        private TextBox textBox1;
        private ComboBox cbbDepartment;
        private ComboBox cbbMonth;
        private TextBox textBox2;
        private ComboBox cbbYear;
        private TextBox textBox3;
        private TextBox textBox10;
        private Button btnReset;
    }
}
