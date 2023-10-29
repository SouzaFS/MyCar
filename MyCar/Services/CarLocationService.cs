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

        public async Task<List<CarLocationDTO>> GetCarsLocation()
        {
            return CarLocationMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        public async Task<CarLocationDTO> GetCarLocationById(int id)
        {
            var carLocationDTO = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carLocationDTO != null ? CarLocationMapper.FromModelToDTO(carLocationDTO) : null;
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
            var carLocationDTO = await GetCarLocationById(id);
            var carLocationModel = CarLocationMapper.FromDTOToModel(carLocationDTO);
            carLocationModel.Id = id;
            await _baseRepository.DeleteAsync(carLocationModel);
        }
    }
    

}
