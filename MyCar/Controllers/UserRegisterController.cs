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
    public class UserRegisterController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserRegisterService _userRegisterService;

        public UserRegisterController(AppDbContext appDbContext, IUserRegisterService userRegisterService)
        {
            _appDbContext = appDbContext;
            _userRegisterService = userRegisterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersRegisters()
        {
            var result = await _userRegisterService.GetUsersRegisters();

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
        public async Task<IActionResult> GetUserRegisterById(int id)
        {
            try
            {
                
                var result = await _userRegisterService.GetUserRegisterById(id);
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
        public async Task<IActionResult> CreateUserRegister(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                await _userRegisterService.CreateUserRegister(userRegisterDTO);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };

            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateUserRegister(int id, UserRegisterDTO userRegisterDTO)
        {
            try
            {
                await _userRegisterService.UpdateUserRegister(id, userRegisterDTO);
                return Ok();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserRegister(int id)
        {
            try
            {
                await _userRegisterService.RemoveUserRegisterById(id);
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
