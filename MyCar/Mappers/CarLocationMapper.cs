using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class CarLocationMapper
    {
        //DTO = Data Transfer Object
        public static CarLocationDTO FromModelToDTO(CarLocationModel carLocationModel)
        {
            return new CarLocationDTO()
            {
                State = carLocationModel.State,
                City = carLocationModel.City
            };
        }

        public static CarLocationModel FromDTOToModel(CarLocationDTO carLocationDTO)
        {
            return new CarLocationModel()
            {
                State = carLocationDTO.State,
                City = carLocationDTO.City
            };
        }

        public static List<CarLocationDTO> FromModelToDTOList(List<CarLocationModel> carLocationModelList)
        {
            var carLocationDTOList = new List<CarLocationDTO>();

            foreach (var item in carLocationModelList)
                carLocationDTOList.Add(FromModelToDTO(item));

            return carLocationDTOList;
        }
    }
}
