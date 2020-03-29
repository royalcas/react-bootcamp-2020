using HealthApi.Identity.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HealthApi.Identity
{
	public interface IIdentityLoginService
	{
		string GenerateJwtToken(string username, IdentityUser user);
		Task<IdentityResponse> Login(LoginDto model);
	}
}