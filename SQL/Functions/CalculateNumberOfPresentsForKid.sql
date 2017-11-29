create function [dbo].[CalculateNumberOfPresentsForKid] (
	@kidID int
)
returns int as
begin
	return (
		select count(ItemID)
		from Presents
		where Presents.KidID = @kidID
	)
end
