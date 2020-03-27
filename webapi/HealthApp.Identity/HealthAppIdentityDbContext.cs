
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthApi.Identity
{
	public class HealthAppIdentityDbContext: IdentityDbContext
	{
		public HealthAppIdentityDbContext(DbContextOptions<HealthAppIdentityDbContext> options)
			:base(options)
		{
		}
	}
}
