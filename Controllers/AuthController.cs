using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TUAApi.DTO;
using TUAApi.Services.Auth;
using TUAApi.Services.Product;

namespace TUAApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto user)
        {
            try
            {
                if (user is null)
                {
                    return InvalidRequestPayload("Invalid request");
                }
                else
                {
                    var result = await _authService.LoginUser(user);
                    if (result is not null && result.Token != null)
                    {
                        return OkResult(result);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }

            }
            catch (Exception ex)
            {

                return ServerErrorResult(ex.Message);

            }



        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            try
            {
                if (user is null)
                {
                    return InvalidRequestPayload("Invalid request");
                }
                else
                {
                    var result = await _authService.RegisterUser(user);
                    if (result is not null)
                    {
                        return OkResult(result);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }

            }
            catch (Exception ex)
            {

                return ServerErrorResult(ex.Message);

            }



        }
    }
}
