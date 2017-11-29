create table dbo.Presents (
	KidID int not null,
	ItemID int not null,
	ElfID int not null,
	IsDone bit not null,
	primary key(KidID, ItemID),
	constraint FK_Presents_Kids foreign key (KidID)     
		references Kids(KidID)    
		on delete cascade  
		on update cascade,
	constraint FK_Presents_Items foreign key (ItemID)     
		references Items(ItemID)    
		on delete cascade  
		on update cascade,
	constraint FK_Presents_Elves foreign key (ElfID)     
		references Elves(ElfID)    
		on delete cascade  
		on update cascade
)
