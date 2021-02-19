using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetUserById
    {
        private readonly CinemaDbContext _context;
        private readonly Guid _id;

        public GetUserById(CinemaDbContext context, Guid id)
        {
            _context = context;
            _id = id;
        }

        public Models.User Execute()
        {
            return _context.User.FirstOrDefault(u => u.Id == _id);
        }
    }
}
