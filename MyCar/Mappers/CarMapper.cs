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
                Year = carModel.Year,
                Model = carModel.Model,
                Version = carModel.Version,
                Mileage = carModel.Mileage,
                Fuel = carModel.Fuel,
                Transmission = carModel.Transmission,
                CarDoorAmount = carModel.CarDoorAmount,
                CarSeatLiner = carModel.CarSeatLiner,
                CRV = carModel.CRV,
                Type = carModel.Type,
                Color = carModel.Color
            };
        }

        public static CarModel FromDTOToModel(CarDTO carDTO)
        {
            return new CarModel()
            {
                Brand = carDTO.Brand,
                Plate = carDTO.Plate,
                Year = carDTO.Year,
                Model = carDTO.Model,
                Version = carDTO.Version,
                Mileage = carDTO.Mileage,
                Fuel = carDTO.Fuel,
                Transmission = carDTO.Transmission,
                CarDoorAmount = carDTO.CarDoorAmount,
                CarSeatLiner = carDTO.CarSeatLiner,
                CRV = carDTO.CRV,
                Type = carDTO.Type,
                Color = carDTO.Color
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
