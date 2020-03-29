using HealthApi.Application.Services;
using HealthApi.Persistence;
using HealthApi.Persistence.Repository;
using HealthApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HealthApi.InversionOfControl
{
	public static class Bootstraper
	{
		public static void AddApplicationServices(this IServiceCollection services, System.Action<DbContextOptionsBuilder> dbOptionsBuilder)
		{
			// Entity Db Context
			services.AddDbContextPool<HealthAppContext>(dbOptionsBuilder);

			// Data
			services.AddScoped<IUserProfileRepository, UserProfileRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<HealthAppContext>();

			// Services
			services.AddScoped<IUserProfileService, UserProfileService>();
		}

	}
}
