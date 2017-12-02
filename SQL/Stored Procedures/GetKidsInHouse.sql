create procedure dbo.GetKidsInHouse
(
	@houseID int
)
as
	select *
	from Kids
	where Kids.HouseID = @houseID
return