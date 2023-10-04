using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetCars();
    }

}
