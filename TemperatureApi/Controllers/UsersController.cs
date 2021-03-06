﻿using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Models;
using TemperatureApi.Services;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] AuthenticateRequest model)
        {
            if (model == null)
            {
                return BadRequest("Invalid Data Entered");
            }

            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Data Entered");
            }

            var response = _userService.registerUser(user);

            if (response.Equals("User already exists"))
                return BadRequest(response);

            return Ok(response);
        }
    }
}
