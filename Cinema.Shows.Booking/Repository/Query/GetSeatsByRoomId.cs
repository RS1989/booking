using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetSeatsByRoomId
    {
        private readonly CinemaDbContext _context;
        private readonly Int64 _id;

        public GetSeatsByRoomId(CinemaDbContext context, Int64 id)
        {
            _context = context;
            _id = id;
        }

        public IQueryable<Seat> Execute()
        {
            return _context.Seat.Where(s=> s.RoomId == _id);
        }
    }
}
