create function [dbo].[CalculateEarningsRatio] (
	@elfID int
)
returns int as
begin
	declare @salary int
	set @salary = (select Salary from Elves where ElfID = @elfID)

	declare @presentsMade int
	set @presentsMade = dbo.CalculateNumberOfPresentsByElf(@elfID, 1)

	return @salary / @presentsMade
end