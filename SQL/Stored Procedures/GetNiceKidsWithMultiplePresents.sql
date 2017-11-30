create procedure dbo.GetNiceKidsWithMultiplePresents
as
	select *
	from Kids
	where dbo.CalculateNiceness(Kids.KidID) > 0 and dbo.CalculateNumberOfPresentsForKid(Kids.KidID) > 1
return