using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementWebApp.Pages
{
    public class RoomSearchModel : PageModel
    {
		private readonly IDatabaseData _db;

		[DataType(DataType.Date)]
		[BindProperty(SupportsGet = true)]
		public DateTime StartDate { get; set; } = DateTime.Now;

		[DataType(DataType.Date)]
		[BindProperty(SupportsGet = true)]
		public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

		[BindProperty(SupportsGet = true)]
		public bool SearchEnabled { get; set; } = false;

		public List<RoomTypeModel> AvailableRoomTypes { get; set; }

		public RoomSearchModel(IDatabaseData db)
		{
			_db = db;
		}

		public void OnGet()
		{
			if (SearchEnabled == true)
			{
				AvailableRoomTypes = _db.GetAvailableRooms(StartDate, EndDate);
			}
		}

		public IActionResult OnPost()
		{

			return RedirectToPage(new
			{
				SearchEnabled = true,
				StartDate = StartDate.ToString("yyyy-MM-dd"),
				EndDate = EndDate.ToString("yyyy-MM-dd")
			});
		}
	}
}
