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

        public Task<CarPhotoDTO> GetCarPhotosById(int id);

        public Task CreateCarPhotos(CarPhotoDTO carPhotosDTO);

        public Task UpdateCarPhotos(int id, CarPhotoDTO carPhotosDTO);

        public Task RemoveCarPhotosById(int id);
    }

}
