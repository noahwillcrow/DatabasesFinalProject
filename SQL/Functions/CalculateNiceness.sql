create function [dbo].[CalculateNiceness] (
	@kidID int
)
returns int as
begin
	declare @niceSum int
	set @niceSum = isnull((select sum(Weight) from Deeds where KidID = @kidID and IsNice = 1), 0)

	declare @naughtySum int
	set @naughtySum = isnull((select sum(Weight) from Deeds where KidID = @kidID and IsNice = 0), 0)

	return @niceSum - @naughtySum
end
