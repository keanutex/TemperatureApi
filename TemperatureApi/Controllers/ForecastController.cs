using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        [HttpGet("ByName")]
        public async Task<IActionResult> ByName(string cityName, int days)
        {
            if (cityName == null || days <= 0)
            {
                return BadRequest("Invalid Data Entered");
            }

            try
            {
                var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(cityName)}&days={HttpUtility.UrlEncode(days.ToString())}");

                ForecastResponse apiresponse = (ForecastResponse)apicall.Result;

                return Ok(apiresponse);
            } catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("ByLonLat")]
        public async Task<IActionResult> ByLonLat(string lat, string lon, int days)
        {
            if (lat == null || lon == null || days <= 0)
            {
                return BadRequest("Invalid Data Entered");
            }

            try
            {
                var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

                ForecastResponse apiresponse = (ForecastResponse)apicall.Result;

                return Ok(apiresponse);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}