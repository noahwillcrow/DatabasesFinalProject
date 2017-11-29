create procedure dbo.GetElvesWorkingOnPresentsForKid
(
	@kidID int
)
as
	select Elves.ElfID
	from Elves
	where exists (
		select Presents.KidID, Presents.ItemID
		from Presents
		where Presents.ElfID = Elves.ElfID and Presents.KidID = @kidID
	)
return