using Microsoft.EntityFrameworkCore;
using MyCar.DTOs;
using MyCar.Mappers;
using MyCar.Models;
using MyCar.Repositories;
using MyCar.Repositories.Interfaces;
using MyCar.Services.Interfaces;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using MyCar.ObjectCheckers;

namespace MyCar.Services
{
    public class UserService : IUserService
    {
        private IBaseRepository<UserModel> _baseRepository = null;

        public UserService(){
            _baseRepository = new BaseRepository<UserModel>();
        }


        public async Task<List<UserModel>> GetUsers()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var userModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return userModel != null ? userModel : null;
        }
        public async Task<UserModel> GetUserByEmail(string email)
        {
            var userModel = await _baseRepository.GetByWhere(a => a.Email == email).FirstOrDefaultAsync();
            return userModel != null ? userModel : null;
        }

        public async Task<UserModel> CreateUser(UserDTO userDTO)
        {
            bool hasNullOrEmptyStrings = NullOrEmptyStrings.IsAnyNullOrEmpty(userDTO);
            if (!hasNullOrEmptyStrings)
            {
                var userModel = await _baseRepository.CreateAsync(UserMapper.FromDTOToModel(userDTO));
                if (userModel != null)
                {
                    return userModel;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<UserModel> UpdateUser(int id, UserDTO userDTO)
        {
            bool hasNullOrEmptyStrings = NullOrEmptyStrings.IsAnyNullOrEmpty(userDTO);
            if (!hasNullOrEmptyStrings)
            {
                var userModel = UserMapper.FromDTOToModel(userDTO);
                userModel.Id = id;
                var result = await _baseRepository.UpdateAsync(userModel);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
           
            
        }

        public async Task<bool> RemoveUserById(int id)
        {
            var userModel = await GetUserById(id);
            if (userModel != null)
            {
                await _baseRepository.DeleteAsync(userModel);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    

}
