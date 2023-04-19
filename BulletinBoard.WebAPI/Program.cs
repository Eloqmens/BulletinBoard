using BulletinBoard.Application;
using BulletinBoard.Application.Common.Mappings;
using BulletinBoard.Application.Interfaces;
using BulletinBoard.Persistence;
using BulletinBoard.WebAPI;
using BulletinBoard.WebAPI.Data;
using BulletinBoard.WebAPI.Middleware;
using BulletinBoard.WebAPI.Models.Identity;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Конфигурация
ConfigurationManager configuration = builder.Configuration;
var connectiongstring = configuration.GetValue<string>("DbContection");
// Добовление Сервисов
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.AddControllers();

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(connectiongstring);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase= false;
})
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "BulletinBoard.Identity.Cookie";
    config.LoginPath = "/Auth/Login";
    config.LogoutPath = "/Auth/Logout";
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IBulletinBoardDbContext).Assembly));
});


// Конвейр
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AuthDbContext>();
        DbInitializer.Intialize(context);
    }
    catch (Exception exception)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occurred while app initialization");
    }
}

//using (var scope = app.Services.CreateScope())
//{
//    var serviceProvider = scope.ServiceProvider;
//    try
//    {
//        var context = serviceProvider.GetRequiredService<BulletinBoardDbContext>();
//        DbIntializer.Intialze(context);
//    }
//    catch (Exception ex)
//    {

//    }
//}

app.UseCustomExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseIdentityServer();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.Run();
