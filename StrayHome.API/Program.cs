using Microsoft.EntityFrameworkCore;

using StrayHome.Application.Contracts.Persistence;
using StrayHome.Application.Features.Commands.CreateShopItem;
using StrayHome.Infrastructure.Data;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using StrayHome.Application.Mappings;
using StrayHome.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Quartz;
using StrayHome.Infrastructure.Authorization;
using StrayHome.API.HostedService;
using StrayHome.Infrastructure.ExcelService;
using StrayHome.Infrastructure.SeleniumService;
using Quartz.Impl;
using Quartz.Spi;
using StrayHome.Infrastructure.Jobs;
using QuartzHostedService = StrayHome.API.HostedService.QuartzHostedService;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IStrayHomeContext, StrayHomeContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("StrayHomeDbContext"),
        new MySqlServerVersion(new Version(8, 0, 32)));
}
);
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddMediatR(typeof(CreateShopItemCommand));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<IAuthorizationHandler, AdminRequirementAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, AdminShelterRequirementAuthorizationHandler>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new AdminRequirement());
    });
    options.AddPolicy("AdminShelter", policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new AdminShelterRequirement());
    });
});
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
builder.Services.AddSingleton<UpdateListOfMissingAnimals>();
builder.Services.AddSingleton<IScheduler>(provider =>
{
    var schedulerFactory = provider.GetRequiredService<ISchedulerFactory>();
    return schedulerFactory.GetScheduler().Result;
});
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddScoped<IExcelProcessingService, ExcelProcessingService>();
builder.Services.AddScoped<ISeleniumService, SeleniumService>();
builder.Services.AddHostedService<MigrationHostedService>();
builder.Services.AddHostedService<UserHostedService>();
builder.Services.AddMemoryCache();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAllOrigins", options => options.AllowAnyOrigin().AllowAnyMethod()
     .AllowAnyHeader());
});

//JSON Serializer
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
    .Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
    = new DefaultContractResolver());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.MapFallbackToFile("index.html");
app.UseStaticFiles();
app.UseDefaultFiles();

app.MapControllers();

app.Run();
