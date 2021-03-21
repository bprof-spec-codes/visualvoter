using Data;
using Logic;
using Logic.Class;
using Logic.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotoeBackend
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
            services.AddControllers();
            services.AddTransient<IOneVoteLogic>(x => new OneVoteLogic(Configuration["DBPassword"]));
            services.AddTransient<IAllVotesLogic>(x => new AllVotesLogic(Configuration["DBPassword"]));
            services.AddTransient<AuthLogic, AuthLogic>();

            var connectionString = "server=95.111.254.24;database=projektmunka_teszt;user=projektmunka;password=" + Configuration["DBPassword"] + ";ApplicationIntent=ReadWrite;";
            services.AddDbContext<VotoeDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<IdentityUser, IdentityRole>(
                     option =>
                     {
                         option.Password.RequireDigit = false;
                         option.Password.RequiredLength = 6;
                         option.Password.RequireNonAlphanumeric = false;
                         option.Password.RequireUppercase = false;
                         option.Password.RequireLowercase = false;
                     }
                 ).AddEntityFrameworkStores<VotoeDbContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://www.security.org",
                    ValidIssuer = "http://www.security.org",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abc 123 970608 qwertzuiopõú"))
                };
            });


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                var config =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.production.json", true)
                    .AddEnvironmentVariables()
                    .Build();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
