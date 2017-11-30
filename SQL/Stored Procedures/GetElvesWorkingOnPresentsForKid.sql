create procedure dbo.GetElvesWorkingOnPresentsForKid
(
	@kidID int
)
as
	select *
	from Elves
	where exists (
		select Presents.KidID, Presents.ItemID
		from Presents
		where Presents.ElfID = Elves.ElfID and Presents.KidID = @kidID
	)
return