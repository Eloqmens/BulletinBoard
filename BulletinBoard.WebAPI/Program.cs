using BulletinBoard.Application;
using BulletinBoard.Application.Common.Mappings;
using BulletinBoard.Application.Interfaces;
using BulletinBoard.Persistence;
using BulletinBoard.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Конфигурация
ConfigurationManager configuration = builder.Configuration;

// Добовление Сервисов

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IBulletinBoardDbContext).Assembly));
});

builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = 
        JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:44328/";
        options.Audience = "BulletinBoardWebAPI";
        options.RequireHttpsMetadata = false;
    });

// Конвейр
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ServiceProvider = scope.ServiceProvider;
    try
    {
        var context = ServiceProvider.GetRequiredService<BulletinBoardDbContext>();
        DbIntializer.Intialze(context);
    }
    catch (Exception ex)
    {

    }
}

app.UseCustomExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.Run();
