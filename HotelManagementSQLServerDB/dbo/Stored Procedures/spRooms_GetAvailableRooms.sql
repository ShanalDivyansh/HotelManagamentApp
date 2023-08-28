CREATE PROCEDURE [dbo].[spRooms_GetAvailableRooms]

	@startDate date,
	@endDate date,
	@roomTypeId int

AS
begin
	set nocount on;

	select r.*
	from dbo.Rooms r
	inner join dbo.RoomType t on t.Id = r.RoomTypeId
	where r.RoomTypeID = @roomTypeId
	and r.Id not in (
	select b.RoomsId
	from dbo.Bookings b
	where (@startDate < b.StartDate and @endDate > b.EndDate)
		or (b.StartDate <= @endDate and @endDate < b.EndDate)
		or (b.StartDate <= @startDate and @startDate < b.EndDate)
		);
end