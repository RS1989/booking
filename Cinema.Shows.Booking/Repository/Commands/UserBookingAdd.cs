using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Commands
{
    public class UserBookingAdd
    {
        private readonly CinemaDbContext _context;
        private readonly Models.UserBooking _userBooking;

        public UserBookingAdd(CinemaDbContext context, Models.UserBooking userBooking)
        {
            _context = context;
            _userBooking = userBooking;
        }

        public void Execute()
        {
            _context.UserBooking.Add(_userBooking);
            _context.SaveChanges();
        }
    }
}
