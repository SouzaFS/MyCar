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

        public async Task<List<CarAcessoryModel>> GetCarsAcessories()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }
        public async Task<CarAcessoryModel> GetCarAcessoryById(int id)
        {
            var carAcessoryModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carAcessoryModel != null ? carAcessoryModel : null;
        }

        public async Task<CarAcessoryModel> GetCarAcessoriesByCarId(int id)
        {
            var carAcessoryModel = await _baseRepository.GetByWhere(a => a.CarModelId == id).FirstOrDefaultAsync();
            return carAcessoryModel != null ? carAcessoryModel : null;
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
            var carAcessoryModel = await GetCarAcessoryById(id);
            if (carAcessoryModel != null)
            {
                await _baseRepository.DeleteAsync(carAcessoryModel);
            }
        }
    }
    

}
