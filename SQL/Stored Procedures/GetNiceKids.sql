create procedure dbo.GetNiceKids
as
	select Kids.KidID
	from Kids
	where dbo.CalculateNiceness(Kids.KidID) > 0
return