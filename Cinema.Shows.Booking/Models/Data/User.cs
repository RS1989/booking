using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Shows.Booking.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserBooking> UserBookings { get; set; }
    }
}
