using Cinema.Shows.Booking.Models;
using Cinema.Shows.Booking.Repository.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Factory
{
    public class CommandFactory: ICommandFactory
    {
        private readonly CinemaDbContext _context;

        public CommandFactory(CinemaDbContext context)
        {
            _context = context;
        }

        public void UserAdd(User user)
        {
            new UserAdd(_context, user).Execute();
        }

        public Models.Booking BookingAdd(Models.Booking booking)
        {
            var result =  new BookingAdd(_context, booking).Execute();
            return result;
        }

        public void UserBookingAdd(Models.UserBooking userBooking)
        {
            new UserBookingAdd(_context, userBooking).Execute();
        }
    }
}
