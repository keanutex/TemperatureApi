using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemperatureApi.Helpers;
using TemperatureApi.Models;

namespace TemperatureApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("getToken")]
        public async Task<ActionResult> GetToken([FromForm]LoginInfo loginInfo)
        {
            string uri = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=AIzaSyAHdMx9404tm15RidD_7jF2C4phFaHGt_g";
            using (HttpClient client = new HttpClient())
            {
                FireBaseLoginInfo fireBaseLoginInfo = new FireBaseLoginInfo
                {
                    Email = loginInfo.Username,
                    Password = loginInfo.Password
                };
                var result = await client.PostAsJsonAsync<FireBaseLoginInfo, GoogleToken>(uri, fireBaseLoginInfo);
                Token token = new Token
                {
                    token_type = "Bearer",
                    access_token = result.idToken,
                    id_token = result.idToken,
                    expires_in = int.Parse(result.expiresIn),
                    refresh_token = result.refreshToken

                };
                return Ok(token);
            }
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromForm]LoginInfo loginInfo)
        {
            string uri = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyAHdMx9404tm15RidD_7jF2C4phFaHGt_g";
            using (HttpClient client = new HttpClient())
            {
                FireBaseLoginInfo fireBaseLoginInfo = new FireBaseLoginInfo
                {
                    Email = loginInfo.Username,
                    Password = loginInfo.Password
                };
                var result = await client.PostAsJsonAsync<FireBaseLoginInfo, GoogleToken>(uri, fireBaseLoginInfo);
                Token token = new Token
                {
                    token_type = "Bearer",
                    access_token = result.idToken,
                    id_token = result.idToken,
                    expires_in = int.Parse(result.expiresIn),
                    refresh_token = result.refreshToken

                };
                return Ok(token);
            }
        }

    }
}