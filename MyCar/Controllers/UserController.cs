using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCar.DTOs;
using MyCar.Models;
using MyCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsers();

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
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {

                var result = await _userService.GetUserById(id);
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
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            try
            {
                await _userService.CreateUser(userDTO);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };

            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            try
            {
                await _userService.UpdateUser(id, userDTO);
                return Ok();
            }
            catch (Exception)
            {
                return Problem(null, null, 500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            try
            {
                await _userService.RemoveUserById(id);
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
