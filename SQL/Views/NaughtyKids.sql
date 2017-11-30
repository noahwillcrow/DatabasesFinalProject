create view dbo.NaughtyKids
as
	select *
	from Kids
	where dbo.CalculateNiceness(Kids.KidID) <= 0