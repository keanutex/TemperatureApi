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
    public class ForecastController : ControllerBase
    {
        [HttpGet("ByName")]
        public async Task<IActionResult> ByName(string cityName, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key=27e6d089e4a04e0db4092022200808&q={HttpUtility.UrlEncode(cityName)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;

            return Ok(apiresponse);
        }

        [HttpGet("ByLonLat")]
        public async Task<IActionResult> ByLonLat(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key=27e6d089e4a04e0db4092022200808&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;

            return Ok(apiresponse);
        }
    }
}