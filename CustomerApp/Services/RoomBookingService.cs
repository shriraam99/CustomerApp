using System;
using CustomerApp.Models;

namespace CustomerApp.Services
{
    public class RoomBookingService
    {
        private List<Room> rooms = new List<Room>
        {
            new Room { Id = 1, RoomType = "Single", IsBooked = false },
            new Room { Id = 2, RoomType = "Single", IsBooked = false },
            // Initialize more rooms as needed
        };

        public List<UserBooking> UserBookings = new List<UserBooking>();

        public (bool IsSuccess, int RoomNumber) BookRoom(DateTime fromDate, DateTime toDate, string roomType)
        {
            var availableRoom = rooms.FirstOrDefault(room => room.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase)
                                                            && !room.IsBooked
                                                            && (room.BookedFromDate == null || room.BookedToDate < fromDate || room.BookedFromDate > toDate));
            if (availableRoom != null)
            {
                availableRoom.IsBooked = true;
                availableRoom.BookedFromDate = fromDate;
                availableRoom.BookedToDate = toDate;
                UserBookings.Add(new UserBooking { BookingDate = DateTime.Now, RoomNo = availableRoom.Id, RoomType = availableRoom.RoomType });
                return (true, availableRoom.Id);
            }

            return (false, 0);
        }
    }
}

