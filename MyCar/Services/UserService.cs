using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Mappers;
using MyCar.Models;
using MyCar.Repositories;
using MyCar.Repositories.Interfaces;
using MyCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace MyCar.Services
{
    public class UserService : IUserService
    {
        private IBaseRepository<UserModel> _baseRepository = null;
        private MD5 _md5;

        public UserService(){
            _baseRepository = new BaseRepository<UserModel>();
            _md5 = MD5.Create();
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

        public async Task CreateUser(UserDTO userDTO)
        {
            //byte[] encryptPassword = _md5.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
            //userDTO.Password = Convert.ToBase64String(encryptPassword);

            await _baseRepository.CreateAsync(UserMapper.FromDTOToModel(userDTO));
        }

        public async Task UpdateUser(int id, UserDTO userDTO)
        {
            var userModel = UserMapper.FromDTOToModel(userDTO);
            userModel.Id = id;
            await _baseRepository.UpdateAsync(userModel);
        }

        public async Task RemoveUserById(int id)
        {
            var userModel = await GetUserById(id);
            if (userModel != null)
            {
                await _baseRepository.DeleteAsync(userModel);
            } 
        }
    }
    

}
