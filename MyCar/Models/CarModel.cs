using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCar.Models
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Plate { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Version { get; set; }
        public decimal Mileage { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public int CarDoorAmount { get; set; }
        public string CarSeatLiner { get; set; }
        public string CRV { get; set; }
        public string Type { get; set; }
        // public AdvertisingModel? AdvertisingModel { get; set; }
        public ICollection<CarAcessoryModel> CarAcessories { get; set; }
        public ICollection<CarPhotoModel> CarPhotos { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual CarLocationModel? CarLocationModel { get; set; }
        public AdvertisingModel Advertising { get; set; }
    }
}
