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
    public class AdvertisingsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdvertisingService _advertisingService;

        public AdvertisingsController(AppDbContext appDbContext, IAdvertisingService advertisingService)
        {
            _appDbContext = appDbContext;
            _advertisingService = advertisingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAds()
        {
            var result = await _advertisingService.GetAds();

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
        [Route("{id}")]
        public async Task<IActionResult> GetAdById(int id)
        {
            try
            {
                
                var result = await _advertisingService.GetAdById(id);
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
        public async Task<IActionResult> CreateAd(AdvertisingDTO advertisingDTO)
        {
            try
            {
                await _advertisingService.CreateAd(advertisingDTO);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };

            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAd(int id, AdvertisingDTO advertisingDTO)
        {
            try
            {
                await _advertisingService.UpdateAd(id, advertisingDTO);
                return Ok();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAd(int id)
        {
            try
            {
                await _advertisingService.RemoveAdById(id);
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
