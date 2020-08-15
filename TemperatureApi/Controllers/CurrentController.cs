using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentController : ControllerBase
    {
        [HttpGet("ByName")]
        public async Task<IActionResult> DailyByName(string cityName)
        {
            var apicall = ApiCall.CallAsync<CurrentResponse>($"http://api.weatherapi.com/v1/current.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(cityName)}");

            CurrentResponse apiresponse = (CurrentResponse)apicall.Result;

            return Ok(apiresponse);
        }

       
        [HttpGet("ByLonLat")]
        public async Task<IActionResult> CurrentByLonLat(string lat, string lon)
        {
            var apicall = ApiCall.CallAsync<CurrentResponse>($"http://api.weatherapi.com/v1/current.json?key={Secret.weatherapikey}&q={HttpUtility.UrlEncode(lat)},{HttpUtility.UrlEncode(lon)}");

            CurrentResponse apiresponse = (CurrentResponse)apicall.Result;

            return Ok(apiresponse);
        }
    }
}