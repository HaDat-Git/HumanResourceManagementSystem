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
    public partial class ReportControl : UserControl
    {
        private string connectionString = @"Server=LAPTOP-RA8AK0H5;Database=humanresource;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection conn;
        public ReportControl()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadReportData()
        {
            string query = @"
            SELECT 
                d.name AS Department,
                p.month,
                p.year,
                COUNT(DISTINCT e.employeeId) AS totalEmployees,
                AVG(p.totalHours) AS avgWorkHours,
                AVG(p.totalSalary) AS avgSalary,
                (
                    SELECT COUNT(*) 
                    FROM LeaveRequest lr
                    INNER JOIN Employee e2 ON lr.employeeId = e2.employeeId
                    WHERE e2.departmentId = d.departmentId 
                      AND MONTH(lr.startDate) = p.month 
                      AND YEAR(lr.startDate) = p.year
                ) AS numOnLeave
            FROM Payroll p
            INNER JOIN Employee e ON p.employeeId = e.employeeId
            INNER JOIN Department d ON e.departmentId = d.departmentId
            GROUP BY d.name, d.departmentId, p.month, p.year;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
            }
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ReportControl_Load(object sender, EventArgs e)
        {
            LoadReportData();
            LoadDepartmentComboBox();
            LoadMonthComboBox();
            LoadYearComboBox();
            FilterReport();
        }

        private void LoadDepartmentComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT department FROM HumanResourceReport ORDER BY department";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                cbbDepartment.Items.Clear();

                while (reader.Read())
                {
                    cbbDepartment.Items.Add(reader["department"].ToString());
                }

                reader.Close();
            }
        }

        private void LoadMonthComboBox()
        {
            cbbMonth.Items.Clear();
            cbbMonth.Items.Add(""); // Tùy chọn để không lọc

            for (int i = 1; i <= 12; i++)
            {
                cbbMonth.Items.Add(i.ToString());
            }
        }

        private void LoadYearComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT year FROM HumanResourceReport ORDER BY year";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                cbbYear.Items.Clear();

                while (reader.Read())
                {
                    cbbYear.Items.Add(reader["year"].ToString());
                }

                reader.Close();
            }
        }



        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterReport();
        }

        private void cbbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterReport();
        }

        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterReport();
        }

        private void FilterReport()
        {
            string department = cbbDepartment.SelectedItem?.ToString();
            int? month = cbbMonth.SelectedItem != null ? Convert.ToInt32(cbbMonth.SelectedItem) : (int?)null;
            int? year = cbbYear.SelectedItem != null ? Convert.ToInt32(cbbYear.SelectedItem) : (int?)null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT * FROM HumanResourceReport
            WHERE (@Department IS NULL OR department = @Department)
              AND (@Month IS NULL OR month = @Month)
              AND (@Year IS NULL OR year = @Year);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Department", (object)department ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Month", (object)month ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Year", (object)year ?? DBNull.Value);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvReport.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbDepartment.SelectedIndex = -1;
            cbbMonth.SelectedIndex = -1;
            cbbYear.SelectedIndex = -1;
            FilterReport();
        }
    }
}
