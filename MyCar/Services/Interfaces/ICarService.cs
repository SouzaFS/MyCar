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
    public interface ICarService
    {
        public Task<List<CarDTO>> GetCars();

        public Task<CarDTO> GetCarById(int Id);

        public Task<int> CreateCars(CarDTO carDTO);
    }

}
