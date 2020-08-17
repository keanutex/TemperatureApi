using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TemperatureApi.Models;

 

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimbingController : ControllerBase
    {        
        [HttpGet("ClimbingConditions")]
        public async Task<IActionResult> ClimbingConditions(string lat, string lon, int days)
        {

            return Ok();
        }
    }
}