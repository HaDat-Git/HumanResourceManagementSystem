using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResorce
{
    public partial class PaymentControl : UserControl
    {
        private string connectionString = @"Server=LAPTOP-RA8AK0H5;Database=humanresource;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection conn;

        private int selectedEmployeeId = -1;
        public PaymentControl()
        {
            InitializeComponent();
            dgvSalary.CellClick += dgvSalary_CellClick;
        }
        private void LoadPayrollData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    p.payrollId AS [Payroll ID],
                    p.employeeId AS [Employee ID],
                    e.name AS [Employee Name],
                    p.month AS [Month],
                    p.year AS [Year],
                    p.totalHours AS [Total Hours],
                    p.baseSalary AS [Base Salary (USD/hour)],
                    p.allowance AS [Allowance (USD)],
                    p.totalSalary AS [Total Salary (USD)]
                FROM Payroll p
                JOIN Employee e ON p.employeeId = e.employeeId
                ORDER BY p.year DESC, p.month DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvSalary.DataSource = table;

                    if (dgvSalary.Columns.Contains("Payroll ID"))
                        dgvSalary.Columns["Payroll ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvSalary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void PaymentControl_Load(object sender, EventArgs e)
        {
            LoadPayrollData();
            LoadMonthYear();
        }

        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int oldMonth = 0;
        int oldYear = 0;
        private void dgvSalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Đảm bảo người dùng click vào dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalary.Rows[e.RowIndex];

                txtID.Text = row.Cells["Employee ID"].Value.ToString();
                txtName.Text = row.Cells["Employee Name"].Value.ToString();
                cbbMonth.SelectedItem = row.Cells["Month"].Value.ToString();
                cbbYear.SelectedItem = row.Cells["Year"].Value.ToString();
                txtTotalHour.Text = row.Cells["Total Hours"].Value.ToString();
                txtBaseSalary.Text = row.Cells["Base Salary (USD/hour)"].Value.ToString();
                txtAllowance.Text = row.Cells["Allowance (USD)"].Value.ToString();
                txtTotal.Text = row.Cells["Total Salary (USD)"].Value.ToString();

                oldMonth = int.Parse(row.Cells["Month"].Value.ToString());
                oldYear = int.Parse(row.Cells["Year"].Value.ToString());

            }
        }

        private void LoadMonthYear()
        {
            cbbMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cbbMonth.Items.Add(i.ToString());

            cbbYear.Items.Clear();
            for (int y = 2023; y <= DateTime.Now.Year + 5; y++)
                cbbYear.Items.Add(y.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Không cho phép sửa Employee ID và Name (nếu TextBox hoặc ComboBox bị sửa)
            if (dgvSalary.CurrentRow != null)
            {
                string currentName = dgvSalary.CurrentRow.Cells["Employee Name"].Value.ToString();
                string currentId = dgvSalary.CurrentRow.Cells["Employee ID"].Value.ToString();

                if (txtID.Text != currentId)
                {
                    MessageBox.Show("Không được phép sửa ID nhân viên trong bảng lương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Text = currentId;
                    return;
                }

                if (txtName.Text != currentName)
                {
                    MessageBox.Show("Không được phép sửa tên nhân viên trong bảng lương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Text = currentName;
                    return;
                }
            }

            // 2. Kiểm tra tháng và năm không lớn hơn hiện tại
            if (cbbMonth.SelectedItem == null || cbbYear.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int month = int.Parse(cbbMonth.SelectedItem.ToString());
            int year = int.Parse(cbbYear.SelectedItem.ToString());
            DateTime selectedDate = new DateTime(year, month, 1);
            DateTime now = DateTime.Now;

            if (selectedDate > new DateTime(now.Year, now.Month, 1))
            {
                MessageBox.Show("Tháng và năm không được lớn hơn hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Lấy các giá trị để cập nhật
            int employeeId = int.Parse(txtID.Text);
            float baseSalary = float.Parse(txtBaseSalary.Text);
            float allowance = float.Parse(txtAllowance.Text);
            float totalHours = float.Parse(txtTotalHour.Text);

            float totalSalary = baseSalary * totalHours + allowance;
            txtTotal.Text = totalSalary.ToString("F2");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"
                UPDATE Payroll 
                SET 
                    month = @month,
                    year = @year,
                    totalHours = @totalHours,
                    baseSalary = @baseSalary,
                    allowance = @allowance,
                    totalSalary = @totalSalary
                WHERE employeeId = @employeeId AND month = @oldMonth AND year = @oldYear";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@totalHours", totalHours);
                    cmd.Parameters.AddWithValue("@baseSalary", baseSalary);
                    cmd.Parameters.AddWithValue("@allowance", allowance);
                    cmd.Parameters.AddWithValue("@totalSalary", totalSalary);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.Parameters.AddWithValue("@oldMonth", oldMonth);
                    cmd.Parameters.AddWithValue("@oldYear", oldYear);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPayrollData(); // reload dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBaseSalary_Leave(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void PaymentControl_Leave(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void txtTotalHour_Leave(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void CalculateSalary()
        {
            if (float.TryParse(txtBaseSalary.Text, out float baseSalary) &&
                float.TryParse(txtAllowance.Text, out float allowance) &&
                float.TryParse(txtTotalHour.Text, out float totalHours))
            {
                float totalSalary = baseSalary * totalHours + allowance;
                txtTotal.Text = totalSalary.ToString("F2");
            }
            else
            {
                txtTotal.Text = "0.00";
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            SearchPayrollByID();
        }

        private void SearchPayrollByID()
        {
            if (!int.TryParse(txtID.Text.Trim(), out int employeeId))
            {
                txtName.Clear();
                dgvSalary.DataSource = null;
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy tên nhân viên
                    string nameQuery = "SELECT name FROM Employee WHERE employeeId = @empId";
                    SqlCommand nameCmd = new SqlCommand(nameQuery, conn);
                    nameCmd.Parameters.AddWithValue("@empId", employeeId);
                    object result = nameCmd.ExecuteScalar();
                    if (result != null)
                    {
                        txtName.Text = result.ToString();
                    }
                    else
                    {
                        txtName.Clear();
                    }

                    // Lấy dữ liệu bảng lương
                    string payrollQuery = @"
                SELECT 
                    p.employeeId AS [Employee ID],
                    e.name AS [Employee Name],
                    p.month AS [Month],
                    p.year AS [Year],
                    p.totalHours AS [Total Hours],
                    p.baseSalary AS [Base Salary (USD/hour)],
                    p.allowance AS [Allowance (USD)],
                    p.totalSalary AS [Total Salary (USD)]
                FROM Payroll p
                JOIN Employee e ON p.employeeId = e.employeeId
                WHERE p.employeeId = @empId";

                    SqlCommand payrollCmd = new SqlCommand(payrollQuery, conn);
                    payrollCmd.Parameters.AddWithValue("@empId", employeeId);
                    SqlDataAdapter adapter = new SqlDataAdapter(payrollCmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvSalary.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            LoadPayrollData();
        }
    }
}
