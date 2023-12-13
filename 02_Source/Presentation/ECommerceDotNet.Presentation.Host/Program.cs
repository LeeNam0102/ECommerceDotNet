using ECommerceDotNet.Common.Filters;
using ECommerceDotNet.Common.Middlewares;
using ECommerceDotNet.Common.Services;
using ECommerceDotNet.Core.Application.Services;
using ECommerceDotNet.Core.Domain.Repositories;
using ECommerceDotNet.Infrastructure.Persistence.DataContexts;
using ECommerceDotNet.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using Wata.Commerce.Account.Business.MapperProfiles;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ECommerceDotNet.Infrastructure.Migrations")));

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Account Aggregator for Web Clients",
        Version = "v1",
        Description = "Aggregator for Web Clients"
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

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Scope Objects
//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

//Business
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();


builder.Services.AddScoped<IValidateTokenService, ValidateTokenService>();

//Filter
builder.Services.AddScoped<AuthenFilter>();
builder.Services.AddScoped<AuthorFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandler>();
app.UseMiddleware<JwtMiddleware>();

app.UseCors(options => options
    .WithOrigins(builder.Configuration["AllowOrigins"].Split(","))
    .AllowAnyOrigin()
    .WithMethods("POST", "GET", "PUT", "DELETE")
    .AllowAnyHeader()
    .WithExposedHeaders("Content-Disposition"));

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
