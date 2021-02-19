using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Commands
{
    public class UserAdd
    {
        private readonly CinemaDbContext _context;
        private readonly User _user;

        public UserAdd(CinemaDbContext context, User user)
        {
            _context = context;
            _user = user;
        }

        public void  Execute()
        {
            _context.User.Add(_user);
            _context.SaveChanges();
        }
    }
}
