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

        public async Task<List<CarPhotoDTO>> GetCarsPhotos()
        {
            return CarPhotoMapper.FromModelToDTOList(await _baseRepository.GetAll().ToListAsync());
        }

        public async Task<CarPhotoDTO> GetCarPhotoById(int id)
        {
            var carPhotosDTO = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return carPhotosDTO != null ? CarPhotoMapper.FromModelToDTO(carPhotosDTO) : null;
        }

        public async Task<CarPhotoDTO> GetCarPhotosByCarId(int id)
        {
            var carPhotosDTO = await _baseRepository.GetByWhere(a => a.CarModelId == id).FirstOrDefaultAsync();
            return carPhotosDTO != null ? CarPhotoMapper.FromModelToDTO(carPhotosDTO) : null;
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
            var carPhotosDTO = await GetCarPhotoById(id);
            var carPhotosModel = CarPhotoMapper.FromDTOToModel(carPhotosDTO);
            carPhotosModel.Id = id;
            await _baseRepository.DeleteAsync(carPhotosModel);
        }
    }
    

}
