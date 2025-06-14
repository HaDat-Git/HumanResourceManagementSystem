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
    reason VARCHAR(255),
    startDate DATE NOT NULL,
    endDate DATE NOT NULL,
    status VARCHAR(50),
    isApproved BIT DEFAULT 0,
    note VARCHAR(MAX),
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
    totalEmployees INT,
    totalWorkHours FLOAT,
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