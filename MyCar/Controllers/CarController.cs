using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Mappers;
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

        public CarsController(AppDbContext appDbContext, ICarService carService)
        {
            _appDbContext = appDbContext;
            _carService = carService;
        }

        [HttpGet]
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
            }
            else
                return NotFound();
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetCarById(int id)
        {
            try
            {
                
                var result = await _carService.GetCarById(id);
                if (result != null)
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                return Problem(null,null,500);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CarDTO carDTO)
        {
            try
            {
                await _carService.CreateCar(carDTO);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };

            }
            catch (Exception e)
            {
                var teste = e;
                return Problem(null, null, 500);
            }
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateCar(int id, CarDTO carDTO)
        {
            try
            {
                await _carService.UpdateCar(id, carDTO);
                return Ok();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            try
            {
                await _carService.RemoveCarById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                var teste = e;
                return Problem(null, null, 500);
            }
        }
    }
}
