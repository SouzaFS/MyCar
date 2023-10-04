using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using System;
using System.Collections.Generic;

namespace MyCar.Repositories

public class CarRepository
{
    private readonly AppDbContext _appDbContext;

    public CarRepository(AppDbContext appDbContext){
        _appDbContext = appDbContext;
    }

    public async List<Car> GetCars(){
        return await _appDbContext.Cars.ToListAsync();
    }
}