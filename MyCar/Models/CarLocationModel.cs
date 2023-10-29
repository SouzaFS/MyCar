using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Models
{
    public class CarLocationModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int CarModelId { get; set; }
        [ForeignKey("CarModelId")]
        public virtual CarModel CarModel { get; set; }
    }
}
