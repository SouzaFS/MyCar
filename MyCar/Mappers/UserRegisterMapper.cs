using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class UserRegisterMapper
    {
        //DTO = Data Transfer Object
        public static UserRegisterDTO FromModelToDTO(UserRegisterModel userRegisterModel)
        {
            return new UserRegisterDTO()
            {
                CPF = userRegisterModel.CPF
            };
        }

        public static UserRegisterModel FromDTOToModel(UserRegisterDTO userRegisterDTO)
        {
            return new UserRegisterModel()
            {
                CPF = userRegisterDTO.CPF
            };
        }

        public static List<UserRegisterDTO> FromModelToDTOList(List<UserRegisterModel> userRegisterModelList)
        {
            var userRegisterDTOList = new List<UserRegisterDTO>();

            foreach (var item in userRegisterModelList)
                userRegisterDTOList.Add(FromModelToDTO(item));

            return userRegisterDTOList;
        }
    }
}
