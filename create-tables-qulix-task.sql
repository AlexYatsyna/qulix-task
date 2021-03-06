CREATE TABLE Companies(
  CompanyID INTEGER NOT NULL IDENTITY(1,1),
  Name CHAR(30) NOT NULL,
  Size INTEGER NOT NULL Default 0,
  Form INTEGER NOT NULL,
  PRIMARY KEY (CompanyID), 
);

CREATE TABLE Employees(
	EmployeeID INTEGER NOT NULL IDENTITY(1,1),
	CompanyID INTEGER NOT NULL,
	FirstName CHAR(15) NOT NULL,
	LastName CHAR(15) NOT NULL,
	MiddleName CHAR(15) NOT NULL,
	Position INTEGER NOT NULL,
	FirstDay DATE NOT NULL,


	PRIMARY KEY (EmployeeID),
	CONSTRAINT company_id
	FOREIGN KEY(CompanyID)
	REFERENCES Companies
	ON DELETE CASCADE,

);