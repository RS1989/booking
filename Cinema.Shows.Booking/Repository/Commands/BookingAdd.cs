using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Commands
{
    public class BookingAdd
    {
        private readonly CinemaDbContext _context;
        private readonly Models.Booking _booking;

        public BookingAdd(CinemaDbContext context, Models.Booking booking)
        {
            _booking = booking;
            _context = context;
        }

        public Models.Booking Execute()
        {
            var result = _context.Booking.Add(_booking);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
