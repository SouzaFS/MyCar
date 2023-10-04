using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using MyCar.Repositories.Interfaces;
using MyCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository){
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetCars(){
            return await _carRepository.GetCars();
        }
    }

}
