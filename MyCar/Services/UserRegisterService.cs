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

        public async Task<List<UserRegisterDTO>> GetUsersRegisters()
        {
            return UserRegisterMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        public async Task<UserRegisterDTO> GetUserRegisterById(int id)
        {
            var userRegisterDTO = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return userRegisterDTO != null ? UserRegisterMapper.FromModelToDTO(userRegisterDTO) : null;
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
            var userRegisterDTO = await GetUserRegisterById(id);
            if (userRegisterDTO != null)
            {
                var userRegisterModel = UserRegisterMapper.FromDTOToModel(userRegisterDTO);
                userRegisterModel.Id = id;
                await _baseRepository.DeleteAsync(userRegisterModel);
            }
        }
    }
    

}
