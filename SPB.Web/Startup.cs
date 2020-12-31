using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BaseApp.Service;
using BaseApp.Web;
using Belgrade.SqlClient;
using Belgrade.SqlClient.SqlDb;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace SPB.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; protected set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options => {
                options.EnableForHttps = true;
            });

            services.AddSingleton(Configuration);
            services.AddTransient<IAppConfigValues, AppConfigValues>();
            services.AddTransient<IAppService, AppService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddTransient<IQueryPipe>(_ => new QueryPipe(new SqlConnection(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddTransient<ICommand>(_ => new Command(new SqlConnection(Configuration["ConnectionStrings:DefaultConnection"])));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var issuer = Configuration.GetValue<string>("AppSettings:jwt:issuer");
                var audience = Configuration.GetValue<string>("AppSettings:jwt:audience");
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AppSettings:jwt:passPhrase")));

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero, //default is 5 minutes

                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = signingKey
                };

                // Note: On token expiry, the status returned will be 401 (unauthorized)
                // and the response header will contain:
                // www-authenticate: Bearer error="invalid_token", error_description="The token is expired"
            });

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    var origins = Configuration.GetSection("AppSettings:api:cors.allowed.origins").Get<string[]>();
                    
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(origins)
                        .AllowCredentials()
                        .Build();
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase(new PathString("/spb.web"));

            app.UseResponseCompression();

            app.Use_EnableRequestBodyRewind();
            app.Use_AppExceptionMiddleware();

            app.UseAuthentication();
            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Use(async (context, next) => {
                await next();

                // See https://github.com/dotnet/aspnetcore/issues/4398
                // Still required with .net 5 ??
                if (context.Response.StatusCode == 204)
                    context.Response.ContentLength = 0;
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
