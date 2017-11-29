create table dbo.Kids (
	KidID int primary key identity(1,1),
	HouseID int not null,
	[Name] nvarchar(20) not null,
	Gender nvarchar(5) not null,
	Age int not null,   
	constraint FK_Kids_Houses foreign key (HouseID)     
		references Houses(HouseID)    
		on delete cascade
		on update cascade
)
