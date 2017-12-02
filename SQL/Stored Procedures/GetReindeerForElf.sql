create procedure dbo.GetReindeerForElf
(
	@elfID int
)
as
	select *
	from Reindeer
	where Reindeer.CaretakerElfID = @elfID
return