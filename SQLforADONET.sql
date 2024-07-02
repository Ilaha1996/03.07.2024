Create Database EducationDatabase
Use EducationDatabase

Create Table Academies(
Id Int Identity Primary Key,
Name Nvarchar (50)
)

Create Table Groups(
Id Int Identity Primary Key,
Name Nvarchar (50),
AcademyId Int Foreign Key References Academies(Id)
)

Create Table Students(
Id Int Identity Primary Key,
Name Nvarchar (50),
Surname Nvarchar (60),
Age Int,
[Grant] Decimal,
GroupId Int Foreign Key References Groups(Id)
)

Insert Into Academies 
Values
('CodeAcademy')

Insert Into Groups 
Values
('Pb201',1),
('Pb202',1)

Insert Into Students 
Values
('Ilaha','Hasanova',28,500,3),
('Aygun','Aliyeva',29,600,4),
('Simuzer','Faraczade',27,400,3),
('Aida','Soltanli',29,300,4)

