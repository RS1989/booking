using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetAvailableShow
    {
        private readonly CinemaDbContext _context;
        private readonly DateTime _startDate;

        public GetAvailableShow(CinemaDbContext context, DateTime startDate)
        {
            _context = context;
            _startDate = startDate;
        }

        public IQueryable<Models.Show> Execute()
        {
            return _context.Show.Include(s=> s.Room).Include(s=> s.Movie).Where(s => s.StartTime >= _startDate);
        }
    }
}
