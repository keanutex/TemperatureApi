using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TemperatureApi.Dtos;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimbingController : ControllerBase
    {
        [HttpGet("ClimbingConditions")]
        public async Task<IActionResult> ByLonLat(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;

            return Ok(apiresponse);
        }

        [HttpGet("wind")]
        public async Task<IActionResult> GetWind(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            WindDataDto windDataDto = apiresponse.ToWindDataDto();

            return Ok(windDataDto);
        }

        [HttpGet("pressure")]
        public async Task<IActionResult> GetPressure(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            PressureDataDto pressureDataDto = apiresponse.ToPressureDataDto();

            return Ok(pressureDataDto);
        }

        [HttpGet("precip")]
        public async Task<IActionResult> GetPrecip(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            PrecipDataDto precipDataDto = apiresponse.ToPrecipDataDto();

            return Ok(precipDataDto);
        }

        [HttpGet("humidity")]
        public async Task<IActionResult> GetHumidity(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            HumidityDataDto humidityDataDto = apiresponse.ToHumidityDataDto();

            return Ok(humidityDataDto);
        }

        [HttpGet("Sunrise")]
        public async Task<IActionResult> GetSunrise(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            SunriseDataDto sunriseDataDto = apiresponse.ToSunriseDataDto();

            return Ok(sunriseDataDto);
        }
    }
}
   