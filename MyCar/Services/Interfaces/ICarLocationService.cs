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
    public interface ICarLocationService
    {
        public Task<List<CarLocationModel>> GetCarsLocation();

        public Task<CarLocationModel> GetCarLocationById(int id);

        public Task CreateCarLocation(CarLocationDTO carLocationDTO);

        public Task UpdateCarLocation(int id, CarLocationDTO carLocationDTO);

        public Task RemoveCarLocationById(int id);
    }

}
