using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Databases;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
	public class SQLData : IDatabaseData
	{
		private readonly ISQLDataAccess _db;
		private const string connectionStringName = "SqlDb";

		public SQLData(ISQLDataAccess db)
		{
			_db = db;
		}

		public List<RoomTypeModel> GetAvailableRooms(DateTime startDate, DateTime endDate)
		{
			return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes", new { startDate, endDate }, connectionStringName, true);
		}

		public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
		{
			GuestsModel guest = _db.LoadData<GuestsModel, dynamic>("dbo.spGuests_Insert", new { firstName, lastName }, connectionStringName, true).First();
			RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypes where Id = @Id",
																		  new { Id = roomTypeId },
																		  connectionStringName,
																		  false).First();

			TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);


			List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
																				new { startDate, endDate, roomTypeId },
																				connectionStringName,
																				true);

			_db.SaveData("dbo.spBookings_Insert",
						  new
						  {
							  roomId = availableRooms.First().Id,
							  guestId = guest.Id,
							  startDate = startDate,
							  endDate = endDate,
							  totalCost = timeStaying.Days * roomType.Price
						  },
						  connectionStringName,
						  true);
		}
		public List<BookingFullModel> SearchBookings(string lastName)
		{
			return _db.LoadData<BookingFullModel, dynamic>("dbo.spBookings_Search", new { lastName, startDate = DateTime.Now.Date }, connectionStringName, true);
		}

		public void CheckInGuest(int bookingId)
		{
			_db.SaveData("dbo.spBookings_CheckIn", new { Id = bookingId }, connectionStringName, true);
		}
	}
}
