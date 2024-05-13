using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCar.Models
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public decimal Mileage { get; set; }
        public string Fuel { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public int CarDoorAmount { get; set; }
        public string CarSeatLiner { get; set; } = string.Empty;
        public string CRV { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        // public AdvertisingModel? AdvertisingModel { get; set; }
        public ICollection<CarAcessoryModel> CarAcessories { get; set; }
        public ICollection<CarPhotoModel> CarPhotos { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual CarLocationModel CarLocationModel { get; set; }
        public AdvertisingModel Advertising { get; set; }
    }
}
