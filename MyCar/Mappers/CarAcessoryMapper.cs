using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class CarAcessoryMapper
    {
        //DTO = Data Transfer Object
        public static CarAcessoryDTO FromModelToDTO(CarAcessoryModel carAcessoryModel)
        {
            return new CarAcessoryDTO()
            {
                CarId = carAcessoryModel.CarModelId,
                Acessory = carAcessoryModel.Acessory
            };
        }

        public static CarAcessoryModel FromDTOToModel(CarAcessoryDTO carAcessoryDTO)
        {
            return new CarAcessoryModel()
            {
                CarModelId = carAcessoryDTO.CarId,
                Acessory = carAcessoryDTO.Acessory
            };
        }

        public static List<CarAcessoryDTO> FromModelToDTOList(List<CarAcessoryModel> carAcessoryModelList)
        {
            var carAcessoryDTOList = new List<CarAcessoryDTO>();

            foreach (var item in carAcessoryModelList)
                carAcessoryDTOList.Add(FromModelToDTO(item));

            return carAcessoryDTOList;
        }
    }
}
