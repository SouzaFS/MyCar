using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using System;
using System.Collections.Generic;

namespace MyCar.Services.Interfaces

public interface ICarService
{
    public async List<Car> GetCars();
}