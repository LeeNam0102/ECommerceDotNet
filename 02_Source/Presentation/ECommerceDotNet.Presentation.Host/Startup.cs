using ECommerceDotNet.Common.Filters;
using ECommerceDotNet.Common.Middlewares;
using ECommerceDotNet.Common.Services;
using ECommerceDotNet.Core.Application.Services;
using ECommerceDotNet.Core.Domain.Repositories;
using ECommerceDotNet.Infrastructure.Persistence.DataContexts;
using ECommerceDotNet.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using Wata.Commerce.Account.Business.MapperProfiles;

namespace ECommerceDotNet.Presentation.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = string.Empty;
            if (Env.IsDevelopment())
            {
                connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            }
            else
            {
                connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_ACCOUNT");
            }

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            //.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });


            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ECommerceDotNet.Infrastructure.Migrations")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Account Aggregator for Web Clients",
                    Version = "v1",
                    Description = "Account Aggregator for Web Clients"
                });
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
              {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                      },
                      Scheme = "oauth2",
                      Name = JwtBearerDefaults.AuthenticationScheme,
                      In = ParameterLocation.Header,

                    },
                    new List<string>()
                  }
                });

            });

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            // Scope Objects
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            //Business
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IValidateTokenService, ValidateTokenService>();

            //Filter
            services.AddScoped<AuthenFilter>();
            services.AddScoped<AuthorFilter>();

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandler>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseCors(
                options => options
                .WithOrigins(Configuration["AllowOrigins"].Split(","))
                .AllowAnyOrigin()
                .WithMethods("POST", "GET", "PUT", "DELETE")
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition")
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
