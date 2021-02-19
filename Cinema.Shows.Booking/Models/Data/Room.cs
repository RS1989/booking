using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Shows.Booking.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
