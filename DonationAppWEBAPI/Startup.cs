using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.BuisnessLogic.Implementations;
using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DataStore;
using DonationApp.DataStore.Implementations;
using DonationApp.DataStore.Interfaces;
using DonationApp.DataStore.Seeder;
using DonationApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace DonationAppWEBAPI
{
    public class Startup
    {
        readonly string AllowedOrigins = "_AllowedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IDoneeServices, DoneeServices>();
            services.AddScoped<IDoneeAppDatastore, DoneeAppDatastore>();
            services.AddScoped<IItemServices, ItemServices>();
            services.AddScoped<IDonationServices, DonationServices>();
            services.AddScoped<IAppuserDatastore, AppuserDatastore>();
            services.AddScoped<IItemDatastore, ItemDatastore>();
            services.AddScoped<IDonationDatastore,DonationDatastore>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddDbContext<DonationAppDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
                // options.UseSqlite(Configuration["ConnectionStrings:DefaultConnection"]);

            });
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DonationAppDBContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;

            }
              );
            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = Configuration["JWTSettings:Audience"],
                    ValidIssuer = Configuration["JWTSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero

                };
            });

            services
        .AddControllers()
        .AddNewtonsoftJson( options => options.SerializerSettings
        .ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DonationAppWEBAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                                  
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, DonationAppDBContext donationAppDBContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SeedClass.Seed(roleManager, userManager, donationAppDBContext).Wait();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DonationAppWEBAPI v1"));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowedOrigins);

            app.UseAuthentication();

             app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
