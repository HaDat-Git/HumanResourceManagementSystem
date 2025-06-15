using Azure.Core;
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
    public partial class LeaveRequestControl : UserControl
    {
        private string connectionString = @"Server=LAPTOP-RA8AK0H5;Database=humanresource;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection conn;

        private int selectedEmployeeId = -1;

        public LeaveRequestControl()
        {
            InitializeComponent();
            txtIDSearch.TextChanged += txtIDSearch_TextChanged;
        }

            private void LoadLeaveRequestsData()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = @"
                    SELECT 
                        lr.requestId AS [Request ID],
                        lr.employeeId AS [Employee ID],
                        e.name AS [Employee Name],
                        lr.reason AS [Reason],
                        lr.startDate AS [Start Date],
                        lr.endDate AS [End Date],
                        lr.status AS [Status],
                        lr.isApproved AS [Approved],
                        lr.note AS [Note]
                    FROM LeaveRequest lr
                    JOIN Employee e ON lr.employeeId = e.employeeId
                    ORDER BY lr.startDate DESC";

                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvLeaveRequest.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu đơn nghỉ phép: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvLeaveRequest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            private void LeaveRequestControl_Load(object sender, EventArgs e)
            {
                LoadLeaveRequestsData();
                LoadStatusComboBox();
                isUpdating = false;
            }

            private void LoadStatusComboBox()
            {
                cbbStatus.Items.Clear();
                cbbStatus.Items.Add("Pending");
                cbbStatus.Items.Add("Approved");
                cbbStatus.Items.Add("Rejected");

                cbbStatus.SelectedIndex = 0;
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                // 1. Kiểm tra dữ liệu
                if (!int.TryParse(txtID.Text.Trim(), out int employeeId))
                {
                    MessageBox.Show("Vui lòng nhập ID nhân viên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReason.Text) || cbbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ lý do và chọn trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;
                
                if(startDate > DateTime.Today)
                {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                }
                
                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Lấy dữ liệu
                string reason = txtReason.Text.Trim();
                string status = cbbStatus.SelectedItem.ToString();
                bool isApproved;

                if (ckYes.Checked && !ckNo.Checked)
                {
                    isApproved = true;
                }
                else if (!ckYes.Checked && ckNo.Checked)
                {
                    isApproved = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn trạng thái được duyệt hoặc từ chối (chỉ một trong hai).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string note = rtbNote.Text.Trim();

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Kiểm tra nhân viên có tồn tại không
                        string checkEmpQuery = "SELECT COUNT(*) FROM Employee WHERE employeeId = @empId";
                        SqlCommand checkCmd = new SqlCommand(checkEmpQuery, conn);
                        checkCmd.Parameters.AddWithValue("@empId", employeeId);
                        int empExists = (int)checkCmd.ExecuteScalar();

                        if (empExists == 0)
                        {
                            MessageBox.Show("Không tồn tại nhân viên với ID này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 3. Thêm bản ghi vào LeaveRequest
                        string insertQuery = @"
                    INSERT INTO LeaveRequest (employeeId, reason, startDate, endDate, status, isApproved, note)
                    VALUES (@employeeId, @reason, @startDate, @endDate, @status, @isApproved, @note)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@employeeId", employeeId);
                        insertCmd.Parameters.AddWithValue("@reason", reason);
                        insertCmd.Parameters.AddWithValue("@startDate", startDate);
                        insertCmd.Parameters.AddWithValue("@endDate", endDate);
                        insertCmd.Parameters.AddWithValue("@status", status);
                        insertCmd.Parameters.AddWithValue("@isApproved", isApproved);
                        insertCmd.Parameters.AddWithValue("@note", note);

                        int rows = insertCmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Thêm đơn nghỉ phép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLeaveRequestsData(); // Reload lại dgv
                            ClearLeaveForm();    // Xóa trắng các trường nhập
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm đơn nghỉ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm đơn nghỉ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void ClearLeaveForm()
            {
                txtID.Clear();
                txtName.Clear();
                txtReason.Clear();
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today;
                cbbStatus.SelectedItem = "Pending";
                ckYes.Checked = false;
                ckNo.Checked = false;
                rtbNote.Clear();
            }

            private void dgvLeaveRequest_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0 && dgvLeaveRequest.Rows[e.RowIndex].Cells["Employee ID"].Value != null)
                {
                    DataGridViewRow row = dgvLeaveRequest.Rows[e.RowIndex];

                    txtID.Text = row.Cells["Employee ID"].Value.ToString();
                    txtName.Text = row.Cells["Employee Name"].Value.ToString();
                    txtReason.Text = row.Cells["Reason"].Value?.ToString();
                    dtpStartDate.Value = Convert.ToDateTime(row.Cells["Start Date"].Value);
                    dtpEndDate.Value = Convert.ToDateTime(row.Cells["End Date"].Value);
                    isUpdating = true;

                    cbbStatus.Text = row.Cells["Status"].Value?.ToString();
                    rtbNote.Text = row.Cells["Note"].Value?.ToString();

                    // Xử lý checkbox IsApproved
                    bool isApproved = row.Cells["Approved"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Approved"].Value);
                    ckYes.Checked = isApproved;
                    ckNo.Checked = !isApproved;
                    isUpdating = false; // 👈 Kết thúc
                    rtbNote.Text = row.Cells["Note"].Value?.ToString();
            }
            }

            private void txtID_Leave(object sender, EventArgs e)
            {
                if (int.TryParse(txtID.Text.Trim(), out int employeeId))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "SELECT name FROM Employee WHERE employeeId = @id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", employeeId);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                txtName.Text = result.ToString();
                            }
                            else
                            {
                                txtName.Text = "(Không tìm thấy)";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lấy tên nhân viên: " + ex.Message);
                        }
                    }
                }
                else
                {
                    txtName.Clear();
                }
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                if (dgvLeaveRequest.CurrentRow == null || dgvLeaveRequest.CurrentRow.Cells["Request ID"].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn một đơn nghỉ phép để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy requestId từ dòng đang chọn
                int requestId = Convert.ToInt32(dgvLeaveRequest.CurrentRow.Cells["Request ID"].Value);

                // Lấy thông tin nhập từ form
                if (!int.TryParse(txtID.Text.Trim(), out int employeeId))
                {
                    MessageBox.Show("ID nhân viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReason.Text) || cbbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ lý do và chọn trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;

                if (startDate > DateTime.Today)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reason = txtReason.Text.Trim();
                string status = cbbStatus.SelectedItem.ToString();
                string note = rtbNote.Text.Trim();

                bool isApproved;
                if (ckYes.Checked && !ckNo.Checked)
                {
                    isApproved = true;
                }
                else if (!ckYes.Checked && ckNo.Checked)
                {
                    isApproved = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn trạng thái duyệt (Yes hoặc No).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string updateQuery = @"
                    UPDATE LeaveRequest
                    SET 
                        employeeId = @employeeId,
                        reason = @reason,
                        startDate = @startDate,
                        endDate = @endDate,
                        status = @status,
                        isApproved = @isApproved,
                        note = @note
                    WHERE requestId = @requestId";

                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);
                        cmd.Parameters.AddWithValue("@reason", reason);
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@isApproved", isApproved);
                        cmd.Parameters.AddWithValue("@note", note);
                        cmd.Parameters.AddWithValue("@requestId", requestId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật đơn nghỉ phép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLeaveRequestsData(); // reload dgv
                            ClearLeaveForm(); // clear fields
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật đơn nghỉ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật đơn nghỉ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (dgvLeaveRequest.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy requestId từ DataGridView
                int requestId;
                try
                {
                    requestId = Convert.ToInt32(dgvLeaveRequest.CurrentRow.Cells["Request ID"].Value);
                }
                catch
                {
                    MessageBox.Show("Không thể xác định requestId để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đơn nghỉ phép này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM LeaveRequest WHERE requestId = @requestId";

                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@requestId", requestId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa đơn nghỉ phép thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLeaveRequestsData();
                            ClearLeaveForm();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hoặc không thể xóa bản ghi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa đơn nghỉ phép: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void txtIDSearch_(object sender, EventArgs e)
            {

            }

            private void txtIDSearch_TextChanged(object sender, EventArgs e)
            {
                SearchLeaveRequests();
            }

            private void dtpStartDateSearch_ValueChanged(object sender, EventArgs e)
            {
                SearchLeaveRequests();
            }

            private void SearchLeaveRequests()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = @"
                    SELECT 
                        lr.requestId AS [Request ID],
                        lr.employeeId AS [Employee ID],
                        e.name AS [Employee Name],
                        lr.reason AS [Reason],
                        lr.startDate AS [Start Date],
                        lr.endDate AS [End Date],
                        lr.status AS [Status],
                        lr.isApproved AS [Approved],
                        lr.note AS [Note]
                    FROM LeaveRequest lr
                    JOIN Employee e ON lr.employeeId = e.employeeId
                    WHERE 1=1";

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        // Lọc theo ID nếu có nhập
                        if (!string.IsNullOrWhiteSpace(txtIDSearch.Text) && int.TryParse(txtIDSearch.Text.Trim(), out int empId))
                        {
                            query += " AND lr.employeeId = @empId";
                            cmd.Parameters.AddWithValue("@empId", empId);
                        }

                        // Luôn lọc theo ngày (nếu muốn bỏ điều kiện này khi không chọn, có thể thêm tùy chọn)
                        DateTime selectedDate = dtpStartDateSearch.Value.Date;
                        query += " AND lr.startDate = @startDate";
                        cmd.Parameters.AddWithValue("@startDate", selectedDate);

                        cmd.CommandText = query;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvLeaveRequest.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnReset_Click(object sender, EventArgs e)
            {
                txtIDSearch.Clear();

                if (dtpStartDateSearch.ShowCheckBox)
                {
                    dtpStartDateSearch.Checked = false;
                }

                // Reset status và checkbox
                isUpdating = true;
                cbbStatus.SelectedItem = "Pending";
                ckYes.Checked = false;
                ckNo.Checked = false;
                isUpdating = false;

                LoadLeaveRequestsData();
            }

            bool isUpdating = false;

            private void ckYes_CheckedChanged(object sender, EventArgs e)
            {
                if (isUpdating) return;

                if (ckYes.Checked)
                {
                    isUpdating = true;
                    ckNo.Checked = false;
                    cbbStatus.SelectedItem = "Approved";
                    isUpdating = false;
                }
            }

            private void ckNo_CheckedChanged(object sender, EventArgs e)
            {
                if (isUpdating) return;

                if (ckNo.Checked)
                {
                    isUpdating = true;
                    ckYes.Checked = false;
                    cbbStatus.SelectedItem = "Rejected";
                    isUpdating = false;
                }
            }

            private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (isUpdating) return;
                if (cbbStatus.SelectedItem == null) return;

                isUpdating = true;
                string status = cbbStatus.SelectedItem.ToString();
                if (status == "Approved")
                {
                    ckYes.Checked = true;   
                    ckNo.Checked = false;
                }
                else if (status == "Rejected")
                {
                    ckNo.Checked = true;
                    ckYes.Checked = false;
                }
                else if (status == "Pending")
                {
                    ckYes.Checked = false;
                    ckNo.Checked = true;
                }
                isUpdating = false;
            }
    }
}
