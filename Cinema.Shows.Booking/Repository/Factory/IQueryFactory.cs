using Cinema.Shows.Booking.Models;
using Cinema.Shows.Booking.Repository.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Shows.Booking.Repository.Factory
{
    public interface IQueryFactory
    {
        IQueryable<Seat> GetAllSeatsByRoomIdList(List<long> roomIds);
        IQueryable<Models.Booking> GetBookingsByShowList(List<long> showsIds);
        IQueryable<Models.Show> GetAvailableShow(DateTime startDate);
        IQueryable<Seat> GetSeatsByRoomId(Int64 id);
        Models.Show GetShowById(Int64 id);
        IQueryable<Models.Booking> GetBookingsByShowId(Int64 id);
        Models.User GetUserById(Guid id);
    }
}