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
    public interface ICarPhotosService
    {
        public Task<List<CarPhotoDTO>> GetCarsPhotos();

        public Task<CarPhotoDTO> GetCarPhotoById(int id);

        public Task<CarPhotoDTO> GetCarPhotosByCarId(int id);

        public Task CreateCarPhoto(CarPhotoDTO carPhotosDTO);

        public Task UpdateCarPhoto(int id, CarPhotoDTO carPhotosDTO);

        public Task RemoveCarPhotoById(int id);
    }

}
