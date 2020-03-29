using HealthApi.Identity.Model;
using HealthApi.Identity.Model;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace HealthApi.Identity
{
    public class IdentityRegisterService : IIdentityRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityRegisterService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResponse> Register(RegisterDto model)
        {
            var response = new IdentityResponse();

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            response.UserId = GetUserId(user.UserName);
            response.Success = result.Succeeded;

            return response;
        }

        public string GetUserId(string username)
        {
            var user = _userManager.Users.SingleOrDefault(r => r.Email.Equals(username));
            return user.Id;
        }
    }
}
