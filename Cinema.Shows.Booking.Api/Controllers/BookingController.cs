using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Shows.Booking.Api.Models;
using Cinema.Shows.Booking.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Shows.Booking.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("show/{fromTime}")]
        public IActionResult GetShow(DateTime fromTime)
        {
            try
            {
                var result = _bookingService.GetAvailableShow(fromTime);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("seats/{showId}")]
        public IActionResult GetSeats(long showId)
        {
            try
            {
                var result = _bookingService.GetAvailableSeatForShow(showId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Book(BookingRequest request)
        {
            try
            {
                _bookingService.BookShow(request.UserId, request.UserName, request.ShowId, request.SeatIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}