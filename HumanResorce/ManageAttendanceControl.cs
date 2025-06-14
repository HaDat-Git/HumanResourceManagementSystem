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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HumanResorce
{
    public partial class ManageAttendanceControl : UserControl
    {

        private string connectionString = @"Server=LAPTOP-RA8AK0H5;Database=humanresource;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection conn;

        private int selectedAttendanceId = -1;
        public ManageAttendanceControl()
        {
            InitializeComponent();
            cbbDepartment.SelectedIndexChanged += cbbDepartment_SelectedIndexChanged;
            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;
            txtID.Leave += txtID_Leave;

            this.Load += ManageAttendanceControl_Load;
        }

        private void ManageAttendanceControl_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadAttendanceData();

            dtpCheckInTime.Format = DateTimePickerFormat.Time;
            dtpCheckInTime.ShowUpDown = true;

            dtpCheckOutTime.Format = DateTimePickerFormat.Time;
            dtpCheckOutTime.ShowUpDown = true;

            // Đặt mặc định giờ check-in là 8:00 sáng
            dtpCheckInTime.Value = DateTime.Today.AddHours(8);

            // Đặt mặc định giờ check-out là 5:00 chiều
            dtpCheckOutTime.Value = DateTime.Today.AddHours(17);

            dtpCheckInTime.ValueChanged += CalculateAttendanceStats;
            dtpCheckOutTime.ValueChanged += CalculateAttendanceStats;
        }

        private void LoadAttendanceData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    a.attendanceId,
                    e.employeeId,
                    e.name AS EmployeeName,
                    a.date,
                    a.checkInTime,
                    a.checkOutTime,
                    ROUND(a.totalHours, 2) AS totalHours,
                    a.isLate,
                    a.lateMinutes
                FROM Attendance a
                JOIN Employee e ON a.employeeId = e.employeeId
                ORDER BY a.date DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvAttendance.DataSource = table;

                    if (dgvAttendance.Columns["attendanceId"] != null)
                        dgvAttendance.Columns["attendanceId"].Visible = false;

                    dgvAttendance.Columns["EmployeeId"].HeaderText = "Employee ID";
                    dgvAttendance.Columns["EmployeeName"].HeaderText = "Employee Name";
                    dgvAttendance.Columns["date"].HeaderText = "Date";
                    dgvAttendance.Columns["checkInTime"].HeaderText = "Check In";
                    dgvAttendance.Columns["checkOutTime"].HeaderText = "Check Out";
                    dgvAttendance.Columns["totalHours"].HeaderText = "Total Hours";
                    dgvAttendance.Columns["isLate"].HeaderText = "Late";
                    dgvAttendance.Columns["lateMinutes"].HeaderText = "Late Minutes";

                    dgvAttendance.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chấm công: " + ex.Message);
            }

            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name FROM Department";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cbbDepartment.Items.Clear();
                    cbbDepartment.Items.Add("Tất cả"); // Cho phép xem toàn bộ
                    while (reader.Read())
                    {
                        string departmentName = reader.GetString(0);
                        cbbDepartment.Items.Add(departmentName);
                    }

                    cbbDepartment.SelectedIndex = 0; // Mặc định chọn “Tất cả”
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng ban: " + ex.Message);
            }
        }

        private void LoadAttendanceByDepartment(string departmentName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    a.attendanceId,
                    e.employeeId,
                    e.name AS EmployeeName,
                    a.date,
                    a.checkInTime,
                    a.checkOutTime,
                    ROUND(a.totalHours, 2) AS totalHours,
                    a.isLate,
                    a.lateMinutes
                FROM Attendance a
                JOIN Employee e ON a.employeeId = e.employeeId
                JOIN Department d ON e.departmentId = d.departmentId
                WHERE d.name = @DepartmentName
                ORDER BY a.date DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvAttendance.DataSource = table;

                    if (dgvAttendance.Columns["attendanceId"] != null)
                        dgvAttendance.Columns["attendanceId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu chấm công theo phòng ban: " + ex.Message);
            }
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDepartment.SelectedItem != null)
            {
                string selectedDepartment = cbbDepartment.SelectedItem.ToString();

                if (selectedDepartment == "Tất cả")
                {
                    LoadAttendanceData();
                }
                else
                {
                    LoadAttendanceByDepartment(selectedDepartment);
                }
            }
        }
        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];

                selectedAttendanceId = Convert.ToInt32(row.Cells["attendanceId"].Value);

                // Hiển thị thông tin
                txtID.Text = row.Cells["EmployeeId"].Value?.ToString();
                txtName.Text = row.Cells["EmployeeName"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["date"].Value?.ToString(), out DateTime date))
                    dtpDate.Value = date;

                if (TimeSpan.TryParse(row.Cells["checkInTime"].Value?.ToString(), out TimeSpan checkIn))
                    dtpCheckInTime.Value = DateTime.Today + new TimeSpan(checkIn.Hours, checkIn.Minutes, 0);

                if (TimeSpan.TryParse(row.Cells["checkOutTime"].Value?.ToString(), out TimeSpan checkOut))
                    dtpCheckOutTime.Value = DateTime.Today + new TimeSpan(checkOut.Hours, checkOut.Minutes, 0);

                txtTotalHour.Text = row.Cells["totalHours"].Value?.ToString();

                if (bool.TryParse(row.Cells["isLate"].Value?.ToString(), out bool isLate))
                {
                    ckYes.Checked = isLate;
                    ckNo.Checked = !isLate;
                }

                txtLateMinute.Text = row.Cells["lateMinutes"].Value?.ToString();
            }
        }

        private void CalculateAttendanceStats(object sender, EventArgs e)
        {
            TimeSpan checkIn = new TimeSpan(dtpCheckInTime.Value.Hour, dtpCheckInTime.Value.Minute, 0);
            TimeSpan checkOut = new TimeSpan(dtpCheckOutTime.Value.Hour, dtpCheckOutTime.Value.Minute, 0);

            // Tính tổng số giờ làm việc
            TimeSpan duration = checkOut - checkIn;

            if (duration.TotalMinutes >= 0) // CheckOut phải sau CheckIn
            {
                txtTotalHour.Text = Math.Round(duration.TotalHours, 2).ToString();

                // Giả sử giờ làm việc bắt đầu từ 08:00
                TimeSpan standardStart = new TimeSpan(8, 0, 0);

                // Nếu đến sau 8h thì trễ
                if (checkIn > standardStart)
                {
                    int lateMins = (int)(checkIn - standardStart).TotalMinutes;
                    txtLateMinute.Text = lateMins.ToString();
                    ckYes.Checked = true;
                    ckNo.Checked = false;
                }
                else
                {
                    txtLateMinute.Text = "0";
                    ckYes.Checked = false;
                    ckNo.Checked = true;
                }
            }
            else
            {
                txtTotalHour.Text = "0";
                txtLateMinute.Text = "0";
                MessageBox.Show("Giờ check-out phải sau giờ check-in.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();

            // Đặt ngày về hôm nay
            dtpDate.Value = DateTime.Today;

            // Đặt giờ check-in là 08:00 sáng
            dtpCheckInTime.Value = DateTime.Today.AddHours(8);

            // Đặt giờ check-out là 17:00 (5 giờ chiều)
            dtpCheckOutTime.Value = DateTime.Today.AddHours(17);

            txtTotalHour.Text = "0";
            txtLateMinute.Text = "0";

            // Bỏ chọn cả hai checkbox
            ckYes.Checked = false;
            ckNo.Checked = false;

            // Reset ID đang chọn
            selectedAttendanceId = -1;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedAttendanceId == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.");
                return;
            }

            if (dgvAttendance.CurrentRow != null)
            {
                string selectedName = dgvAttendance.CurrentRow.Cells["EmployeeName"].Value?.ToString();
                if (txtName.Text != selectedName)
                {
                    MessageBox.Show("Không thể sửa tên nhân viên trong mục chấm công.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Text = selectedName; // Reset lại
                    return;
                }
            }

            // Thêm kiểm tra ngày tại đây:
            DateTime selectedDate = dtpDate.Value.Date;
            if (selectedDate > DateTime.Today)
            {
                MessageBox.Show("Không thể cập nhật ngày chấm công lớn hơn ngày hiện tại.", "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE Attendance
                SET 
                    date = @Date,
                    checkInTime = @CheckInTime,
                    checkOutTime = @CheckOutTime,
                    totalHours = @TotalHours,
                    isLate = @IsLate,
                    lateMinutes = @LateMinutes
                WHERE attendanceId = @AttendanceId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@CheckInTime", dtpCheckInTime.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@CheckOutTime", dtpCheckOutTime.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@TotalHours", float.Parse(txtTotalHour.Text));
                    cmd.Parameters.AddWithValue("@IsLate", ckYes.Checked);
                    cmd.Parameters.AddWithValue("@LateMinutes", int.Parse(txtLateMinute.Text));
                    cmd.Parameters.AddWithValue("@AttendanceId", selectedAttendanceId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        LoadAttendanceData(); // Tải lại dữ liệu dgv
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại.");
                    }
                }
                ClearFields(); // Xóa các trường sau khi cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.CurrentRow != null)
            {
                // Lấy attendanceId từ dòng được chọn
                int attendanceId = Convert.ToInt32(dgvAttendance.CurrentRow.Cells["attendanceId"].Value);

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng chấm công này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            string deleteQuery = "DELETE FROM Attendance WHERE attendanceId = @attendanceId";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@attendanceId", attendanceId);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Xóa thành công!");
                            LoadAttendanceData(); // Tải lại dữ liệu
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                    }
                }
                ClearFields(); // Xóa các trường sau khi xóa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int employeeId = int.TryParse(txtID.Text, out int id) ? id : -1;
            if (employeeId == -1)
            {
                MessageBox.Show("Vui lòng nhập ID hợp lệ.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên nhân viên.");
                return;
            }

            string employeeName = txtName.Text.Trim();
            DateTime date = dtpDate.Value.Date;
            if (date > DateTime.Today)
            {
                MessageBox.Show("Ngày chấm công không thể lớn hơn ngày hiện tại.", "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TimeSpan checkInTime = dtpCheckInTime.Value.TimeOfDay;
            TimeSpan checkOutTime = dtpCheckOutTime.Value.TimeOfDay;
            float totalHours = float.TryParse(txtTotalHour.Text, out float h) ? h : 0;
            bool isLate = ckYes.Checked;
            int lateMinutes = int.TryParse(txtLateMinute.Text, out int lm) ? lm : 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy employeeId từ tên
                    string findIdQuery = "SELECT employeeId FROM Employee WHERE name = @name";
                    SqlCommand findCmd = new SqlCommand(findIdQuery, conn);
                    findCmd.Parameters.AddWithValue("@name", employeeName);
                    object result = findCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên có tên này.");
                        return;
                    }

                    int empId = Convert.ToInt32(result);

                    // Kiểm tra đã có chấm công ngày này chưa
                    string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE employeeId = @employeeId AND date = @date";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@employeeId", empId);
                    checkCmd.Parameters.AddWithValue("@date", date);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Nhân viên này đã được chấm công trong ngày này.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Nếu chưa có thì chèn bản ghi mới
                    string insertQuery = @"
                INSERT INTO Attendance (employeeId, date, checkInTime, checkOutTime, totalHours, isLate, lateMinutes)
                VALUES (@employeeId, @date, @checkInTime, @checkOutTime, @totalHours, @isLate, @lateMinutes)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@employeeId", empId);
                    insertCmd.Parameters.AddWithValue("@date", date);
                    insertCmd.Parameters.AddWithValue("@checkInTime", checkInTime);
                    insertCmd.Parameters.AddWithValue("@checkOutTime", checkOutTime);
                    insertCmd.Parameters.AddWithValue("@totalHours", totalHours);
                    insertCmd.Parameters.AddWithValue("@isLate", isLate);
                    insertCmd.Parameters.AddWithValue("@lateMinutes", lateMinutes);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm chấm công thành công.");

                    LoadAttendanceData(); // Refresh DataGridView
                }
                ClearFields(); // Xóa các trường sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text.Trim(), out int employeeId))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT name FROM Employee WHERE employeeId = @employeeId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtName.Text = result.ToString();
                        }
                        else
                        {
                            txtName.Text = "";
                            MessageBox.Show("Không tìm thấy nhân viên với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm tên nhân viên: " + ex.Message);
                }
            }
            else
            {
                txtName.Text = "";
            }
        }
    }
}

