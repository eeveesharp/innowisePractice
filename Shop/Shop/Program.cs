using FluentValidation.AspNetCore;
using Shop.BLL.DI;
using Shop.Mappers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogic(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(Shop.BLL.Mappers.MappingProfile));
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("Shop")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
