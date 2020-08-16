﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TemperatureApi.Entities;
using TemperatureApi.Models;
using TemperatureApi.Services;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var response = _userService.registerUser(user);

            if (response == null)
                return BadRequest(new { message = "User already exists" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult test()
        {
            return Ok("test successful");
        }
    }
}
