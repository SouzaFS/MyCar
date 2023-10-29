using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.DTOs
{
    public class AdvertisingDTO
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
