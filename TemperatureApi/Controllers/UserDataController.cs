using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Models;
using TemperatureApi.Services;

namespace TemperatureApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private UserDataService _UserSubData;

        public UserDataController(UserDataService userService)
        {
            _UserSubData = userService;
        }

        [HttpGet("CheckCondition")]
        public async Task<IActionResult> CheckCondition(string condition)
        {
            int resp = _UserSubData.CheckIfConditionExists(condition);
            if (resp > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("AddData")]
        public async Task<IActionResult> AddData([FromBody] UserSubModel condition)
        {
            int resp = _UserSubData.SubmitUserData(condition);
            if (resp == 1)
            {
                return Ok();
            }
            else
            {
                return NotFound("There might be some issues");
            }
        }

        [HttpGet("GetData")]
        public async Task<IActionResult> GetData()
        {
            List<UserSubReturnModel> resp = _UserSubData.GetUserData();
            if (resp != null)
            {
                return Ok(resp);
            }
            else
            {
                return NotFound("There might be some issues");
            }
        }
    }
}