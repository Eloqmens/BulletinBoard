using BulletinBoard.Application;
using BulletinBoard.Application.Common.Mappings;
using BulletinBoard.Application.Interfaces;
using BulletinBoard.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Конфигурация
ConfigurationManager configuration = builder.Configuration;

// Добовление Сервисов
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

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IBulletinBoardDbContext).Assembly));
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

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.Run();
