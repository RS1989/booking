using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetBookingsByShowId
    {
        private readonly CinemaDbContext _context;
        private readonly Int64 _id;
        public GetBookingsByShowId(CinemaDbContext context, Int64 id)
        {
            _context = context;
            _id = id;
        }

        public IQueryable<Models.Booking> Execute()
        {
            return _context.Booking.Where(b => b.ShowId == _id);
        }
    }
}
