create view dbo.HousesWithOnlyNiceKids
as
	select *
	from Houses
	where (
		select count(KidID)
		from Kids
		where Kids.HouseID = Houses.HouseID and (
			dbo.CalculateNiceness(Kids.KidID) <= 0 or dbo.CalculateNumberOfPresentsForKid(Kids.KidID) = 0
		)
	) = 0