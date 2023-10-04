using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using System;
using System.Collections.Generic;

namespace MyCar.Services

public class CarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository){
        _carRepository = carRepository;
    }

    public async List<Car> GetCars(){
        return await _carRepository.GetCars();
    }
}