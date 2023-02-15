using CiberSystem.EF;
using CiberSystem.Models.Login;
using CiberSystem.Models.Order;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiberSystem
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
            //services.AddElmahIo(o =>
            //{
            //    o.ApiKey = "API_KEY";
            //    o.LogId = new Guid("LOG_ID");
            //});
            services.AddDbContext<CiBerDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("CiBerDatabase")));


            services.AddTransient<OrderModel>();
            services.AddTransient<LoginModel>();
            services.AddTransient<DBInitial>();
            services.AddTransient<CiBerDbContext>();


            IMvcBuilder builder = services.AddRazorPages();
            var envi = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (envi == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
           
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string singinKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] singinKeyBytes = System.Text.Encoding.UTF8.GetBytes(singinKey);
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme, (options) =>
                {
                    options.LoginPath = "/User/Login";                
                }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = issuer,
                        ValidIssuer = issuer,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(singinKeyBytes)                        ,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                }); ;

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
          //  app.UseElmahIo();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
