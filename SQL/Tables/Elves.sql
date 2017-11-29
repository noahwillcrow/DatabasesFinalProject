create table dbo.Elves (
	ElfID int primary key identity(1,1),
	[Name] nvarchar(20) not null,
	YearsOnJob int not null,
	Salary int not null,
	Rank int not null
)