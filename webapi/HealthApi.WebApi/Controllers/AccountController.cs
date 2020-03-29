﻿using System;
using System.Threading.Tasks;
using HealthApi.Application.Services;
using HealthApi.Identity;
using HealthApi.Identity.Model;
using HealthApi.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IIdentityRegisterService _registerService;
        private readonly IIdentityLoginService _loginService;
        private readonly IIdentityUserProvider _user;

        public AccountController(
            IUserProfileService userProfileService,
            IIdentityRegisterService registerService,
            IIdentityLoginService loginService,
            IIdentityUserProvider user)
        {
            this._userProfileService = userProfileService;
            this._registerService = registerService;
            this._loginService = loginService;
            this._user = user;
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
        [Authorize]
        public IActionResult Profile()
        {
            var userProfile = _userProfileService.GetById(_user.Id);
            return Ok(userProfile);
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AccountRegisterDto model) 
        {
            var registerRequest = new RegisterDto()
            {
                Email = model.Email,
                Password = model.Password,
            };

            var registerResponse = await _registerService.Register(registerRequest);

            if (!registerResponse.Success)
            {
                return Problem("Error Registering user on Identity");
            }

            model.Id = new Guid(registerResponse.UserId);
            _userProfileService.Add(model);

            var loginRequest = new LoginDto()
            {
                Username = model.Email,
                Password = model.Password,
            };

            var loginResponse = await _loginService.Login(loginRequest);

            if (!registerResponse.Success)
            {
                return Problem();
            }

            return Ok(loginResponse);
        }
    }
}