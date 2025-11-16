namespace Contemporary_Programming_Final_Project.Models;

public class Class
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public required string ClassName { get; set; } = string.Empty;
    public int Grade { get; set; }
    public required int CreditHours { get; set; }
    public required string PassingGrade { get; set; } = string.Empty;
}