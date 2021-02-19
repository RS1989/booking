using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Shows.Booking.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("ShowId")]
        public virtual Show Show { get; set; }
        public Int64? ShowId { get; set; }

        [ForeignKey("SeatId")]
        public virtual Seat Seat { get; set; }
        public Int64? SeatId { get; set; }

        public ICollection<UserBooking> UserBookings { get; set; }
    }
}
