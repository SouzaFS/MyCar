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
    public class CarPhotosService : ICarPhotosService
    {
        private IBaseRepository<CarPhotoModel> _baseRepository = null;

        public CarPhotosService(){
            _baseRepository = new BaseRepository<CarPhotoModel>();
        }

        public async Task<List<CarPhotoModel>> GetCarsPhotos()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }

        public async Task<CarPhotoModel> GetCarPhotoById(int id)
        {
            var carPhotosModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carPhotosModel != null ? carPhotosModel : null;
        }

        public async Task<CarPhotoModel> GetCarPhotosByCarId(int id)
        {
            var carPhotosModel = await _baseRepository.GetByWhere(a => a.CarModelId == id).FirstOrDefaultAsync();
            return carPhotosModel != null ? carPhotosModel : null;
        }

        public async Task CreateCarPhoto(CarPhotoDTO carPhotosDTO)
        {
            await _baseRepository.CreateAsync(CarPhotoMapper.FromDTOToModel(carPhotosDTO));
        }

        public async Task UpdateCarPhoto(int id, CarPhotoDTO carPhotosDTO)
        {
            var carPhotosModel = CarPhotoMapper.FromDTOToModel(carPhotosDTO);
            carPhotosModel.Id = id;
            await _baseRepository.UpdateAsync(carPhotosModel);
        }

        public async Task RemoveCarPhotoById(int id)
        {
            var carPhotosModel = await GetCarPhotoById(id);
            if (carPhotosModel != null)
            {
                await _baseRepository.DeleteAsync(carPhotosModel);
            }
        }
    }
    

}
