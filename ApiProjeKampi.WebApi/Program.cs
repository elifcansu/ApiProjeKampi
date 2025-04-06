using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using ApiProjeKampi.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>(); //ApiContext sýnýfýný Constructor Method olarak kullandýðýmýzý program.cs e söylüyoruz.
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Þu anda çalýþan assembly’i (yani projenin derlendiði .dll dosyasýný) temsil eder. Bu, AutoMapper'ýn Profile sýnýflarýný bulup otomatik olarak kaydedebilmesi için kullanýlýr.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
