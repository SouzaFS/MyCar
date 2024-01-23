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
    public interface IUserService
    {
        public Task<List<UserDTO>> GetUsers();

        public Task<UserDTO> GetUserById(int id);

        public Task<UserDTO> GetUserByUsername(string username);

        public Task CreateUser(UserDTO userDTO);

        public Task UpdateUser(int id, UserDTO userDTO);

        public Task RemoveUserById(int id);
    }

}
