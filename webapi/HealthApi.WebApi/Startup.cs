using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealthApi.WebApi.Configuration;
using Microsoft.AspNetCore.Identity;
using HealthApi.WebApi.AppStart;
using HealthApi.Identity;
using Microsoft.EntityFrameworkCore;

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
            

            services.AddDbContextPool<HealthAppIdentityDbContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("IdentityDatabase")));

            services.AddDbContext<HealthAppIdentityDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<HealthAppIdentityDbContext>()
               .AddDefaultTokenProviders();



            services.AddControllers();
            var jwtAuthConfig = Configuration.GetSection("JwtAuth").Get<JwtAuthConfig>();
            services.Configure<JwtAuthConfig>(options => Configuration.GetSection("JwtAuth").Bind(options));
            services.AddJwtAuth(jwtAuthConfig);
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
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HealthAppIdentityDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
