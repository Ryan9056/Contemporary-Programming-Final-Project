using Contemporary_Programming_Final_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Contemporary_Programming_Final_Project.Seeds
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.TeamMembers.Any())
            {
                TeamMemberSeeder.Seed(context);
            }

            /*
            if (!context.Hobbies.Any())
            {
                HobbySeeder.Seed(context);
            }
            */

            if (!context.Classes.Any())
            {
                ClassesSeeder.Seed(context);
            }
        }
    }
}