create function [dbo].[CalculateNiceness] (
	@kidID int
)
returns int as
begin
	declare @niceSum int
	set @niceSum = (select sum(Weight) from Deeds where KidID = @kidID and IsNice = 1)

	declare @naughtySum int
	set @naughtySum = (select sum(Weight) from Deeds where KidID = @kidID and IsNice = 0)

	return isnull(@niceSum - @naughtySum)
end
