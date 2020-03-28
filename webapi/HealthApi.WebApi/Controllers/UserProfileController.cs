using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthApi.Application.Services;
using HealthApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            this._userProfileService = userProfileService;
        }

        [HttpPost]
        public void Post([FromBody] UserProfile profile) 
        {
            _userProfileService.Add(profile);
        }
    }
}