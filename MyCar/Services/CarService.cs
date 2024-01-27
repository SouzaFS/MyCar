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
    public class CarService : ICarService
    {
        private IBaseRepository<CarModel> _baseRepository = null;

        public CarService(){
            _baseRepository = new BaseRepository<CarModel>();
        }

        public async Task<List<CarModel>> GetCars()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }
        public async Task<CarModel> GetCarById(int id)
        {
            var carModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carModel != null ? carModel : null;
        }

        public async Task CreateCar(CarDTO carDTO)
        {
            await _baseRepository.CreateAsync(CarMapper.FromDTOToModel(carDTO));
        }

        public async Task UpdateCar(int id, CarDTO carDTO)
        {
            var carModel = CarMapper.FromDTOToModel(carDTO);
            carModel.Id = id;
            await _baseRepository.UpdateAsync(carModel);
        }

        public async Task RemoveCarById(int id)
        {
            var carModel = await GetCarById(id);
            if (carModel != null)
            {
                await _baseRepository.DeleteAsync(carModel);
            }
        }
    }
    

}
