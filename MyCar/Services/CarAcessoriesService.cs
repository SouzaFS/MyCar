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
    public class CarAcessoriesService : ICarAcessoriesService
    {
        private IBaseRepository<CarAcessoryModel> _baseRepository = null;

        public CarAcessoriesService(){
            _baseRepository = new BaseRepository<CarAcessoryModel>();
        }

        public async Task<List<CarAcessoryDTO>> GetCarsAcessories()
        {
            return CarAcessoryMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        //Estudos para próxima etapa:
        //Linq, Lambda, Ternário
        //Modelagem de Banco de Dados
            //5 formas normais, normalização de banco de dados
        //Diagrama Entidade Relacionamento
            //Gerar diagrama de Entidade Relacionamento com base no Só Carrão
        //Diagrama de Classe UML

        public async Task<CarAcessoryDTO> GetCarAcessoryById(int id)
        {
            var carAcessoryDTO = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carAcessoryDTO != null ? CarAcessoryMapper.FromModelToDTO(carAcessoryDTO) : null;
        }

        public async Task<CarAcessoryDTO> GetCarAcessoriesByCarId(int id)
        {
            var carAcessoryDTO = await _baseRepository.GetByWhere(a => a.CarModelId == id).FirstOrDefaultAsync();
            return carAcessoryDTO != null ? CarAcessoryMapper.FromModelToDTO(carAcessoryDTO) : null;
        }

        public async Task CreateCarAcessory(CarAcessoryDTO carAcessoryDTO)
        {
            await _baseRepository.CreateAsync(CarAcessoryMapper.FromDTOToModel(carAcessoryDTO));
        }

        public async Task UpdateCarAcessory(int id, CarAcessoryDTO carAcessoryDTO)
        {
            var carAcessoryModel = CarAcessoryMapper.FromDTOToModel(carAcessoryDTO);
            carAcessoryModel.Id = id;
            await _baseRepository.UpdateAsync(carAcessoryModel);
        }

        public async Task RemoveCarAcessoryById(int id)
        {
            var carAcessoryDTO = await GetCarAcessoryById(id);
            var carAcessoryModel = CarAcessoryMapper.FromDTOToModel(carAcessoryDTO);
            carAcessoryModel.Id = id;
            await _baseRepository.DeleteAsync(carAcessoryModel);
        }
    }
    

}
