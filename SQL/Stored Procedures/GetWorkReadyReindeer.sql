create procedure dbo.GetWorkReadyReindeer
as
	select *
	from Reindeer
	where Reindeer.Status = 'Healthy'
return