using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.Models;
using MyCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICarService _carService;

        //Construtor
        public CarsController(AppDbContext appDbContext, ICarService carService)
        {
            _appDbContext = appDbContext;
            _carService = carService;
        }

        [HttpGet]
        //Async com await
        //Inversão de controle - Injeção de Dependência
        public async Task<IActionResult> GetCars()
        {
            var result = await _carService.GetCars();

            if (result.Count > 0)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }else{
                return NotFound();
            }
        }

        //Fazer o mesmo do get pro post

        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = car
            });
        }
    }
}
