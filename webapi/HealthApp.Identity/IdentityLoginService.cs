using HealthApi.Identity.Configuration;
using HealthApi.Identity.Model;
using HealthApi.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthApi.Identity
{
    public class IdentityLoginService : IIdentityLoginService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtAuthConfig _configuration;

        public IdentityLoginService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptionsMonitor<JwtAuthConfig> configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration.CurrentValue;
        }

        public async Task<IdentityResponse> Login(LoginDto model)
        {
            var response = new IdentityResponse();
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            response.Success = result.Succeeded;

            if (!result.Succeeded)
            {
                return response;
            }

            var user = _userManager.Users.SingleOrDefault(r => r.Email.Equals(model.Username));
            response.UserId = user.Id;
            response.AuthorizationToken = GenerateJwtToken(model.Username, user);

            return response;
        }

        public string GenerateJwtToken(string username, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToUpper()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration.ExpireDays));

            var token = new JwtSecurityToken(
                _configuration.Issuer,
                _configuration.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
