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
using System.Threading.Tasks;

namespace MyCar.Services
{
    public class UserRegisterService : IUserRegisterService
    {
        private IBaseRepository<UserRegisterModel> _baseRepository = null;

        public UserRegisterService(){
            _baseRepository = new BaseRepository<UserRegisterModel>();
        }

        public async Task<List<UserRegisterModel>> GetUsersRegisters()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }

        public async Task<UserRegisterModel> GetUserRegisterById(int id)
        {
            var userRegisterModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return userRegisterModel != null ? userRegisterModel : null;
        }

        public async Task CreateUserRegister(UserRegisterDTO userRegisterDTO)
        {
            await _baseRepository.CreateAsync(UserRegisterMapper.FromDTOToModel(userRegisterDTO));
        }

        public async Task UpdateUserRegister(int id, UserRegisterDTO userRegisterDTO)
        {
            var userRegisterModel = UserRegisterMapper.FromDTOToModel(userRegisterDTO);
            userRegisterModel.Id = id;
            await _baseRepository.UpdateAsync(userRegisterModel);
        }

        public async Task RemoveUserRegisterById(int id)
        {
            var userRegisterModel = await GetUserRegisterById(id);
            if (userRegisterModel != null)
            {
                await _baseRepository.DeleteAsync(userRegisterModel);
            }
        }
    }
    

}
