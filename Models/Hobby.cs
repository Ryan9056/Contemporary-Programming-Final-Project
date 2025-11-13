using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }

        [Required]
        public string MemberName { get; set; } = string.Empty;

        [Required]
        public string HobbyName { get; set; } = string.Empty;

        public int YearsDoing { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string LocationType { get; set; } = string.Empty;
    }
}
