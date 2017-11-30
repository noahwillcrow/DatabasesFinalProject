create procedure dbo.GetPresentsForKid
(
	@kidID int
)
as
	select *
	from Presents
	where Presents.KidID = @kidID
return