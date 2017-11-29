create table dbo.Houses (
	HouseID int primary key identity(1,1),
	FamilyName nvarchar(20) not null,
	Address nvarchar(200) not null,
	HasChimney bit not null
)