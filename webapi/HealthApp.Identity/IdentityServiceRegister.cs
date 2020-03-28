using Microsoft.Extensions.DependencyInjection;

namespace HealthApi.Identity
{
	public static class IdentityServiceRegister
	{
		public static void AddIdentityServices(this IServiceCollection services)
		{
			services.AddTransient<IIdentityLoginService, IdentityLoginService>();
			services.AddTransient<IIdentityRegisterService, IdentityRegisterService>();
		}
	}
}
