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
    public class CarAcessoryController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICarAcessoriesService _carAcessoriesService;

        public CarAcessoryController(AppDbContext appDbContext, ICarAcessoriesService carAcessoriesService)
        {
            _appDbContext = appDbContext;
            _carAcessoriesService = carAcessoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarsAcessories()
        {
            var result = await _carAcessoriesService.GetCarsAcessories();

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
        public async Task<IActionResult> GetCarAcessoryById(int id)
        {
            try
            {
                var result = await _carAcessoriesService.GetCarAcessoryById(id);
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

        [HttpGet]
        [Route("CarId")]
        public async Task<IActionResult> GetCarAcessoriesByCarId(int id)
        {
            try
            {
                var result = await _carAcessoriesService.GetCarAcessoriesByCarId(id);
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
                return Problem(null, null, 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarAcessory(CarAcessoryDTO carAcessoryDTO)
        {
            try
            {
                await _carAcessoriesService.CreateCarAcessory(carAcessoryDTO);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };

            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateCarAcessory(int id, CarAcessoryDTO carAcessoryDTO)
        {
            try
            {
                await _carAcessoriesService.UpdateCarAcessory(id, carAcessoryDTO);
                return Ok();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCarAcessoryById(int id)
        {
            try
            {
                await _carAcessoriesService.RemoveCarAcessoryById(id);
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
