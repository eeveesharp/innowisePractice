using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{ Title = "Api", Version = "v1", Description = "A simple example ASP.NET Core Web API" });

    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Api2", Version = "v2" });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");

    c.RoutePrefix = string.Empty;
});

app.Run();
