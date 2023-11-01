global using HRIS.Basic.Models;
global using Microsoft.EntityFrameworkCore;
global using HRIS.Basic.Data;
global using System.ComponentModel.DataAnnotations;
using HRIS.Basic.Controllers;
using HRIS.Basic.Mappings;
using HRIS.Basic.Repositories;
using HRIS.Basic.Repositories.Interfaces;
using Microsoft.Identity.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HrisDbRevContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HRISConnectionString")
        );
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
