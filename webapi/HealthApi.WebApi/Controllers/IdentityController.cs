using System.Threading.Tasks;
using HealthApi.Identity;
using Microsoft.AspNetCore.Mvc;
using HealthApi.Identity.Model;
using System.Net;

namespace HealthApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityRegisterService _registerService;
        private readonly IIdentityLoginService _loginService;

        public IdentityController(IIdentityLoginService loginService, IIdentityRegisterService registerService)
        {
            this._registerService = registerService;
            this._loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _loginService.Login(model);

            if (result.Success)
            {
                return Ok(result);
            }

            return Problem("Invalid Credentials");
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var result = await _registerService.Register(model);

            if (result.Success)
            {
                var login = new LoginDto() 
                {
                    Username = model.Email,
                    Password = model.Password,
                };

                var response = await _loginService.Login(login); 
                return Ok(response);
            }

            return Problem("Error in Register");
        }
    }
}