using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentController : ControllerBase
    {
        [HttpGet("ByName")]
        public async Task<IActionResult> DailyByName(string cityName)
        {

            try
            {
                var apicall = ApiCall.CallAsync<CurrentResponse>($"http://api.weatherapi.com/v1/current.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(cityName)}");

                CurrentResponse apiresponse = (CurrentResponse)apicall.Result;

                return Ok(apiresponse);
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("ByLonLat")]
        public async Task<IActionResult> CurrentByLonLat(string lat, string lon)
        {
            try
            {
                var apicall = ApiCall.CallAsync<CurrentResponse>($"http://api.weatherapi.com/v1/current.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}");

                CurrentResponse apiresponse = (CurrentResponse)apicall.Result;

                return Ok(apiresponse);
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }
    }
}