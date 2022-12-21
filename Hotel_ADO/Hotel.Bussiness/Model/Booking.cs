using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Bussiness.Model
{
    public class Booking
    {
        [Key]
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNo { get; set; } 

        public string Address { get; set; }

        public short CityId { get; set; }

        public DateTimeOffset BookingDate { get; set; }

        public DateTimeOffset CheckIn { get; set; }

        public DateTimeOffset CheckOut { get; set; }
    }
}
