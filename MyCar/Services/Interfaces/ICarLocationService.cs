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
        public Task<List<CarLocationDTO>> GetCarsLocation();

        public Task<CarLocationDTO> GetCarLocationById(int id);

        public Task CreateCarLocation(CarLocationDTO carLocationDTO);

        public Task UpdateCarLocation(int id, CarLocationDTO carLocationDTO);

        public Task RemoveCarLocationById(int id);
    }

}
