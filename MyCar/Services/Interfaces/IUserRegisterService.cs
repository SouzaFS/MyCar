using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Services.Interfaces
{
    public interface IUserRegisterService
    {
        public Task<List<UserRegisterModel>> GetUsersRegisters();

        public Task<UserRegisterModel> GetUserRegisterById(int id);

        public Task CreateUserRegister(UserRegisterDTO userRegisterDTO);

        public Task UpdateUserRegister(int id, UserRegisterDTO userRegisterDTO);

        public Task RemoveUserRegisterById(int id);
    }

}
