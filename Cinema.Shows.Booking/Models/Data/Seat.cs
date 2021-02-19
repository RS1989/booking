using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Shows.Booking.Models
{
    [Table("Seat")]
    public class Seat
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 RowNumber { get; set; }
        public Int64 SeatNumber { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        public Int64 RoomId { get; set; }
    }
}
