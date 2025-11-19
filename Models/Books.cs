using System.ComponentModel.DataAnnotations;

namespace Contemporary_Programming_Final_Project.Models;

public class Books
{
    [Key]
    public long ISBN { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public required string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public required int PublicationYear { get; set; }
}
