using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HealthApi.Identity
{
    public static class IdentityStartup
	{
		public static void AddIdentityConfig(this IServiceCollection services)
		{
            services.AddDbContext<HealthApiIdentityDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<HealthApiIdentityDbContext>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.AddIdentityServices();
        }
	}
}
