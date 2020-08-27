using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Dtos;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClimbingController : ControllerBase
    {
        [HttpGet("GetWindForecast")]
        public async Task<IActionResult> GetWindForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");
            List<WindDataDto> list = apiresponse.ToWindDataDto();

            return Ok(list);
        }

        [HttpGet("GetAverageWindForecast")]
        public async Task<IActionResult> GetAverageWindForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");
            var avgWindDataDto = apiresponse.ToAvgWindDataDto();

            return Ok(avgWindDataDto);
        }

        [HttpGet("GetCurrentPressure")]
        public async Task<IActionResult> GetCurrentPressure(string lat, string lon)
        {
            if (lat == null || lon == null)
            {
                return BadRequest("Invalid Data Entered");
            }

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/current.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}");

            PressureDataDto pressureDataDto = apiresponse.ToPressureDataDto();

            return Ok(pressureDataDto);
        }

        // WILL ADD IF THERE IS TIME:
        //[HttpGet("Pressure")]
        //public async Task<IActionResult> GetPressure(string lat, string lon, int days)
        //{
        //    var apicall = ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

        //    ForecastResponse apiresponse = (ForecastResponse)apicall.Result;
        //    List<PressureDataDto> list = apiresponse.ToPressureDataDto();

        //    return Ok(list);
        //}

        [HttpGet("GetPrecipitationForecast")]
        public async Task<IActionResult> GetPrecip(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            List<PrecipitationDataDto> list = apiresponse.ToPrecipitationDataDto();

            return Ok(list);
        }

        [HttpGet("GetAveragePrecipitationForecast")]
        public async Task<IActionResult> GetAveragePrecipitationForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");
            var avgPrecipitationDataDto = apiresponse.ToAvgPrecipitationDataDto();

            return Ok(avgPrecipitationDataDto);
        }

        [HttpGet("GetHumidityForecast")]
        public async Task<IActionResult> GetHumidityForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            List<HumidityDataDto> list = apiresponse.ToHumidityDataDto();

            return Ok(list);
        }

        [HttpGet("GetAverageHumidityForecast")]
        public async Task<IActionResult> GetAverageHumidityForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");
            var avgHumidityDataDto = apiresponse.ToAvgHumidityDataDto();

            return Ok(avgHumidityDataDto);
        }

        [HttpGet("GetSunriseForecast")]
        public async Task<IActionResult> GetSunriseForecast(string lat, string lon, int days)
        {
            if(days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            List<SunriseDataDto> list = apiresponse.ToSunriseDataDto();

            return Ok(list);
        }

        [HttpGet("GetAverageSunriseForecast")]
        public async Task<IActionResult> GetAverageSunriseForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            var avgSunriseDataDto = apiresponse.ToAvgSunriseDataDto();

            return Ok(avgSunriseDataDto);
        }

        [HttpGet("GetSunsetForecast")]
        public async Task<IActionResult> GetSunsetForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            List<SunsetDataDto> list = apiresponse.ToSunsetDataDto();

            return Ok(list);
        }

        [HttpGet("GetAverageSunsetForecast")]
        public async Task<IActionResult> GetAverageSunsetForecast(string lat, string lon, int days)
        {
            if (days > 10 || days <= 0)
                return BadRequest("Please choose a number of days from 1 --> 10");

            var apiresponse = await ApiCall.CallAsync<ForecastResponse>($"http://api.weatherapi.com/v1/forecast.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}&days={HttpUtility.UrlEncode(days.ToString())}");

            var avgSunsetDataDto = apiresponse.ToAvgSunsetDataDto();

            return Ok(avgSunsetDataDto);
        }
    }
}
   