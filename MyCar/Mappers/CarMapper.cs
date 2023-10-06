using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class CarMapper
    {
        //DTO = Data Transfer Object
        public static CarDTO FromModelToDTO(CarModel carModel)
        {
            return new CarDTO()
            {
                Brand = carModel.Brand,
                Plate = carModel.Plate,
                Price = carModel.Price
            };
        }

        public static CarModel FromDTOToModel(CarDTO carDTO)
        {
            return new CarModel()
            {
                Brand = carDTO.Brand,
                Plate = carDTO.Plate,
                Price = carDTO.Price
            };
        }

        public static List<CarDTO> FromModelToDTOList(List<CarModel> carModelList)
        {
            var carDTOList = new List<CarDTO>();

            foreach (var item in carModelList)
                carDTOList.Add(FromModelToDTO(item));

            return carDTOList;
        }
    }
}
