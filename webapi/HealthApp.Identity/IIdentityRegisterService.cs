using HealthApi.Identity.Model;
using System.Threading.Tasks;

namespace HealthApi.Identity
{
	public interface IIdentityRegisterService
	{
		Task<IdentityResponse> Register(RegisterDto model);
	}
}