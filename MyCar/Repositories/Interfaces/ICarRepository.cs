using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using System;
using System.Collections.Generic;

namespace MyCar.Repositories.Interfaces

public interface ICarRepository
{
    public async List<Car> GetCars();
}