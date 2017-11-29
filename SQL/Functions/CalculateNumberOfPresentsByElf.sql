create function [dbo].[CalculateNumberOfPresentsByElf] (
	@elfID int,
	@doneOnly bit
)
returns int as
begin
	return (
		select count(*)
		from Presents
		where Presents.ElfID = @elfID and (@doneOnly = 0 or Presents.IsDone = 1)
	)
end