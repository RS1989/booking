using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetBookingsByShowList
    {
        private readonly CinemaDbContext _context;
        private readonly List<long> _showsIds;
        public GetBookingsByShowList(CinemaDbContext context, List<long> showsIds)
        {
            _context = context;
            _showsIds = showsIds;
        }

        public IQueryable<Models.Booking> Execute()
        {
            return _context.Booking.Where(b => _showsIds.Contains(b.ShowId.GetValueOrDefault()));
        }
    }
}
