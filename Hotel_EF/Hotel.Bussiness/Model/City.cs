using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Bussiness.Model
{
    public class City
    {
        [Key]
        public short Id { get; set; }

        public string CityName { get; set; }
    }
}
