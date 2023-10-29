using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class AdvertisingMapper
    {
        //DTO = Data Transfer Object
        public static AdvertisingDTO FromModelToDTO(AdvertisingModel advertisingModel)
        {
            return new AdvertisingDTO()
            {
                Title = advertisingModel.Title,
                Price = advertisingModel.Price,
                Description = advertisingModel.Description,
                CarId = advertisingModel.CarModelId,
                UserId = advertisingModel.UserModelId
            };
        }

        public static AdvertisingModel FromDTOToModel(AdvertisingDTO advertisingDTO)
        {
            return new AdvertisingModel()
            {
                Title = advertisingDTO.Title,
                Price = advertisingDTO.Price,
                Description = advertisingDTO.Description,
                CarModelId = advertisingDTO.CarId,
                UserModelId = advertisingDTO.UserId
            };
        }

        public static List<AdvertisingDTO> FromModelToDTOList(List<AdvertisingModel> advertisingModelList)
        {
            var advertisingDTOList = new List<AdvertisingDTO>();

            foreach (var item in advertisingModelList)
                advertisingDTOList.Add(FromModelToDTO(item));

            return advertisingDTOList;
        }
    }
}
