using Cinema.Shows.Booking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetShowById
    {
        private readonly CinemaDbContext _context;
        private readonly Int64 _id;

        public GetShowById(CinemaDbContext context, Int64 id)
        {
            _context = context;
            _id = id;
        }

        public Models.Show Execute()
        {
            return _context.Show.Include(s=> s.Movie).Include(s=> s.Room).FirstOrDefault(s => s.Id == _id );
        }
    }
}
