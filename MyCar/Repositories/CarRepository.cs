using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using MyCar.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Repositories { 
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CarModel>> GetCars()
        {
            return await _appDbContext.Cars.ToListAsync();
        }

        public async Task<CarModel> GetCarById(int Id)
        {
            return await _appDbContext.Cars.FindAsync(Id);
        }

        //CRUD = Create, Read, Update and Delete
        public async Task<int> CreateCars(CarModel car)
        {
            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();

            return car.Id;
        }
    }

}
