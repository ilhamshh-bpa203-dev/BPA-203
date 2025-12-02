CREATE TABLE Employees (
EmployeeID int primary key,
FirstName nvarchar(20) Not Null,
LastName nvarchar(25) Not Null,
Email nvarchar(100),
PhoneNumber int ,
HireDate DateTime,
Constraint CheckHireDate check (HireDate <= GEtDAte()),
JobTitle nvarchar(100),
Salary decimal,
Department nvarchar(100)
)


INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, PhoneNumber, HireDate, JobTitle, Salary, Department)
VALUES
(1, 'Ilham', 'Huseynov', 'ilham@gmail.com', '0501234567', '2023-01-01', 'Developer', 4500, 'IT'),
(2, 'Aysel', 'Aliyeva', 'aysel@gmail.com', '0519876543', '2022-05-12', 'HR Manager', 1500, 'HR'),
(3, 'Murad', 'Ismayilov', 'murad@gmail.com', '0705556677', '2021-09-30', 'Accountant', 1600, 'Finance'),
(4, 'Nigar', 'Rahimli', 'nigar@gmail.com', '0552223344', '2020-03-10', 'Designer', 1300, 'Design'),
(5, 'Elvin', 'Karimov', 'elvin@gmail.com', '0774445566', '2024-02-15', 'QA Engineer', 2100, 'IT');



--select queryler
BEGIN

--Butun iscilerin siyahisi
select * from Employees

--maasi 2000den cox isciler
select * from Employees where Salary>2000

--IT isleyen siyahisi
select * from Employees where Department = 'IT'

--maas azalan sira ile
select * from Employees order by Salary desc

--yalniz firstname ve salary olsun
select FirstName, Salary from Employees

--2020den sora isleyenleri gosteren(hami 2020 sora baslayib)
select * from Employees where HireDate > 2020

--emailinde company.az olani tap(heckimde yoxdur ona gore bos)
select * from Employees where Email like '%company.az' 

END 


--Aggregate Functions
Begin
--enyuksek maas
select MAX(Salary) as MaxSalary from Employees

-- en asaqi maas
select min(Salary) as MinSalary from Employees

--ortalama maas
select AVG(Salary) as AvarageSalary from Employees

--iscilerin umumi sayi
select Count(FirstName) as CountOFEmployees from Employees

--butun maas cemi
select sum(Salary) as SumOfSalary from Employees

end


--GROUP BY Query
begin
--her departmentde olan isciler
SELECT Department,count(*) as EmployeeCount from Employees Group by Department

--her departmentdeki ortalama maas
select Department, avg(Salary) as AvarageOfSalary from Employees group by Department  

--her departmentde en yuksek maas
select Department, max(Salary) as MaxSalary from Employees group by Department

end 


--UPDATE Query
begin
--id=1 olan isci maasi artir
update Employees set Salary = 5000 where EmployeeId =1

--butun iscilere maas 10% artir
update Employees set Salary = Salary + Salary*10/100

--Murad Ismayilov vezifesi HR manager olur
update Employees set JobTitle = 'HR manager' where FirstName = 'Murad' AND LastName = 'Ismayilov'

end

--DELETE Query
begin
--id = 5 olan silinir
delete Employees where EmployeeID = 5
-- 1500den az maasli isci elave edilir ve silinir
INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, PhoneNumber, HireDate, JobTitle, Salary, Department) values 
(6,'Teymur','Memmedov','teymur@gmail.com',0550990432,2019-01-01,'Marketing',700,'Finance'),
(7,'Rehim','Memmedov','rehim@gmail.com',0513943244,2015-11-12,'Marketing',700,'Finance')

delete Employees where Salary<1500
end

--Əlavə

--adinda a herfi olan iscileri tap
select * from Employees where FirstName like '%a%'

--maas 1000 2500 aarasinda olan isciler
select * from Employees where Salary between 1000 and 2500

--IT isleyenleri tap
select * from Employees where Department in ('IT' ,'Finance') 
