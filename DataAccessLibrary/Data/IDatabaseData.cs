using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
	public interface IDatabaseData
	{
		void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
		void CheckInGuest(int bookingId);
		List<RoomTypeModel> GetAvailableRooms(DateTime startDate, DateTime endDate);
		List<BookingFullModel> SearchBookings(string lastName);
		public RoomTypeModel GetRoomTypeById(int id);

    }
}