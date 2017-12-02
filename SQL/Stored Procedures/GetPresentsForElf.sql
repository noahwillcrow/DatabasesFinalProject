create procedure dbo.GetPresentsForElf
(
	@elfID int
)
as
	select *
	from Presents
	where Presents.ElfID = @elfID
return