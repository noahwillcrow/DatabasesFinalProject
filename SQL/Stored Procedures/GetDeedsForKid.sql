create procedure dbo.GetDeedsForKid
(
	@kidID int
)
as
	select *
	from Deeds
	where Deeds.KidID = @kidID
return