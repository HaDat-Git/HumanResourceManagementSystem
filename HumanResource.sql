-- 1. Tạo CSDL
CREATE DATABASE humanresource;
GO

USE humanresource;
GO

-- 2. Bảng người dùng hệ thống
CREATE TABLE [User] (
    userId INT IDENTITY(1,1) PRIMARY KEY,
    fullName NVARCHAR(100) NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(100) NOT NULL,
    role VARCHAR(20) CHECK (role IN ('HR', 'Director'))
);
GO

-- 3. Bảng phòng ban (Department)
CREATE TABLE Department (
    departmentId INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    managerId INT NULL  -- FK thêm sau
);
GO

-- 4. Bảng nhân viên (Employee)
CREATE TABLE Employee (
    employeeId INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    dob DATE NOT NULL,
    gender VARCHAR(10),
    position VARCHAR(100),
    email VARCHAR(100),
    phoneNumber VARCHAR(20),
    startDate DATE NOT NULL,
    departmentId INT,
    CONSTRAINT FK_Employee_Department FOREIGN KEY (departmentId)
        REFERENCES Department(departmentId)
);
GO

-- 5. Thêm FK cho managerId trong Department
ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager FOREIGN KEY (managerId)
    REFERENCES Employee(employeeId);
GO

-- 6. Bảng chấm công (Attendance)
CREATE TABLE Attendance (
    attendanceId INT IDENTITY(1,1) PRIMARY KEY,
    employeeId INT NOT NULL,
    date DATE NOT NULL,
    checkInTime TIME,
    checkOutTime TIME,
    totalHours FLOAT,
    isLate BIT DEFAULT 0,
    lateMinutes INT DEFAULT 0,
    CONSTRAINT FK_Attendance_Employee FOREIGN KEY (employeeId)
        REFERENCES Employee(employeeId)
);
GO

-- 7. Bảng đơn nghỉ phép (LeaveRequest)
CREATE TABLE LeaveRequest (
    requestId INT IDENTITY(1,1) PRIMARY KEY,
    employeeId INT NOT NULL,
    reason NVARCHAR(255),
    startDate DATE NOT NULL,
    endDate DATE NOT NULL,
    status VARCHAR(50) DEFAULT 'Pending' CHECK (status IN ('Pending', 'Approved', 'Rejected')),
    isApproved BIT DEFAULT 0,
    note NVARCHAR(MAX),
    CONSTRAINT FK_LeaveRequest_Employee FOREIGN KEY (employeeId)
        REFERENCES Employee(employeeId)
);
GO

-- 8. Bảng lương (Payroll)
CREATE TABLE Payroll (
    payrollId INT IDENTITY(1,1) PRIMARY KEY,
    employeeId INT NOT NULL,
    month INT NOT NULL,
    year INT NOT NULL,
    totalHours FLOAT,
    baseSalary FLOAT,
    allowance FLOAT,
    totalSalary FLOAT,
    CONSTRAINT FK_Payroll_Employee FOREIGN KEY (employeeId)
        REFERENCES Employee(employeeId)
);
GO

-- 9. Bảng báo cáo nhân sự tổng hợp (HumanResourceReport)
CREATE TABLE HumanResourceReport (
    reportId INT IDENTITY(1,1) PRIMARY KEY,
    generatedBy INT NOT NULL,
    generatedDate DATE NOT NULL,
    department VARCHAR(100),
	month INT NOT NULL,
    year INT NOT NULL,
    totalEmployees INT,
    avgWorkHours FLOAT,
    avgSalary FLOAT,
    numOnLeave INT,
    CONSTRAINT FK_Report_User FOREIGN KEY (generatedBy)
        REFERENCES [User](userId)
);
GO

-- 10. Bảng thống kê nhân viên theo tháng (MonthlyEmployeeSummary)
CREATE TABLE MonthlyEmployeeSummary (
    summaryId INT IDENTITY(1,1) PRIMARY KEY,
    employeeId INT NOT NULL,
    month INT NOT NULL,
    year INT NOT NULL,
    approvedLeaveCount INT DEFAULT 0,
    unapprovedLeaveCount INT DEFAULT 0,
    lateArrivalCount INT DEFAULT 0,
    totalLateMinutes INT DEFAULT 0,
    CONSTRAINT FK_MonthlySummary_Employee FOREIGN KEY (employeeId)
        REFERENCES Employee(employeeId)
);
GO

--Thêm dữ liệu User sử dụng hệ thống HR, Director
INSERT INTO [User] (fullName, username, password, role)
VALUES 
(N'Nguyễn Văn HR', 'hruser', 'hr123', 'HR'),
(N'Trần Thị Director', 'directoruser', 'director123', 'Director');

-- Thêm dữ liệu phòng ban
INSERT INTO Department (name, managerId)
VALUES 
('Marketing', NULL),
('Finance', NULL),
('Sale', NULL);


-- Thêm dữ liệu nhân viên
-- 5 nhân viên Marketing
INSERT INTO Employee (name, dob, gender, position, email, phoneNumber, startDate, departmentId)
VALUES 
(N'Lê Minh Tuấn', '1990-05-12', 'Male', 'Marketing Manager', 'tuan.le@example.com', '0901000001', '2022-01-10', 1), -- Trưởng phòng
(N'Phạm Thị Mai', '1992-08-25', 'Female', 'Marketing Specialist', 'mai.pham@example.com', '0901000002', '2022-03-15', 1),
(N'Nguyễn Hữu Bình', '1991-07-19', 'Male', 'Content Marketer', 'binh.nguyen@example.com', '0901000003', '2021-12-01', 1),
(N'Trần Thị Ngọc', '1993-10-30', 'Female', 'Digital Marketer', 'ngoc.tran@example.com', '0901000004', '2023-01-05', 1),
(N'Đỗ Văn Nam', '1994-04-08', 'Male', 'SEO Executive', 'nam.do@example.com', '0901000005', '2023-02-20', 1);

-- 5 nhân viên Finance
INSERT INTO Employee (name, dob, gender, position, email, phoneNumber, startDate, departmentId)
VALUES 
(N'Nguyễn Văn Hưng', '1988-11-20', 'Male', 'Finance Manager', 'hung.nguyen@example.com', '0902000001', '2021-11-01', 2), -- Trưởng phòng
(N'Trần Thị Hoa', '1993-04-10', 'Female', 'Accountant', 'hoa.tran@example.com', '0902000002', '2022-02-01', 2),
(N'Phạm Văn Khoa', '1990-06-18', 'Male', 'Financial Analyst', 'khoa.pham@example.com', '0902000003', '2023-01-01', 2),
(N'Lý Thị Thanh', '1995-03-25', 'Female', 'Bookkeeper', 'thanh.ly@example.com', '0902000004', '2023-04-10', 2),
(N'Vũ Đức Huy', '1992-09-11', 'Male', 'Auditor', 'huy.vu@example.com', '0902000005', '2022-12-20', 2);

-- 5 nhân viên Sale
INSERT INTO Employee (name, dob, gender, position, email, phoneNumber, startDate, departmentId)
VALUES 
(N'Vũ Đức Long', '1995-09-18', 'Male', 'Sales Manager', 'long.vu@example.com', '0903000001', '2023-01-01', 3), -- Trưởng phòng
(N'Lê Thị Hương', '1996-12-05', 'Female', 'Sales Executive', 'huong.le@example.com', '0903000002', '2023-03-10', 3),
(N'Trịnh Công Sơn', '1991-08-22', 'Male', 'Sales Consultant', 'son.trinh@example.com', '0903000003', '2023-01-20', 3),
(N'Hoàng Thị Tuyết', '1993-11-14', 'Female', 'Sales Assistant', 'tuyet.hoang@example.com', '0903000004', '2023-04-01', 3),
(N'Nguyễn Anh Dũng', '1994-02-17', 'Male', 'Account Manager', 'dung.nguyen@example.com', '0903000005', '2022-11-30', 3);

-- Trưởng phòng ban
UPDATE Department SET managerId = 1 WHERE departmentId = 1;
UPDATE Department SET managerId = 6 WHERE departmentId = 2;
UPDATE Department SET managerId = 11 WHERE departmentId = 3;

-- === Ngày 12/06/2025 ===
INSERT INTO Attendance (employeeId, date, checkInTime, checkOutTime, totalHours, isLate, lateMinutes)
VALUES
(1, '2025-06-12', '08:00', '17:00', 9, 0, 0),
(2, '2025-06-12', '08:05', '17:00', 8.92, 1, 5),
(3, '2025-06-12', '08:10', '17:10', 9, 1, 10),
(4, '2025-06-12', '08:00', '17:00', 9, 0, 0),
(5, '2025-06-12', '08:03', '17:00', 8.95, 1, 3),
(6, '2025-06-12', '08:00', '17:00', 9, 0, 0),
(7, '2025-06-12', '07:55', '17:00', 9.08, 0, 0),
(8, '2025-06-12', '08:12', '17:00', 8.8, 1, 12),
(9, '2025-06-12', '08:00', '17:00', 9, 0, 0),
(10, '2025-06-12', '08:10', '17:10', 9, 1, 10),
(11, '2025-06-12', '08:00', '17:00', 9, 0, 0),
(12, '2025-06-12', '08:15', '17:00', 8.75, 1, 15),
(13, '2025-06-12', '08:00', '17:00', 9, 0, 0),
(14, '2025-06-12', '08:05', '17:05', 9, 1, 5),
(15, '2025-06-12', '08:00', '17:00', 9, 0, 0);

-- === Ngày 13/06/2025 ===
INSERT INTO Attendance (employeeId, date, checkInTime, checkOutTime, totalHours, isLate, lateMinutes)
VALUES
(1, '2025-06-13', '08:10', '17:00', 8.83, 1, 10),
(2, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(3, '2025-06-13', '08:03', '17:00', 8.95, 1, 3),
(4, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(5, '2025-06-13', '08:15', '17:00', 8.75, 1, 15),
(6, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(7, '2025-06-13', '08:05', '17:05', 9, 1, 5),
(8, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(9, '2025-06-13', '08:18', '17:00', 8.7, 1, 18),
(10, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(11, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(12, '2025-06-13', '08:02', '17:00', 8.97, 1, 2),
(13, '2025-06-13', '08:10', '17:00', 8.83, 1, 10),
(14, '2025-06-13', '08:00', '17:00', 9, 0, 0),
(15, '2025-06-13', '08:00', '17:00', 9, 0, 0);

-- === Ngày 14/06/2025 ===
INSERT INTO Attendance (employeeId, date, checkInTime, checkOutTime, totalHours, isLate, lateMinutes)
VALUES
(1, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(2, '2025-06-14', '08:07', '17:00', 8.88, 1, 7),
(3, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(4, '2025-06-14', '08:20', '17:00', 8.67, 1, 20),
(5, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(6, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(7, '2025-06-14', '08:02', '17:00', 8.97, 1, 2),
(8, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(9, '2025-06-14', '08:05', '17:00', 8.92, 1, 5),
(10, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(11, '2025-06-14', '08:10', '17:00', 8.83, 1, 10),
(12, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(13, '2025-06-14', '08:00', '17:00', 9, 0, 0),
(14, '2025-06-14', '08:15', '17:00', 8.75, 1, 15),
(15, '2025-06-14', '08:00', '17:00', 9, 0, 0);

-- Nhân viên phòng Marketing: employeeId 1 (Lê Minh Tuấn), 2 (Phạm Thị Mai)
INSERT INTO LeaveRequest (employeeId, reason, startDate, endDate, status, isApproved, note)
VALUES 
(1, N'Nghỉ phép cá nhân', '2025-06-01', '2025-06-3', N'Pending', 0, N'Cần về quê giải quyết việc gia đình'),
(2, N'Nghỉ du lịch', '2025-06-02', '2025-06-5', N'Pending', 0, N'Du lịch cùng gia đình');

-- Nhân viên phòng Finance: employeeId 6 (Nguyễn Văn Hưng), 7 (Trần Thị Hoa)
INSERT INTO LeaveRequest (employeeId, reason, startDate, endDate, status, isApproved, note)
VALUES 
(6, N'Nghỉ khám bệnh', '2025-06-02', '2025-06-9', N'Pending', 0, N'Trong thời gian điều trị sức khỏe'),
(7, N'Nghỉ phép cá nhân', '2025-06-01', '2025-06-1', N'Pending', 0, N'Có việc cá nhân đột xuất');

-- Nhân viên phòng Sale: employeeId 11 (Vũ Đức Long), 12 (Lê Thị Hương)
INSERT INTO LeaveRequest (employeeId, reason, startDate, endDate, status, isApproved, note)
VALUES 
(11, N'Nghỉ phép hàng năm', '2025-06-01', '2025-06-10', N'Pending', 0, N'Nghỉ phép theo kế hoạch'),
(12, N'Nghỉ du lịch', '2025-06-01', '2025-06-3', N'Pending', 0, N'Tham gia tour du lịch');

INSERT INTO Payroll (employeeId, month, year, totalHours, baseSalary, allowance, totalSalary)
VALUES
-- Marketing
(1, 5, 2025, 160, 25, 200, 160 * 25 + 200),  -- 4200
(2, 5, 2025, 158, 18, 150, 158 * 18 + 150),  -- 2944
(3, 5, 2025, 162, 17, 120, 162 * 17 + 120),  -- 2894
(4, 5, 2025, 160, 17.5, 130, 160 * 17.5 + 130),  -- 2910
(5, 5, 2025, 155, 16, 100, 155 * 16 + 100),  -- 2580

-- Finance
(6, 5, 2025, 160, 27, 250, 160 * 27 + 250),  -- 4630
(7, 5, 2025, 159, 18, 100, 159 * 18 + 100),  -- 2962
(8, 5, 2025, 161, 19, 120, 161 * 19 + 120),  -- 3169
(9, 5, 2025, 158, 17, 90, 158 * 17 + 90),  -- 2686
(10, 5, 2025, 157, 17.5, 80, 157 * 17.5 + 80),  -- 2808

-- Sale
(11, 5, 2025, 160, 26, 300, 160 * 26 + 300),  -- 4500
(12, 5, 2025, 160, 17, 100, 160 * 17 + 100),  -- 2820
(13, 5, 2025, 160, 17.5, 110, 160 * 17.5 + 110),  -- 2910
(14, 5, 2025, 158, 16.5, 95, 158 * 16.5 + 95),  -- 2702
(15, 5, 2025, 159, 18, 120, 159 * 18 + 120);  -- 2922

-- Tháng 1/2025
INSERT INTO Payroll (employeeId, month, year, totalHours, baseSalary, allowance, totalSalary) VALUES
-- Marketing
(1, 1, 2025, 160, 25, 200, 160*25+200),
(2, 1, 2025, 158, 18, 150, 158*18+150),
(3, 1, 2025, 162, 17, 120, 162*17+120),
(4, 1, 2025, 160, 17.5, 130, 160*17.5+130),
(5, 1, 2025, 155, 16, 100, 155*16+100),

-- Finance
(6, 1, 2025, 160, 27, 250, 160*27+250),
(7, 1, 2025, 159, 18, 100, 159*18+100),
(8, 1, 2025, 161, 19, 120, 161*19+120),
(9, 1, 2025, 158, 17, 90, 158*17+90),
(10, 1, 2025, 157, 17.5, 80, 157*17.5+80),

-- Sale
(11, 1, 2025, 160, 26, 300, 160*26+300),
(12, 1, 2025, 160, 17, 100, 160*17+100),
(13, 1, 2025, 160, 17.5, 110, 160*17.5+110),
(14, 1, 2025, 158, 16.5, 95, 158*16.5+95),
(15, 1, 2025, 159, 18, 120, 159*18+120);

-- Tháng 2/2025
INSERT INTO Payroll (employeeId, month, year, totalHours, baseSalary, allowance, totalSalary) VALUES
(1, 2, 2025, 155, 25, 180, 155*25+180),
(2, 2, 2025, 154, 18, 160, 154*18+160),
(3, 2, 2025, 156, 17, 140, 156*17+140),
(4, 2, 2025, 155, 17.5, 150, 155*17.5+150),
(5, 2, 2025, 152, 16, 110, 152*16+110),
(6, 2, 2025, 155, 27, 270, 155*27+270),
(7, 2, 2025, 153, 18, 110, 153*18+110),
(8, 2, 2025, 154, 19, 130, 154*19+130),
(9, 2, 2025, 153, 17, 100, 153*17+100),
(10, 2, 2025, 150, 17.5, 90, 150*17.5+90),
(11, 2, 2025, 156, 26, 310, 156*26+310),
(12, 2, 2025, 155, 17, 105, 155*17+105),
(13, 2, 2025, 157, 17.5, 120, 157*17.5+120),
(14, 2, 2025, 154, 16.5, 100, 154*16.5+100),
(15, 2, 2025, 153, 18, 130, 153*18+130);

-- Tháng 3/2025
INSERT INTO Payroll (employeeId, month, year, totalHours, baseSalary, allowance, totalSalary) VALUES
(1, 3, 2025, 162, 25, 210, 162*25+210),
(2, 3, 2025, 159, 18, 170, 159*18+170),
(3, 3, 2025, 163, 17, 150, 163*17+150),
(4, 3, 2025, 161, 17.5, 160, 161*17.5+160),
(5, 3, 2025, 158, 16, 120, 158*16+120),
(6, 3, 2025, 162, 27, 280, 162*27+280),
(7, 3, 2025, 160, 18, 120, 160*18+120),
(8, 3, 2025, 162, 19, 140, 162*19+140),
(9, 3, 2025, 160, 17, 110, 160*17+110),
(10, 3, 2025, 158, 17.5, 100, 158*17.5+100),
(11, 3, 2025, 162, 26, 320, 162*26+320),
(12, 3, 2025, 160, 17, 110, 160*17+110),
(13, 3, 2025, 161, 17.5, 130, 161*17.5+130),
(14, 3, 2025, 159, 16.5, 110, 159*16.5+110),
(15, 3, 2025, 158, 18, 140, 158*18+140);

-- Tháng 4/2025
INSERT INTO Payroll (employeeId, month, year, totalHours, baseSalary, allowance, totalSalary) VALUES
(1, 4, 2025, 163, 25, 220, 163*25+220),
(2, 4, 2025, 160, 18, 180, 160*18+180),
(3, 4, 2025, 164, 17, 160, 164*17+160),
(4, 4, 2025, 162, 17.5, 170, 162*17.5+170),
(5, 4, 2025, 160, 16, 130, 160*16+130),
(6, 4, 2025, 163, 27, 290, 163*27+290),
(7, 4, 2025, 161, 18, 130, 161*18+130),
(8, 4, 2025, 163, 19, 150, 163*19+150),
(9, 4, 2025, 161, 17, 120, 161*17+120),
(10, 4, 2025, 159, 17.5, 110, 159*17.5+110),
(11, 4, 2025, 163, 26, 330, 163*26+330),
(12, 4, 2025, 161, 17, 115, 161*17+115),
(13, 4, 2025, 162, 17.5, 135, 162*17.5+135),
(14, 4, 2025, 160, 16.5, 115, 160*16.5+115),
(15, 4, 2025, 161, 18, 150, 161*18+150);


-- Tháng 1/2025
INSERT INTO HumanResourceReport (generatedBy, generatedDate, department, month, year, totalEmployees, avgWorkHours, avgSalary, numOnLeave)
VALUES
(1, '2025-01-31', 'IT', 1, 2025, 10, 160, 3000, 2),
(1, '2025-01-31', 'HR', 1, 2025, 5, 150, 2500, 1),
(1, '2025-01-31', 'Finance', 1, 2025, 7, 170, 2800, 3);

-- Tháng 2/2025
INSERT INTO HumanResourceReport (generatedBy, generatedDate, department, month, year, totalEmployees, avgWorkHours, avgSalary, numOnLeave)
VALUES
(1, '2025-02-28', 'IT', 2, 2025, 10, 158, 3050, 1),
(1, '2025-02-28', 'HR', 2, 2025, 5, 148, 2550, 0),
(1, '2025-02-28', 'Finance', 2, 2025, 7, 165, 2820, 2);

-- Tháng 3/2025
INSERT INTO HumanResourceReport (generatedBy, generatedDate, department, month, year, totalEmployees, avgWorkHours, avgSalary, numOnLeave)
VALUES
(1, '2025-03-31', 'IT', 3, 2025, 10, 162, 3100, 3),
(1, '2025-03-31', 'HR', 3, 2025, 5, 149, 2600, 1),
(1, '2025-03-31', 'Finance', 3, 2025, 7, 168, 2850, 2);

-- Tháng 4/2025
INSERT INTO HumanResourceReport (generatedBy, generatedDate, department, month, year, totalEmployees, avgWorkHours, avgSalary, numOnLeave)
VALUES
(1, '2025-04-30', 'IT', 4, 2025, 10, 163, 3150, 2),
(1, '2025-04-30', 'HR', 4, 2025, 5, 151, 2620, 0),
(1, '2025-04-30', 'Finance', 4, 2025, 7, 169, 2880, 1);




-- Xóa khóa ngoại FK_Employee_Department
ALTER TABLE Employee DROP CONSTRAINT FK_Employee_Department;

-- Xóa khóa ngoại FK_Department_Manager
ALTER TABLE Department DROP CONSTRAINT FK_Department_Manager;

-- Xóa khóa ngoại FK_LeaveRequest_Employee
ALTER TABLE LeaveRequest DROP CONSTRAINT FK_LeaveRequest_Employee;

-- Xóa khóa ngoại FK_Attendance_Employee
ALTER TABLE Attendance DROP CONSTRAINT FK_Attendance_Employee;

-- Xóa khóa ngoại FK_Payroll_Employee
ALTER TABLE Payroll DROP CONSTRAINT FK_Payroll_Employee;

-- Xóa khóa ngoại FK_Report_User
ALTER TABLE HumanResourceReport DROP CONSTRAINT FK_Report_User;

ALTER TABLE MonthlyEmployeeSummary DROP CONSTRAINT FK_MonthlySummary_Employee;

-- Xóa bảng phụ thuộc trước
Drop TABLE MonthlyEmployeeSummary;
DROP TABLE HumanResourceReport;
DROP TABLE Payroll;
DROP TABLE Attendance;
DROP TABLE LeaveRequest;

-- Tiếp theo là các bảng trung gian
DROP TABLE Department;
DROP TABLE Employee;

-- Cuối cùng là bảng User (bảng gốc không phụ thuộc ai)
DROP TABLE [User];


select * from "User";
select * from Department;
select * from Employee;
select * from LeaveRequest;
select * from Attendance;
select * from Payroll;
select * from HumanResourceReport;
select * from MonthlyEmployeeSummary;