using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Cinema.Shows.Booking.Models.Business
{
    public class Show
    {
        public Show()
        {
            Seats = new List<Seat>();
        }
        public string MovieName { get; set; }
        public string RoomName { get; set; }
        public DateTime Start { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
