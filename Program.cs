using Contemporary_Programming_Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;            // for UseOpenApi / UseSwaggerUi
using NSwag.Generation.AspNetCore; // for AddOpenApiDocument


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenApiDocument();

// ✅ Wire up EF Core with your connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

var app = builder.Build();

// (Optional) Auto-apply any pending migrations at startup (handy in dev)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        // Use NSwag middleware to serve the OpenAPI document and Swagger UI
        app.UseOpenApi();
        app.UseSwaggerUi(options =>
        {
        });
    }

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    ;

app.Run();
