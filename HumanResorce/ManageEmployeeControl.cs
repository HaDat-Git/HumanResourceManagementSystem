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

        private string connectionString = @"Server=LAPTOP-RA8AK0H5;Database=general_clinic_manage;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection conn;
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
                    e.EmployeeID,
                    e.Name,
                    e.DOB,
                    e.Gender,
                    e.Position,
                    e.Email,
                    e.Phone,
                    e.StartDate,
                    d.DepartmentName AS Department
                FROM Employees e
                JOIN Departments d ON e.DepartmentID = d.DepartmentID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable employeeTable = new DataTable();
                    adapter.Fill(employeeTable);

                    dgvEmployee.DataSource = employeeTable;

                    // Ẩn cột ID nếu không cần
                    dgvEmployee.Columns["EmployeeID"].Visible = false;

                    // Định dạng ngày sinh & ngày bắt đầu
                    dgvEmployee.Columns["DOB"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvEmployee.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Đổi tên cột sang tiếng Việt
                    dgvEmployee.Columns["Name"].HeaderText = "Họ tên";
                    dgvEmployee.Columns["Gender"].HeaderText = "Giới tính";
                    dgvEmployee.Columns["Position"].HeaderText = "Chức vụ";
                    dgvEmployee.Columns["Email"].HeaderText = "Email";
                    dgvEmployee.Columns["Phone"].HeaderText = "Điện thoại";
                    dgvEmployee.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
                    dgvEmployee.Columns["Department"].HeaderText = "Phòng ban";
                    dgvEmployee.Columns["DOB"].HeaderText = "Ngày sinh";
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
        }
    }
}
