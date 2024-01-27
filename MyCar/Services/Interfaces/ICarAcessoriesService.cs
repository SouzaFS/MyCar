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
    public interface ICarAcessoriesService
    {
        public Task<List<CarAcessoryModel>> GetCarsAcessories();

        public Task<CarAcessoryModel> GetCarAcessoryById(int id);

        public Task<CarAcessoryModel> GetCarAcessoriesByCarId(int id);

        public Task CreateCarAcessory(CarAcessoryDTO carAcessoryDTO);

        public Task UpdateCarAcessory(int id, CarAcessoryDTO carAcessoryDTO);

        public Task RemoveCarAcessoryById(int id);
    }

}
