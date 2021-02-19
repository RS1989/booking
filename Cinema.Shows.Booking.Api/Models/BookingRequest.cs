using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Shows.Booking.Api.Models
{
    public class BookingRequest
    {
        public string UserName { get; set; }
        public Guid? UserId { get; set; }
        public Int64 ShowId { get; set; }
        public List<Int64> SeatIds { get; set; }
    }
}
