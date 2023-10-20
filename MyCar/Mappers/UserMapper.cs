using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Mappers
{
    public static class UserMapper
    {
        //DTO = Data Transfer Object
        public static UserDTO FromModelToDTO(UserModel userModel)
        {
            return new UserDTO()
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Phone = userModel.Phone,
                Password = userModel.Password,
                PasswordConfirmation = userModel.PasswordConfirmation
            };
        }

        public static UserModel FromDTOToModel(UserDTO userDTO)
        {
            return new UserModel()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                Password = userDTO.Password,
                PasswordConfirmation = userDTO.PasswordConfirmation
            };
        }

        public static List<UserDTO> FromModelToDTOList(List<UserModel> userModelList)
        {
            var userDTOList = new List<UserDTO>();

            foreach (var item in userModelList)
                userDTOList.Add(FromModelToDTO(item));

            return userDTOList;
        }
    }
}
