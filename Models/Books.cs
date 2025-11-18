namespace Contemporary_Programming_Final_Project.Models;

public class Class
{
    public int ISBN { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public required string Title { get; set; } = string.Empty;
    public string Genre { get; set; }
    public required int PublicationYear { get; set; }
}