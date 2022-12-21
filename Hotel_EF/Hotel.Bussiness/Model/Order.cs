using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Bussiness.Model
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        public long BookingId { get; set; }

        public string FoodItem { get; set; }

        public byte FoodQuantity { get; set; }

        public decimal OrderAmount { get; set; }

        public DateTimeOffset OrderTime { get; set; }

    }
}
