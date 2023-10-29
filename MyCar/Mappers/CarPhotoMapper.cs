using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class CarPhotoMapper
    {
        //DTO = Data Transfer Object
        public static CarPhotoDTO FromModelToDTO(CarPhotoModel carPhotoModel)
        {
            return new CarPhotoDTO()
            {
                
            };
        }

        public static CarPhotoModel FromDTOToModel(CarPhotoDTO carPhotoDTO)
        {
            return new CarPhotoModel()
            {
                
            };
        }

        public static List<CarPhotoDTO> FromModelToDTOList(List<CarPhotoModel> carPhotoModelList)
        {
            var carPhotoDTOList = new List<CarPhotoDTO>();

            foreach (var item in carPhotoModelList)
                carPhotoDTOList.Add(FromModelToDTO(item));

            return carPhotoDTOList;
        }
    }
}
