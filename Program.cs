using Contemporary_Programming_Final_Project.Data;
using Contemporary_Programming_Final_Project.Seeds;
using Microsoft.EntityFrameworkCore;
using NSwag;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Contemporary Programming Final";
    config.Version = "v1";
});

// Wire up EF Core with your connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();
//seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    Seeder.Seed(context);
}

app.MapControllers();

app.Run();