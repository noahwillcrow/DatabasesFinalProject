create table dbo.Reindeer (
	ReindeerID int primary key identity(1,1),
	CaretakerElfID int not null,
	[Name] nvarchar(20) not null,
	Status nvarchar(20) not null,
	constraint FK_Reindeer_Elves foreign key (CaretakerElfID)     
		references Elves(ElfID)    
		on delete cascade  
		on update cascade 
)
