using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Bussiness.Model
{
    public class Room
    {
        [Key]
        public short Id { get; set; }

        public int RoomNo { get; set; }

        public string RoomType { get; set; }

        public int RoomSize { get; set; }
    }
}
