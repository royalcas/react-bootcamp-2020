using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealthApi.WebApi.AppStart;
using HealthApi.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using System.Reflection;
using HealthApi.Identity.Configuration;
using HealthApi.WebApi.Filters;
using HealthApi.InversionOfControl;

namespace HealthApi.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            System.Action<DbContextOptionsBuilder> dbOptionsBuilder = options =>
                    options.UseSqlite(Configuration.GetConnectionString("IdentityDatabase")
            );

            services.AddDbContextPool<HealthApiIdentityDbContext>(dbOptionsBuilder);

            services.AddApplicationServices(dbOptionsBuilder);

            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));


            var jwtAuthConfig = Configuration.GetSection("JwtAuth").Get<JwtAuthConfig>();
            services.Configure<JwtAuthConfig>(options => Configuration.GetSection("JwtAuth").Bind(options));
            services.AddIdentityConfig();
            services.AddJwtAuth(jwtAuthConfig);

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HealthApiIdentityDbContext dbContext)
        {
            app.UseExceptionHandling(env);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Database.EnsureCreated();
        }
    }
}
