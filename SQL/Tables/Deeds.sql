create table dbo.Deeds (
	KidID int not null,
	TimeOfDeed datetime not null,
	Description nvarchar(200) not null,
	Weight int not null, 
	IsNice bit not null,
	primary key(KidID, TimeOfDeed),
	constraint FK_Deeds_Kids foreign key (KidID)     
		references Kids(KidID)    
		on delete cascade  
		on update cascade 
)
