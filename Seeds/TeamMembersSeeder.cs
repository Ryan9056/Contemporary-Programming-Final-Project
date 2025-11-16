using System;
using System.Linq;
using Contemporary_Programming_Final_Project.Data;
using Contemporary_Programming_Final_Project.Models;

namespace Contemporary_Programming_Final_Project.Seeds
{
    public static class TeamMemberSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.TeamMembers.Any()) return;

            var teamMembers = new[]
            {
                new TeamMember
                {
                    FullName = "Corey DeRossett",
                    Birthdate = new DateTime(1990, 11, 9),
                    CollegeProgram = "Software Development",
                    YearInProgram = "Senior"
                },
                new TeamMember
                {
                    FullName = "Ryan Wagner",
                    Birthdate = new DateTime(2003, 07, 13),
                    CollegeProgram = "Information Technology",
                    YearInProgram = "Junior"
                },
                new TeamMember
                {
                    FullName = "Jimeir Hales",
                    Birthdate = new DateTime(2001, 04, 05),
                    CollegeProgram = "Information Technology",
                    YearInProgram = "Sophomore"
                },
                new TeamMember
                {
                    FullName = "Joseph Hankins",
                    Birthdate = new DateTime(2006, 06, 03),
                    CollegeProgram = "Information Technology",
                    YearInProgram = "Junior"
                }
            };

            context.TeamMembers.AddRange(teamMembers);
            context.SaveChanges();
        }
    }
}