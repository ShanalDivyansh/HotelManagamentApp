CREATE PROCEDURE dbo.spBookings_Search
@lastName nvarchar(50),
@startDate date
AS
begin
	set nocount on 

	
select b.Id, b.RoomsId, b.GuestsId, b.StartDate, b.EndDate, 
b.CheckedIn, b.TotalCost, g.FirstName, g.LastName, 
r.RoomNumber, r.RoomTypeId, rt.Title, rt.Description, rt.Price
from dbo.Bookings b
inner join dbo.Guests g on b.GuestsId = g.Id
inner join dbo.Rooms r on b.RoomsId = r.Id 
inner join dbo.RoomType rt on r.RoomTypeId = rt.Id
where b.StartDate = @startDate and g.LastName = @lastName;

end