using Microsoft.EntityFrameworkCore;
using Contemporary_Programming_Final_Project.Models;

namespace Contemporary_Programming_Final_Project.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TeamMember> TeamMembers { get; set; } = null!;

    public DbSet<Hobby> Hobbies { get; set; }

}