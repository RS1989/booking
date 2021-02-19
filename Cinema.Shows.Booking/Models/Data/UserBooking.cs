using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Shows.Booking.Models
{
    [Table("UserBooking")]
    public class UserBooking
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }
        public Int64 BookingId { get; set; }
    }
}
