using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthApi.WebApi.AppStart
{
	public static class ExceptionHandlingStartup
	{
		public static void UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseExceptionHandler("/error-local-development");
			}
			else
			{
				app.UseExceptionHandler("/error");
			}
		}
	}
}
