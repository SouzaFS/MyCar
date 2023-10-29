using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Models
{
    public class CarAcessoryModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Acessory { get; set; }
        public int CarModelId { get; set; }
        [ForeignKey("CarModelId")]
        public CarModel CarModel { get; set; }
        
    }
}
