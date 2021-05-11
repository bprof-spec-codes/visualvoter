#pragma warning disable 1591
using Data;
using Logic;
using Logic.Class;
using Logic.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            services.AddTransient<IRoleSwitchLogic>(x => new RoleSwitchLogic(Configuration["DBPassword"]));
            services.AddTransient<AuthLogic, AuthLogic>();
            services.AddSwaggerGen(c =>
            {
                // configure SwaggerDoc and others

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {securityScheme, new string[] { }}
                });
            });
            var connectionString = "server=95.111.254.24;database=projektmunka;user=projektmunka;password=" + Configuration["DBPassword"] + ";ApplicationIntent=ReadWrite;";
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abc 123 970608 qwertzuiop"))
                };
            });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
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
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
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
            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
