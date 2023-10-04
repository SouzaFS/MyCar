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

        public CarRepository(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public async Task<List<Car>> GetCars(){
            return await _appDbContext.Cars.ToListAsync();
        }
    }

}
