using System;
namespace CustomerApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public bool IsBooked { get; set; }
        public DateTime? BookedFromDate { get; set; }
        public DateTime? BookedToDate { get; set; }
    }
}

