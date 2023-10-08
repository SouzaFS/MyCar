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

        public async Task<CarModel> GetCarById(int id)
        {
            return await _appDbContext.Cars.FindAsync(id);
        }

        //CRUD = Create, Read, Update and Delete
        public async Task<int> CreateCars(CarModel car)
        {
            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();

            return car.Id;
        }

        public async Task<int> UpdateCar(int id, CarModel car)
        {
            car.Id = id;
            _appDbContext.Cars.Update(car);
            await _appDbContext.SaveChangesAsync();

            return car.Id;
        }

        public async Task<int> RemoveCarById(int id)
        {
            var car = await GetCarById(id);
            _appDbContext.Cars.Remove(car);
            await _appDbContext.SaveChangesAsync();

            return id;
        }
    }

}
