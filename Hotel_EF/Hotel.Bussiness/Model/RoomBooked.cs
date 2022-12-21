using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Bussiness.Model
{
    public class RoomBooked
    {
        [Key]
        public long Id { get; set; }

        public long BookingId { get; set; }

        public short RoomId { get; set; }
    }
}
