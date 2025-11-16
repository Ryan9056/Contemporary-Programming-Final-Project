namespace Contemporary_Programming_Final_Project.Models;

public class TeamMember
{
    public int Id { get; set; }
     public required string FullName { get; set; } = string.Empty;
     public DateTime Birthdate { get; set; }
    public required string CollegeProgram { get; set; } = string.Empty;
    public required string YearInProgram { get; set; } = string.Empty;
}