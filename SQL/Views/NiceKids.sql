create view dbo.NiceKids
as
	select *
	from Kids
	where dbo.CalculateNiceness(Kids.KidID) > 0