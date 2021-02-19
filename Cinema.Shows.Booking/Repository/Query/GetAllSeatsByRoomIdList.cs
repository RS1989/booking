using Cinema.Shows.Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Query
{
    public class GetAllSeatsByRoomIdList
    {
        private readonly CinemaDbContext _context;
        private readonly List<long> _roomIds;
        public GetAllSeatsByRoomIdList(CinemaDbContext context, List<long> roomIds)
        {
            _context = context;
            _roomIds = roomIds;
        }

        public IQueryable<Seat> Execute()
        {
            return _context.Seat.Where(s => _roomIds.Contains(s.RoomId)); 
        }
    }
}
