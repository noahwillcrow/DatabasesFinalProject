create procedure dbo.GetHousesWithNiceKids
as
	select Houses.HouseID
	from Houses
	where (
		select count(KidID)
		from Kids
		where Kids.HouseID = Houses.HouseID and (
			dbo.CalculateNiceness(Kids.KidID) <= 0 or dbo.CalculateNumberOfPresentsForKid(Kids.KidID) = 0
		)
	) = 0
return