create function [dbo].[CalculateEarningsRatio] (
	@elfID int
)
returns float as
begin
	declare @salary int
	set @salary = (select Salary from Elves where ElfID = @elfID)

	declare @presentsMade int
	set @presentsMade = dbo.CalculateNumberOfPresentsByElf(@elfID, 1)

	if @presentsMade = 0
		return 0

	return cast(@salary as float) / cast(@presentsMade as float)
end