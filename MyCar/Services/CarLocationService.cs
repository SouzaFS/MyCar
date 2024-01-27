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
    public class CarLocationService : ICarLocationService
    {
        private IBaseRepository<CarLocationModel> _baseRepository = null;

        public CarLocationService(){
            _baseRepository = new BaseRepository<CarLocationModel>();
        }

        public async Task<List<CarLocationModel>> GetCarsLocation()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }

        public async Task<CarLocationModel> GetCarLocationById(int id)
        {
            var carLocationModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carLocationModel != null ? carLocationModel : null;
        }

        public async Task CreateCarLocation(CarLocationDTO carLocationDTO)
        {
            await _baseRepository.CreateAsync(CarLocationMapper.FromDTOToModel(carLocationDTO));
        }

        public async Task UpdateCarLocation(int id, CarLocationDTO carLocationDTO)
        {
            var carLocationModel = CarLocationMapper.FromDTOToModel(carLocationDTO);
            carLocationModel.Id = id;
            await _baseRepository.UpdateAsync(carLocationModel);
        }

        public async Task RemoveCarLocationById(int id)
        {
            var carLocationModel = await GetCarLocationById(id);
            if (carLocationModel != null)
            {
                await _baseRepository.DeleteAsync(carLocationModel);
            }
        }
    }
    

}
