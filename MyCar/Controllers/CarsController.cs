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
        //Async com await
        //Inversão de controle
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

        //Fazer update e delete
        //Referências: Macoratti, Medium

        [HttpGet]
        [Route("{id}")]
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
                await _carService.CreateCars(carDTO);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };

            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(int Id, CarDTO carDTO)
        {
            try
            {
                await _carService.UpdateCar(Id, carDTO);
                return Ok();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int Id)
        {
            try
            {
                await _carService.RemoveCarById(Id);
                return NoContent();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }
    }
}
