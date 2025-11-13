using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;            // for UseOpenApi / UseSwaggerUi
using NSwag.Generation.AspNetCore; // for AddOpenApiDocument
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Contemporary Programming Final Project API";
});

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();     
    app.UseSwaggerUi();  
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
