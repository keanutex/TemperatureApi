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
        [HttpGet("Wind")]
        public async Task<IActionResult> GetWind(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            List<WindDataDto> list = apiresponse.ToWindDataDto();

            return Ok(list);
        }

        [HttpGet("Pressure")]
        public async Task<IActionResult> GetPressure(string lat, string lon)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/current.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            PressureDataDto pressureDataDto = apiresponse.ToPressureDataDto();

            return Ok(pressureDataDto);
        }

        //[HttpGet("Pressure")]
        //public async Task<IActionResult> GetPressure(string lat, string lon, int days)
        //{
        //    var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

        //    ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
        //    List<PressureDataDto> list = apiresponse.ToPressureDataDto();

        //    return Ok(list);
        //}

        [HttpGet("Precipitation")]
        public async Task<IActionResult> GetPrecip(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            List<PrecipitationDataDto> list = apiresponse.ToPrecipitationDataDto();

            return Ok(list);
        }

        [HttpGet("Humidity")]
        public async Task<IActionResult> GetHumidity(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
            List<HumidityDataDto> list = apiresponse.ToHumidityDataDto();

            return Ok(list);
        }

        [HttpGet("Sunrise")]
        public async Task<IActionResult> GetSunrise(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = apicall.Result;
            List<SunriseDataDto> list = apiresponse.ToSunriseDataDto();

            return Ok(list);
        }

        [HttpGet("Sunset")]
        public async Task<IActionResult> GetSunset(string lat, string lon, int days)
        {
            var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            ForecastResponse apiresponse = apicall.Result;
            List<SunsetDataDto> list = apiresponse.ToSunsetDataDto();

            return Ok(list);
        }
    }
}
   