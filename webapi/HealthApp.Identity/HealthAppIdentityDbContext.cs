
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthApi.Identity
{
	public class HealthApiIdentityDbContext : IdentityDbContext
	{
		public HealthApiIdentityDbContext(DbContextOptions<HealthApiIdentityDbContext> options)
			: base(options)
		{
		}
	}
}
