create procedure dbo.GetDeedsForKid
(
	@kidID int
)
as
	select Deeds.KidID, Deeds.TimeOfDeed
	from Deeds
	where Deeds.KidID = @kidID
return