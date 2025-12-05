create database Company 
use Company 
 
 create table Countries(
  Id int primary key identity,
 [Name] nvarchar(200) unique not null
 )

 create table Cities(
 Id int primary key identity,
 [Name] nvarchar(200) unique not null,
 CountryId int foreign key references Countries(Id)
 )

 create table Employees(
 Id int primary key identity,
 [Name] nvarchar(25) not null,
 Surname nvarchar(30) default 'XXX',
 Age int check (Age>18),
 Salary decimal(6,2),
 Position nvarchar(50) not null,
 isDeleted bit default 0,
 CityId int foreign key references Cities(Id)
 )

 INSERT INTO Countries ([Name])
VALUES 
('Azerbaijan'),
('Turkey'),
('USA');

INSERT INTO Cities ([Name], CountryId)
VALUES
('Baku', 1),
('Ganja', 1),
('Istanbul', 2),
('Ankara', 2),
('New York', 3),
('Los Angeles', 3);

INSERT INTO Employees ([Name], Surname, Age, Salary, Position, CityId)
VALUES
('Ilham', 'Huseynov', 25, 800.00, 'Reception', 1),
('Aysel', 'Mammadova', 28, 850.00, 'Reception', 1),
('Rashad', 'Aliyev', 30, 1500.00, 'Manager', 3),
('Nigar', 'Qasýmova', 22, 600.00, 'Assistant', 2),
('Emin', 'Mehdiyev', 35, 2000.00, 'Developer', 5),
('Lala', 'Kazimova', 27, 1800.00, 'Designer', 6);

select * from Employees
select * from Cities
select * from Countries

-- *  Ishcilerin ozlerini, yashadiqi sheherlerini ve olkelerini gosterin.
select e.Name as Employee,ci.Name as City,co.Name as Country from Employees as e
join Cities as ci
on e.CityId = ci.Id
join Countries co
on ci.CountryId = co.Id

-- *  Maashi 2000-den yuxari olan ishcilerin adlari ve yashadiqi olkeleri gosterin.

select e.Name as Employee, e.Salary as Salary ,co.Name as Country from Employees as e
join Cities as ci
on e.CityId = ci.Id
join Countries co
on ci.CountryId = co.Id 

-- *  Hansi sheherin hansi olkeye aid olduqunu gosterin.
select ci.Name as City,co.Name as Country from Cities as ci
join Countries as co
on ci.CountryId = co.Id

--* Positioni "Reseption" olan ishcilerin table-larin id-leri daxil olmamaq sherti ile daxil olmamaq sherti ile butun melumatlarini gosterm
--id daxil olmaqla
select * from Employees as e
join Cities as ci
on e.Position = 'Reception' and e.CityId = ci.Id
join Countries as co
on ci.CountryId = co.Id
--id daxil olmamaqla
select e.Name , e.Surname ,e.Age ,e.Salary, e.Position,e.isDeleted,ci.Name as City,co.Name as Country from Employees as e
join Cities as ci
on e.Position = 'Reception' and e.CityId = ci.Id
join Countries as co
on ci.CountryId = co.Id

--* ishden cixan ishcilerin yashadiqi sheher ve olkeleri, hemcinin ishcilerin oz ad ve soyadlarini gosteren query yazin.
update Employees set isDeleted=1 where Id =5

select e.Name , e.Surname ,ci.Name as City,co.Name as Country from Employees as e
join Cities as ci
on e.isDeleted=1 and e.CityId = ci.Id
join Countries as co
on ci.CountryId = co.Id




