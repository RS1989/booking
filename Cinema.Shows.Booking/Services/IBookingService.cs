using System;
using System.Collections.Generic;

namespace Cinema.Shows.Booking.Services
{
    public interface IBookingService
    {
        List<Models.Business.Show> GetAvailableShow(DateTime startTime);
        Models.Business.Show GetAvailableSeatForShow(Int64 id);
        void BookShow(Guid? userId, string userName, Int64 showId, List<Int64> seatIds);
    }
}