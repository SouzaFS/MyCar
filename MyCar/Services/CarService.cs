using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Mappers;
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

        public async Task<List<CarDTO>> GetCars()
        {
            return CarMapper.FromModelToDTOList(await _carRepository.GetCars());
        }

        public async Task<CarDTO> GetCarById(int Id)
        {
            return CarMapper.FromModelToDTO(await _carRepository.GetCarById(Id));
        }

        public async Task<int> CreateCars(CarDTO carDTO)
        {
            return await _carRepository.CreateCars(CarMapper.FromDTOToModel(carDTO));
        }
    }
    

}
