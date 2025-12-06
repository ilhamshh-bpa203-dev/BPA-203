--create database CompanyMM
USE CompanyMM


CREATE TABLE Employees (
EmployeeID INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
BirthDate DATE,
Email NVARCHAR(200) UNIQUE,
CONSTRAINT CHK_Employee_BirthDate CHECK (BirthDate < '2007-01-01')
)

create table Projects (
ProjectID int primary key identity,
ProjectName NVARCHAR(200),
StartDate DATE,
EndDate DATE,
CONSTRAINT
CHK_Project_Dates CHECK (EndDate > StartDate)
)

CREATE TABLE EmployeeProjects (
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE,

    PRIMARY KEY (EmployeeID, ProjectID),

    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES
('Ilham', 'Huseynov', '1999-05-12', 'ilham@example.com'),
('Aysel', 'Aliyeva', '1995-03-22', 'aysel@example.com'),
('Ramil', 'Karimov', '1990-11-10', 'ramil@example.com'),
('Lala', 'Suleymanova', '1998-07-08', 'lala@example.com'),
('Orxan', 'Mehdiyev',  '1988-09-17', 'orxan@example.com');

INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
('CRM System', '2024-01-10', '2024-07-20'),
('E-Commerce Platform', '2023-05-01', '2024-02-15'),
('Mobile App', '2024-03-01', '2024-10-01');

INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate) VALUES
(1, 1, '2021-01-15'),
(1, 2, '2024-02-01'),
(2, 1, '2022-01-20'),
(3, 3, '2023-03-05'),
(4, 2, '2025-05-10');


-- A. SELECT / JOIN / GROUP BY

-- 1. Bütün employees siyahısı.
SELECT * FROM Employees;

--2. Bütün projects siyahısı.

SELECT * FROM Projects;

-- 3. Hər employee-nin hansı project(lər)-də işlədiyini göstərən sorğu (JOIN ilə).x
SELECT e.FirstName, e.LastName, p.ProjectName
FROM EmployeeProjects ep
JOIN Employees e ON ep.EmployeeID = e.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID;

-- 4. Hər project-ə assign edilmiş employee sayı (GROUP BY ilə).
SELECT p.ProjectName, count(ep.EmployeeID) as 'Employee Count 'FROM EmployeeProjects AS ep
join Projects AS p 
ON p.ProjectID = ep.ProjectID
group by p.ProjectName

-- 5. 2-dən çox project-də işləyən employee-ləri tapın (HAVING istifadə edin).

SELECT e.FirstName, e.LastName, COUNT(ep.ProjectID) FROM EmployeeProjects AS ep
join Employees AS e
ON e.EmployeeID = ep.EmployeeID
GROUP BY e.FirstName, e.LastName
having COUNT(ep.ProjectID)>2


-- B. Views
-- 6. EmployeeProjectView adlı VIEW yaradın: hər sətrdə EmployeeID, FullName, ProjectID, ProjectName, AssignedDate olsun.
CREATE VIEW EmployeeProjectView AS
SELECT e.EmployeeID,(e.FirstName + ' ' + e.LastName) AS FullName,p.ProjectID,p.ProjectName,ep.AssignedDate FROM EmployeeProjects as ep
JOIN Employees AS e
ON e.EmployeeID = ep.EmployeeID
join Projects AS p
ON p.ProjectID = ep.ProjectID


--7. View-dan istifadə edərək bir employee üçün (məsələn EmployeeID = 1) bütün project-ləri göstərin.

select * from EmployeeProjectView where EmployeeID = 1



