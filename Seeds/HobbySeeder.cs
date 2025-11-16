using System;
using System.Linq;
using Contemporary_Programming_Final_Project.Data;
using Contemporary_Programming_Final_Project.Models;

namespace Contemporary_Programming_Final_Project.Seeds
{
    public static class HobbySeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Hobbies.Any()) return;

            var hobbies = new[]
            {
                new Hobby
                {
                    MemberName = "Corey",
                    HobbyName = "Gaming",
                    YearsDoing = 25,
                    Reason = "Stress relief",
                    LocationType = "Online"
                },
                new Hobby
                {
                    MemberName = "Jimeir",
                    HobbyName = "Exercise",
                    YearsDoing = 5,
                    Reason = "Strengthen muscles",
                    LocationType = "Indoors"
                },
                new Hobby
                {
                    MemberName = "Ryan",
                    HobbyName = "Bowling",
                    YearsDoing = 9,
                    Reason = "Enjoyment",
                    LocationType = "Indoors"
                },
                new Hobby
                {
                    MemberName = "Joey",
                    HobbyName = "Camping",
                    YearsDoing = 13,
                    Reason = "Reconnecting with nature",
                    LocationType = "Outdoors"
                }
            };

            context.Hobbies.AddRange(hobbies);
            context.SaveChanges();
        }
    }
}

