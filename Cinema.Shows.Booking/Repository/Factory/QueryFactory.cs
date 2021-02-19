using Cinema.Shows.Booking.Models;
using Cinema.Shows.Booking.Repository.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Shows.Booking.Repository.Factory
{
    public class QueryFactory: IQueryFactory
    {
        private readonly CinemaDbContext _context;
        public QueryFactory(CinemaDbContext context)
        {
            _context = context;
        }

        public IQueryable<Seat> GetAllSeatsByRoomIdList(List<long> roomIds)
        {
            return new GetAllSeatsByRoomIdList(_context, roomIds).Execute();
        }

        public IQueryable<Models.Booking> GetBookingsByShowList(List<long> showsIds)
        {
            return new GetBookingsByShowList(_context, showsIds).Execute();
        }

        public IQueryable<Models.Show> GetAvailableShow(DateTime startDate)
        {
            return new GetAvailableShow(_context, startDate).Execute();
        }

        public IQueryable<Seat> GetSeatsByRoomId(Int64 id)
        {
            return new GetSeatsByRoomId(_context, id).Execute();
        }

        public Models.Show GetShowById(Int64 id)
        {
            return new GetShowById(_context, id).Execute();
        }

        public IQueryable<Models.Booking> GetBookingsByShowId(Int64 id)
        {
            return new GetBookingsByShowId(_context, id).Execute();
        }

        public Models.User GetUserById(Guid id)
        {
            return new GetUserById(_context, id).Execute();
        }
    }
}
