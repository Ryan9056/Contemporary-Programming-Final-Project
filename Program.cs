using Contemporary_Programming_Final_Project.Data;
using Contemporary_Programming_Final_Project.Seeds;
using Microsoft.EntityFrameworkCore;
using NSwag;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//configuring database context with sql server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Contemporary Programming Final";
    config.Version = "v1";
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();
//seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    Seeder.Seed(context);
}

app.MapControllers();

app.Run();