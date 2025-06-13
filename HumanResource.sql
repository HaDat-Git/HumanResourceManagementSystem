-- 1. Tạo CSDL
CREATE DATABASE humanresource;
GO

USE humanresource;
GO

-- 2. Bảng người dùng hệ thống
CREATE TABLE [User] (
    userId INT IDENTITY(1,1) PRIMARY KEY,
    fullName VARCHAR(100) NOT NULL,
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
    name VARCHAR(100) NOT NULL,
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

ALTER TABLE MonthlyEmployeeSummary DROP CONSTRAINT FK_MonthlyEmployeeSummary_Employee;

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