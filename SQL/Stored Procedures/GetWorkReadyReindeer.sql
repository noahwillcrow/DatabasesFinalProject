create procedure dbo.GetWorkReadyReindeer
as
	select Reindeer.ReindeerID
	from Reindeer
	where Reindeer.Status = 'Healthy'
return