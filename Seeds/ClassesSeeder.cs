using System;
using System.Linq;
using Contemporary_Programming_Final_Project.Data;
using Contemporary_Programming_Final_Project.Models;

namespace Contemporary_Programming_Final_Project.Seeds
{
    public static class ClassesSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Classes.Any()) return;

            var classes = new[]
            {
                new Class
                {
                    FullName = "Corey DeRossett",
                    ClassName = "Contemporary Programming",
                    Grade = 100,
                    CreditHours = 3,
                    PassingGrade = "C-"
                },
                new Class
                {
                    FullName = "Ryan Wagner",
                    ClassName = "Human Computer Interaction",
                    Grade = 92,
                    CreditHours = 3,
                    PassingGrade = "C-"
                },
                new Class
                {
                    FullName = "Jimeir Hales",
                    ClassName = "Client Side Web Programming",
                    Grade = 97,
                    CreditHours = 3,
                    PassingGrade = "C-"
                },
                new Class
                {
                    FullName = "Joseph Hankins",
                    ClassName = "Integrated English composition",
                    Grade = 95,
                    CreditHours = 3,
                    PassingGrade = "C-"
                }
            };

            context.Classes.AddRange(classes);
            context.SaveChanges();
        }
    }
}