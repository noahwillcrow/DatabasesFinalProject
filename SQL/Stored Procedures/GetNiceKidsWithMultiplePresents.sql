create procedure dbo.GetNiceKidsWithMultiplePresents
as
	select Kids.KidID
	from Kids
	where dbo.CalculateNiceness(Kids.KidID) > 0 and dbo.CalculateNumberOfPresentsForKid(Kids.KidID) > 1
return