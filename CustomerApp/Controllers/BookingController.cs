using System;
using CustomerApp.Models;
using CustomerApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controllers
{
    public class BookingController : Controller
    {


        private readonly RoomBookingService roomBookingService = new RoomBookingService();

        public IActionResult Index()
        {
            return View("BookRoom");
        }

        [HttpPost]
        public IActionResult BookRoom(BookingModel model)
        {
            var bookingResult = roomBookingService.BookRoom(model.FromDate, model.ToDate, model.RoomType);
            if (bookingResult.IsSuccess)
            {
                ViewBag.SuccessMessage = $"Room booked successfully! Your room number is {bookingResult.RoomNumber}.";
                return View("BookingSuccess", model);
            }
            else
            {
                ViewBag.ErrorMessage = "No rooms available for the selected dates and room type.";
                return View(model);
            }
        }

        public IActionResult MyBookings()
        {
            var bookings = roomBookingService.UserBookings;
            return View(bookings);
        }
    }
}