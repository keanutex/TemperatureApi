using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Model;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentController : ControllerBase
    {
        [HttpGet("ByName")]
        public async Task<IActionResult> DailyByName(string cityName)
        {
            var apicall = ApiCall.CallAsync<CurrentResponse>($"http://api.weatherapi.com/v1/current.json?key=27e6d089e4a04e0db4092022200808&q={HttpUtility.UrlEncode(cityName)}");

            CurrentResponse apiresponse = (CurrentResponse)apicall.Result;

            return Ok(apiresponse);
        }

        [HttpGet("ByLonLat")]
        public async Task<IActionResult> CurrentByLonLat(string lat, string lon)
        {
            var apicall = ApiCall.CallAsync<CurrentResponse>($"http://api.weatherapi.com/v1/current.json?key=27e6d089e4a04e0db4092022200808&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}");

            CurrentResponse apiresponse = (CurrentResponse)apicall.Result;

            return Ok(apiresponse);
        }
    }
}