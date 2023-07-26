CREATE TABLE EmployeeProfile(
	EmpId INT IDENTITY(0,1) NOT NULL PRIMARY KEY,
	FullName varchar(100) NOT NULL,
	Dob datetime NOT NULL,
	Address nvarchar(100) NOT NULL,
	UserName varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	UserRole int NOT NULL,
	MonthlySalary decimal(18,0),
	OverTimeRate decimal(18,0),
	Allowances decimal(18,0),
);

CREATE TABLE UserRole (
	RoleId INT IDENTITY(0,1) NOT NULL PRIMARY KEY,
	RoleName varchar(10)
);

INSERT INTO UserRole (RoleName) VALUES ('Admin');
INSERT INTO UserRole (RoleName) VALUES ('Employee');

SELECT * FROM EmployeeProfile;