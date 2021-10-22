using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Service;
using Specno_Assessment.Service;
using SpecnoRepository;
using System.Text;

namespace Specno_Assessment
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
            services.AddSwaggerDocument();
            services.AddDbContext<RedditDbContext>();
            services.AddScoped<IRedditService, RedditService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RedditDbContext>();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-my-secret-key"));
            var tokenValidationParameter = new TokenValidationParameters()
            {
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                //ValidateLifetime=false,
                //ClockSkew=TimeSpan.Zero
            };


            services.AddAuthentication(x => x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(jwt =>
                    {
                        //jwt.SaveToken = true;
                        //jwt.RequireHttpsMetadata = true;
                        jwt.TokenValidationParameters = tokenValidationParameter;
                    }
                    );
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
