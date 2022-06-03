using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("RegisterBooking")]
        public IActionResult RegisterBooking(BookingModel bookingModel)
        {
            return Ok(_bookingService.BookingRegister(bookingModel));
        }

        [HttpGet("GetBookings")]
        public IActionResult GetAllBookings()
        {
            return Ok(_bookingService.GetAllBookings());
        }
    }
}
