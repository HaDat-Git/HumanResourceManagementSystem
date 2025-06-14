using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResorce
{
    public partial class ManageEmployeeControl : UserControl
    {

        private string connectionString = @"Server=LAPTOP-RA8AK0H5;Database=humanresource;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection conn;

        private int selectedEmployeeId = -1;

        public ManageEmployeeControl()
        {
            InitializeComponent();
            this.Load += ManageEmployeeControl_Load;
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    e.employeeId,
                    e.name,
                    e.dob,
                    e.gender,
                    e.position,
                    e.email,
                    e.phoneNumber,
                    e.startDate,
                    d.name AS DepartmentName
                FROM Employee e
                JOIN Department d ON e.departmentId = d.departmentId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable employeeTable = new DataTable();
                    adapter.Fill(employeeTable);

                    dgvEmployee.DataSource = employeeTable;

                    if (dgvEmployee.Columns["employeeId"] != null)
                        dgvEmployee.Columns["employeeId"].Visible = false;

                    if (dgvEmployee.Columns["dob"] != null)
                        dgvEmployee.Columns["dob"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    if (dgvEmployee.Columns["startDate"] != null)
                        dgvEmployee.Columns["startDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    if (dgvEmployee.Columns["name"] != null)
                        dgvEmployee.Columns["name"].HeaderText = "Full Name";

                    if (dgvEmployee.Columns["gender"] != null)
                        dgvEmployee.Columns["gender"].HeaderText = "Gender";

                    if (dgvEmployee.Columns["position"] != null)
                        dgvEmployee.Columns["position"].HeaderText = "Position";

                    if (dgvEmployee.Columns["email"] != null)
                        dgvEmployee.Columns["email"].HeaderText = "Email";

                    if (dgvEmployee.Columns["phoneNumber"] != null)
                        dgvEmployee.Columns["phoneNumber"].HeaderText = "Phone";

                    if (dgvEmployee.Columns["startDate"] != null)
                        dgvEmployee.Columns["startDate"].HeaderText = "Start Date";

                    if (dgvEmployee.Columns["DepartmentName"] != null)
                        dgvEmployee.Columns["DepartmentName"].HeaderText = "Department";

                    if (dgvEmployee.Columns["dob"] != null)
                        dgvEmployee.Columns["dob"].HeaderText = "DOB";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }


        private void ManageEmployeeControl_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            LoadDepartments();

            cbbGender.Items.Clear();
            cbbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

                // Lưu lại employeeId
                selectedEmployeeId = Convert.ToInt32(row.Cells["employeeId"].Value);

                txtName.Text = row.Cells["name"].Value?.ToString();
                txtPosition.Text = row.Cells["position"].Value?.ToString();
                txtEmail.Text = row.Cells["email"].Value?.ToString();
                txtPhone.Text = row.Cells["phoneNumber"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["dob"].Value?.ToString(), out DateTime dob))
                    dtpDOB.Value = dob;

                if (DateTime.TryParse(row.Cells["startDate"].Value?.ToString(), out DateTime startDate))
                    dtpStartDate.Value = startDate;

                string gender = row.Cells["gender"].Value?.ToString();
                if (!string.IsNullOrEmpty(gender))
                    cbbGender.SelectedItem = gender;

                string department = row.Cells["DepartmentName"].Value?.ToString();
                if (!string.IsNullOrEmpty(department))
                    cbbDepartment.SelectedItem = department;
            }

        }

        private void LoadDepartments()
        {
            cbbDepartment.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM Department", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbbDepartment.Items.Add(reader.GetString(0));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                cbbGender.SelectedItem == null ||
                cbbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy dữ liệu từ form
            string name = txtName.Text.Trim();
            string gender = cbbGender.SelectedItem.ToString();
            DateTime dob = dtpDOB.Value.Date;
            string position = txtPosition.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            DateTime startDate = dtpStartDate.Value.Date;
            string departmentName = cbbDepartment.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 3. Lấy DepartmentID từ tên phòng ban
                    string getDepQuery = "SELECT DepartmentID FROM Department WHERE Name = @name";
                    SqlCommand depCmd = new SqlCommand(getDepQuery, conn);
                    depCmd.Parameters.AddWithValue("@name", departmentName);
                    object result = depCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Phòng ban không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int departmentId = Convert.ToInt32(result);

                    // 4. Thêm nhân viên
                    string insertQuery = @"
                INSERT INTO Employee (Name, DOB, Gender, Position, Email, PhoneNumber, StartDate, DepartmentID)
                VALUES (@Name, @DOB, @Gender, @Position, @Email, @Phone, @StartDate, @DepartmentID)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@Name", name);
                    insertCmd.Parameters.AddWithValue("@DOB", dob);
                    insertCmd.Parameters.AddWithValue("@Gender", gender);
                    insertCmd.Parameters.AddWithValue("@Position", position);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@Phone", phone);
                    insertCmd.Parameters.AddWithValue("@StartDate", startDate);
                    insertCmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                    int rows = insertCmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData(); // Tải lại dgv
                        ClearForm();        // Xóa dữ liệu nhập
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPosition.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cbbGender.SelectedIndex = -1;
            cbbDepartment.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                cbbGender.SelectedItem == null ||
                cbbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            string gender = cbbGender.SelectedItem.ToString();
            DateTime dob = dtpDOB.Value.Date;
            string position = txtPosition.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            DateTime startDate = dtpStartDate.Value.Date;
            string departmentName = cbbDepartment.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy departmentId
                    string getDepQuery = "SELECT DepartmentID FROM Department WHERE Name = @name";
                    SqlCommand depCmd = new SqlCommand(getDepQuery, conn);
                    depCmd.Parameters.AddWithValue("@name", departmentName);
                    object result = depCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy phòng ban!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int departmentId = Convert.ToInt32(result);

                    // Cập nhật nhân viên
                    string updateQuery = @"
            UPDATE Employee
            SET Name = @Name,
                DOB = @DOB,
                Gender = @Gender,
                Position = @Position,
                Email = @Email,
                PhoneNumber = @Phone,
                StartDate = @StartDate,
                DepartmentID = @DepartmentID
            WHERE EmployeeID = @EmployeeID";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Name", name);
                    updateCmd.Parameters.AddWithValue("@DOB", dob);
                    updateCmd.Parameters.AddWithValue("@Gender", gender);
                    updateCmd.Parameters.AddWithValue("@Position", position);
                    updateCmd.Parameters.AddWithValue("@Email", email);
                    updateCmd.Parameters.AddWithValue("@Phone", phone);
                    updateCmd.Parameters.AddWithValue("@StartDate", startDate);
                    updateCmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                    updateCmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeId);

                    int rows = updateCmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData();
                        ClearForm();
                        selectedEmployeeId = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            // Nếu người dùng chọn Yes, thực hiện xóa
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData();
                        ClearForm();
                        selectedEmployeeId = -1;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPosition.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cbbGender.SelectedIndex = -1;
            cbbDepartment.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
        }
    }
}
