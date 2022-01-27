--Partial view--
Create table Branch
(
BranchID int primary Key identity not null,
BranchName varchar(30) not null,
BranchLocation varchar(30) not null,
Division varchar(30) not null
)
go
--Auto Crud--
Create table Department
(
DepartmentID int primary Key identity(5001,1) not null,
DepartmentName varchar(30) not null,
BranchName int  Foreign Key References Branch(BranchID) on delete Cascade 

)
go

Create table Employee
(
EmployeeID int primary key identity(1001,1) not null,
EmployeeName varchar(30) not null,
BranchName int  Foreign Key References Branch(BranchID) on delete Cascade ,
DepartmentName int Foreign Key References Department(DepartmentID),
Email varchar(30),
CellPhone int,
DOB date,
EmployeeImage varchar (MAX)
)
go

Create table Salary
(
SalaryID int primary key identity(101,1) not null,

BranchName int  Foreign Key References Branch(BranchID)  ,
DepartmentName int  Foreign Key References Department(DepartmentID) ,
EmployeeName int  Foreign Key References Employee(EmployeeID) ,
BasicSalary Decimal(10,2),
HouseRent  Decimal(10,2),
TotalSalary as (BasicSalary + HouseRent)
)
go