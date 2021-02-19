using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Shows.Booking.Models
{
    [Table("Show")]
    public class Show
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        public Int64 RoomId { get; set; }        

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
        public Int64 MovieId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
