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
    public class UserService : IUserService
    {
        private IBaseRepository<UserModel> _baseRepository = null;

        public UserService(){
            _baseRepository = new BaseRepository<UserModel>();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return UserMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        //Estudos para próxima etapa:
        //Linq, Lambda, Ternário
        //Modelagem de Banco de Dados
            //5 formas normais, normalização de banco de dados
        //Diagrama Entidade Relacionamento
            //Gerar diagrama de Entidade Relacionamento com base no Só Carrão
        //Diagrama de Classe UML

        public async Task<UserDTO> GetUserById(int id)
        {
            var userDTO = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return userDTO != null ? UserMapper.FromModelToDTO(userDTO) : null;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
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
            var userDTO = await GetUserById(id);
            var userModel = UserMapper.FromDTOToModel(userDTO);
            userModel.Id = id;
            await _baseRepository.DeleteAsync(userModel);
        }
    }
    

}
