CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
begin 
	set nocount on;

	SELECT t.Id, t.Title, T.Description, t.Price
	FROM dbo.Rooms r
	INNER JOIN dbo.RoomType t ON t.Id = r.RoomTypeID
	WHERE r.Id NOT IN (
	SELECT b.RoomsId
	FROM dbo.Bookings b
	WHERE (@startDate < b.StartDate and @endDate > b.EndDate)
	OR (b.StartDate <= @endDate and @endDate <b.EndDate)
	OR (b.StartDate <= @startDate and @endDate <b.EndDate)
)
GROUP BY t.Id, t.Title, t.Description, t.Price
end