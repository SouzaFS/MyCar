using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Models
{
    public class AdvertisingModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public virtual UserModel UserModel { get; set; }
        public int CarModelId { get; set; }
        [ForeignKey("CarModelId")]
        public virtual CarModel CarModel { get; set; }
    }
}
